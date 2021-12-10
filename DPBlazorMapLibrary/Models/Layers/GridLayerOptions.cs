using System.Drawing;

namespace DPBlazorMapLibrary
{
    public class GridLayerOptions : LayerOptions
    {
        public GridLayerOptions()
        {
            Pane = "tilePane";

        }
        /// <summary>
        /// Width and height of tiles in the grid. Use a number if width and height are equal, or L.point(width, height) otherwise.
        /// </summary>
        public Size TileSize { get; set; } = new Size(256, 256);

        /// <summary>
        /// Opacity of the tiles. Can be used in the createTile() function.
        /// </summary>
        public double Opacity { get; set; } = 1.0;

        /// <summary>
        /// By default, a smooth zoom animation (during a touch zoom or a flyTo()) will update grid layers every integer zoom level. 
        /// Setting this option to false will update the grid layer only when the smooth animation ends.
        /// </summary>
        public bool UpdateWhenZooming { get; set; } = true;

        /// <summary>
        /// Tiles will not update more than once every updateInterval milliseconds when panning.
        /// </summary>
        public int UpdateInterval { get; set; } = 200;

        /// <summary>
        /// The explicit zIndex of the tile layer.
        /// </summary>
        public int ZIndex { get; set; } = 1;

        /// <summary>
        /// If set, tiles will only be loaded inside the set.
        /// </summary>
        public LatLngBounds Bounds { get; set; }

        public int MinZoom { get; set; } = 0;
        public int? MaxZoom { get; set; } = null;
        public int? MaxNativeZoom { get; set; } = null;
        public int? MinNativeZoom { get; set; } = null;
        public bool NoWrap { get; set; } = false;
        public int KeepBuffer { get; set; } = 2;

    }
}
