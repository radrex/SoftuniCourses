using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Albums;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services.Albums
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AlbumInfoViewModel> GetAll()
        {
            return this.db.Albums.Select(x => new AlbumInfoViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToArray();
        }

        public void CreateAlbum(string name, string cover)
        {
            Album album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0M,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public AlbumDetailsViewModel GetDetails(string id)
        {
            AlbumDetailsViewModel album =  this.db.Albums.Where(x => x.Id == id)
                                                         .Select(x => new AlbumDetailsViewModel
                                                         {
                                                             Cover = x.Cover,
                                                             Name = x.Name,
                                                             Price = x.Price,
                                                             Id = x.Id,
                                                             Tracks = x.Tracks.Select(t => new TrackInfoViewModel
                                                             {
                                                                 Id = t.Id,
                                                                 Name = t.Name,
                                                             })
                                                         }).FirstOrDefault();
            return album;
        }
    }
}
