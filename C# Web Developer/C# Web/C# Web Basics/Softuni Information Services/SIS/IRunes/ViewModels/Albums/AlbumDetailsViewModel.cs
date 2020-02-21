namespace IRunes.ViewModels.Albums
{
    using System.Collections.Generic;

    public class AlbumDetailsViewModel
    {
        public string Cover { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Id { get; set; }
        public IEnumerable<TrackInfoViewModel> Tracks { get; set; }
    }
}
