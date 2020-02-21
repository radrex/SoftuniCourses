namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using IRunes.Services.Albums;
    using IRunes.ViewModels.Albums;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        //-------------------- ALL --------------------
        // /Albums/All
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            AllAlbumsViewModel viewModel = new AllAlbumsViewModel
            {
                Albums = this.albumsService.GetAll(),
            };

            return this.View(viewModel);
        }

        //------------------- CREATE ------------------
        // /Albums/Create
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (inputModel.Name.Length < 4 || inputModel.Name.Length > 20)
            {
                return this.Error("Name should be with length between 4 and 20");
                //return this.View();
            }

            if (string.IsNullOrWhiteSpace(inputModel.Cover))
            {
                return this.Error("Cover is required.");
                //return this.View();
            }

            this.albumsService.CreateAlbum(inputModel.Name, inputModel.Cover);
            return this.Redirect("/Albums/All");
        }

        //------------------- DETAILS -----------------
        // /Albums/Details?id={albumId}
        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            AlbumDetailsViewModel viewModel = this.albumsService.GetDetails(id);

            return this.View(viewModel);
        }
    }
}
