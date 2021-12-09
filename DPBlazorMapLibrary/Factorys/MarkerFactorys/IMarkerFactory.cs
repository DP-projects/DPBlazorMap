namespace DPBlazorMapLibrary
{
    public interface IMarkerFactory
    {
        public Task<Marker> Create(LatLng latLng, MarkerOptions? options);
        public Task<Marker> CreateAndAddToMap(LatLng latLng, Map map, MarkerOptions? options);
    }
}
