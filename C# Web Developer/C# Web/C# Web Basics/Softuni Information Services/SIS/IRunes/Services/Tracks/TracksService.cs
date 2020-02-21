namespace IRunes.Services.Tracks
{
    using IRunes.Data;
    using IRunes.Models;
    using IRunes.ViewModels.Tracks;

    using System.Linq;

    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrack(string albumId, string name, string link, decimal price)
        {
            Track track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = price,
            };

            this.db.Tracks.Add(track);

            decimal totalSum = this.db.Tracks.Where(x => x.AlbumId == albumId).Sum(x => x.Price) + price;
            Album album = this.db.Albums.Find(albumId);
            album.Price = totalSum * 0.87M;

            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetails(string trackId)
        {
           return this.db.Tracks.Where(x => x.Id == trackId)
                                .Select(x => new DetailsViewModel
                                {
                                    AlbumId = x.AlbumId,
                                    Name = x.Name,
                                    Price = x.Price,
                                    Link = x.Link,
                                }).FirstOrDefault();
        }
    }
}
