namespace DPBlazorMapLibrary
{
    public class TileLayerOptions : GridLayerOptions
    {
        /// <summary>
        /// The minimum zoom level down to which this layer will be displayed (inclusive).
        /// </summary>
        public int MinZoom { get; set; } = 0;

        /// <summary>
        /// The maximum zoom level up to which this layer will be displayed (inclusive).
        /// </summary>
        public int MaxZoom { get; set; } = 18;

        /// <summary>
        /// Subdomains of the tile service. Can be passed in the form of one string (where each letter is a subdomain name) or an array of strings.
        /// </summary>
        public string[] Subdomains { get; set; } = { "abc" };

        /// <summary>
        /// URL to the tile image to show in place of the tile that failed to load.
        /// </summary>
        public string ErrorTileUrl { get; set; } = null;

        /// <summary>
        /// The zoom number used in tile URLs will be offset with this value.
        /// </summary>
        public int ZoomOffset { get; set; } = 0;

        /// <summary>
        /// If true, inverses Y axis numbering for tiles (turn this on for TMS services).
        /// </summary>
        public bool Tms { get; set; } = false;

        /// <summary>
        /// If set to true, the zoom number used in tile URLs will be reversed (maxZoom - zoom instead of zoom)
        /// </summary>
        public bool ZoomReverse { get; set; } = false;

        /// <summary>
        /// If true and user is on a retina display, it will request four tiles of half the specified size and a bigger zoom level in place of one to utilize the high resolution.
        /// </summary>
        public bool DetectRetina { get; set; } = false;
    }
}
