using Microsoft.JSInterop;

namespace DPBlazorMapLibrary
{
    public class TileLayerFactory : ITileLayerFactory
    {
        private const string create = "L.tileLayer";
        private readonly IJSRuntime jsRuntime;
        public TileLayerFactory(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;

        }
        public async Task<TileLayer> Create(string urlTemplate, TileLayerOptions? options)
        {
            IJSObjectReference jsReference = await jsRuntime.InvokeAsync<IJSObjectReference>(create, urlTemplate, options);
            return new TileLayer(jsReference);
        }

        public async Task<TileLayer> CreateAndAddToMap(string urlTemplate, Map map, TileLayerOptions? options)
        {
            TileLayer tileLayer = await Create(urlTemplate, options);
            await tileLayer.AddTo(map);
            return tileLayer;
        }
    }
}
