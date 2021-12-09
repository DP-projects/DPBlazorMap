using DPBlazorMapLibrary.JsInterops.Events;
using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    public class MarkerFactory : IMarkerFactory
    {
        private const string _createJsFunction = "L.marker";
        private readonly IJSRuntime jsRuntime;
        private readonly IEventedJsInterop eventedJsInterop;
        public MarkerFactory(
            IJSRuntime jsRuntime,
            IEventedJsInterop eventedJsInterop)
        {
            this.jsRuntime = jsRuntime;
            this.eventedJsInterop = eventedJsInterop;
        }
        public async Task<Marker> Create(LatLng latLng, MarkerOptions? options)
        {
            IJSObjectReference jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(_createJsFunction, latLng, options);
            return new Marker(jsReference, eventedJsInterop);
        }

        public async Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions? options)
        {
            Marker marker = await Create(latLng, options);
            await marker.AddTo(map);
            return marker;
        }
    }
}
