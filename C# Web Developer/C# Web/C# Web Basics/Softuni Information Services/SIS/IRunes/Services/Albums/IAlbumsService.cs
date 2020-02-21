namespace IRunes.Services.Albums
{
    using IRunes.ViewModels.Albums;
    using System.Collections.Generic;

    public interface IAlbumsService
    {
        IEnumerable<AlbumInfoViewModel> GetAll();
        void CreateAlbum(string name, string cover);
        AlbumDetailsViewModel GetDetails(string id);
    }
}
