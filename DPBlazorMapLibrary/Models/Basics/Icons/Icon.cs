using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    internal class Icon : JsReferenceBase
    {
        internal Icon(IJSObjectReference jsReference)
        {
            JsReference = jsReference;
        }
    }
}
