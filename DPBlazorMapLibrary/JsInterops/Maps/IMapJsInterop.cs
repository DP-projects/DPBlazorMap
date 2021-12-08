using DPBlazorMapLibrary.JsInterops.Base;
using Microsoft.JSInterop;

namespace DPBlazorMapLibrary.JsInterops.Maps
{
    internal interface IMapJsInterop : IBaseJsInterop
    {
        ValueTask<IJSObjectReference> Initialize(MapOptions mapOptions);
    }
}
