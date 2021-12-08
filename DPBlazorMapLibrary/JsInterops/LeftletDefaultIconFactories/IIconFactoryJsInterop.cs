using Microsoft.JSInterop;

namespace DPBlazorMapLibrary.JsInterops.LeftletDefaultIconFactories
{
    internal interface IIconFactoryJsInterop
    {
        ValueTask<IJSObjectReference> CreateDefaultIcon();
    }
}
