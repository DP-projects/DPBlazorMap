using DPBlazorMapLibrary.JsInterops.Events;
using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    /// <summary>
    /// A class for drawing circle overlays on a map. Extends CircleMarker.
    /// </summary>
    internal class Circle : CircleMarker
    {
        internal Circle(IJSObjectReference jsReference, IEventedJsInterop eventedJsInterop)
            : base(jsReference, eventedJsInterop)
        {
        }
    }
}
