using DPBlazorMapLibrary.JsInterops.Events;
using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    public class Marker : InteractiveLayer
    {
        private const string GetLatLngJsFunction = "getLatLng";
        private const string SetLatLngJsFunction = "setLatLng";
        private const string SetZIndexOffsetJsFunction = "setZIndexOffset";
        private const string GetIconJsFunction = "getIcon";
        private const string SetIconJsFunction = "setIcon";
        private const string SetOpacityJsFunction = "setOpacity";

        public Marker(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
        {
            JsReference = jsReference;
            EventedJsInterop = eventedJsInterop;
        }

        public async Task<LatLng> GetLatLng()
        {
            return await JsReference.InvokeAsync<LatLng>(GetLatLngJsFunction);
        }

        public async Task<IJSObjectReference> SetLatLng(LatLng latLng)
        {
            return await JsReference.InvokeAsync<IJSObjectReference>(SetLatLngJsFunction, latLng);
        }

        public async Task<IJSObjectReference> SetZIndexOffset(int number)
        {
            return await JsReference.InvokeAsync<IJSObjectReference>(SetZIndexOffsetJsFunction, number);
        }

        public async Task<Icon> GetIcon()
        {
            return await JsReference.InvokeAsync<Icon>(GetIconJsFunction);
        }

        public async Task<IJSObjectReference> SetIcon(Icon icon)
        {
            return await JsReference.InvokeAsync<IJSObjectReference>(SetIconJsFunction, icon);
        }

        public async Task<IJSObjectReference> SetOpacity(double number)
        {
            return await JsReference.InvokeAsync<IJSObjectReference>(SetOpacityJsFunction, number);
        }
    }
}
