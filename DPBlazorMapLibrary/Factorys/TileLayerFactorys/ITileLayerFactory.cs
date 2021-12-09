namespace DPBlazorMapLibrary
{
    public interface ITileLayerFactory
    {
        public Task<TileLayer> Create(string urlTemplate, TileLayerOptions? options);
        public Task<TileLayer> CreateAndAddToMap(string urlTemplate, Map map, TileLayerOptions? options);
    }
}
