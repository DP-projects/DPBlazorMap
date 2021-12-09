using DPBlazorMapLibrary.JsInterops.Events;
using DPBlazorMapLibrary.JsInterops.Maps;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    public partial class Map
    {
        [Inject]
        internal IJSRuntime JsRuntime { get; set; }

        [Inject]
        internal IMapJsInterop MapJsInterop { get; set; }

        [Inject]
        internal IEventedJsInterop EventedJsInterop { get; set; }

        internal MapEvented MapEvented { get; set; }

        [Parameter]
        public string DivId { get; set; }

        [Parameter]
        public MapOptions MapOptions { get; set; }

        [Parameter]
        public EventCallback AfterRender { get; set; }

        internal IJSObjectReference MapReference { get; set; }

        private const string getCenter = "getCenter";
        private const string getZoom = "getZoom";
        private const string getMinZoom = "getMinZoom";
        private const string getMaxZoom = "getMaxZoom";
        private const string setView = "setView";
        private const string setZoom = "setZoom";
        private const string zoomIn = "zoomIn";
        private const string zoomOut = "zoomOut";
        private const string setZoomAround = "setZoomAround";
        private const string invalidateSize = "invalidateSize";
        private const string fitBounds = "fitBounds";
        private const string panTo = "panTo";
        private const string flyTo = "flyTo";
        private const string flyToBounds = "flyToBounds";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.MapReference = await this.MapJsInterop.Initialize(DivId, this.MapOptions);
                this.MapEvented = new MapEvented(this.MapReference, this.EventedJsInterop);
                await this.AfterRender.InvokeAsync();
            }
        }

        internal async Task<LatLng> GetCenter()
        {
            return await this.MapReference.InvokeAsync<LatLng>(getCenter);
        }

        internal async Task<int> GetZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getZoom);
        }

        internal async Task<int> GetMinZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMinZoom);
        }

        internal async Task<int> GetMaxZoom()
        {
            return await this.MapReference.InvokeAsync<int>(getMaxZoom);
        }

        internal async Task SetView(LatLng latLng)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setView, latLng);
        }

        internal async Task SetZoom(int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoom, zoom);
        }

        internal async Task ZoomIn(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomIn, zoomDelta);
        }

        internal async Task ZoomOut(int zoomDelta)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(zoomOut, zoomDelta);
        }

        internal async Task SetZoomAround(LatLng latLng, int zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(setZoomAround, latLng, zoom);
        }

        internal async Task InvalidateSize()
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(invalidateSize);
        }

        /// <summary>
        /// Задает вид карты (географический центр и масштабирование), выполняя плавную анимацию панорамирования и масштабирования.
        /// https://leafletjs.com/reference.html#:~:text=of%20pixels%20(animated).-,flyTo,-(%3CLatLng%3E%20latlng%2C%20%3CNumber
        /// </summary>
        /// <param name="latLng">lat lng</param>
        /// <param name="zoom">уровень zoom</param>
        /// <returns></returns>
        internal async Task FlyTo(LatLng latLng, int? zoom)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(flyTo, latLng, zoom);
        }

        /// <summary>
        /// Задает вид карты с плавной анимацией, так же как flyTo.
        /// https://leafletjs.com/reference.html#:~:text=pan-zoom%20animation.-,flyToBounds,-(%3CLatLngBounds%3E%20bounds%2C%20%3CfitBounds
        /// </summary>
        /// <param name="latLngBounds">область</param>
        /// <returns></returns>
        internal async Task FlyToBounds(LatLngBounds latLngBounds)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(flyToBounds, latLngBounds);
        }

        /// <summary>
        /// Задает вид карты, содержащий заданные географические границы, с максимально возможным уровнем масштабирования.
        /// https://leafletjs.com/reference.html#:~:text=left%20corner)%20stationary.-,fitBounds,-(%3CLatLngBounds%3E%20bounds%2C%20%3CfitBounds
        /// </summary>
        /// <param name="latLngBounds">область</param>
        internal async Task FitBounds(LatLngBounds latLngBounds)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(fitBounds, latLngBounds);
        }

        /// <summary>
        /// Перемещает карту в заданный центр.
        /// https://leafletjs.com/reference.html#:~:text=zoom%20level%20possible.-,panTo,-(%3CLatLng%3E%20latlng%2C%20%3CPan
        /// </summary>
        /// <param name="latLng">lat lng</param>
        /// <param name="animate">If true, panning will always be animated if possible. If false, it will not animate panning, either resetting the map view if panning more than a screen away, or just setting a new offset for the map pane (except for panBy which always does the latter).</param>
        /// <param name="duration">Duration of animated panning, in seconds.</param>
        /// <param name="easeLinearity">The curvature factor of panning animation easing (third parameter of the Cubic Bezier curve). 1.0 means linear animation, and the smaller this number, the more bowed the curve.</param>
        /// <param name="noMoveStart">If true, panning won't fire movestart event on start (used internally for panning inertia).</param>
        /// <returns></returns>
        internal async Task PanTo(LatLng latLng, bool animate = true, float duration = 0.25f, float easeLinearity = 0.25f, bool noMoveStart = false)
        {
            await this.MapReference.InvokeAsync<IJSObjectReference>(panTo, latLng, animate, duration, easeLinearity, noMoveStart);
        }

        internal async Task OnClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnClick(callback);
        }

        internal async Task OnDblClick(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnDblClick(callback);
        }

        internal async Task OnMouseDown(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseDown(callback);
        }

        internal async Task OnMouseUp(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseUp(callback);
        }

        internal async Task OnMouseOver(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOver(callback);
        }

        internal async Task OnMouseOut(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnMouseOut(callback);
        }

        internal async Task OnContextMenu(Func<MouseEvent, Task> callback)
        {
            await this.MapEvented.OnContextMenu(callback);
        }

        internal async Task Off(string eventType)
        {
            await this.MapEvented.Off(eventType);
        }
    }
}
