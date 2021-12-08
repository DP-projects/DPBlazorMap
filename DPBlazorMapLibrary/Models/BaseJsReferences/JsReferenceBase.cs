using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    /// <summary>
    /// Base class for a reference to a js object
    /// </summary>
    internal class JsReferenceBase
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Js References
        /// </summary>
        internal IJSObjectReference JsReference;
        #pragma warning restore CS8618 
    }
}
