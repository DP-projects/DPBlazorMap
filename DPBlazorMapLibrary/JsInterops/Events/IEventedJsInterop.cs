using Microsoft.JSInterop;

namespace DPBlazorMapLibrary.JsInterops.Events
{
    internal interface IEventedJsInterop
    {
        ValueTask OnCallback(DotNetObjectReference<Evented> eventedClass, IJSObjectReference eventedReference, string eventType);
    }
}
