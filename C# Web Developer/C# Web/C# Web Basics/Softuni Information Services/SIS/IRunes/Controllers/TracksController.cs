namespace IRunes.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using IRunes.Services.Tracks;
    using IRunes.ViewModels.Tracks;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        //-------------------- CREATE --------------------
        // /Tracks/Create?albumId={albumId}
        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            AlbumIdViewModel viewModel = new AlbumIdViewModel { AlbumId = albumId };
            return this.View(viewModel);
        }

        // /Tracks/Create?albumId={albumId}
        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (inputModel.Name.Length < 4 || inputModel.Name.Length > 20)
            {
                return this.Error("Track name should be between 4 and 20 characters.");
                //return this.View();
            }

            if (!inputModel.Link.StartsWith("http"))
            {
                return this.Error("Invalid link.");
                //return this.View();
            }

            if (inputModel.Price < 0.0M || inputModel.Price > decimal.MaxValue)
            {
                return this.Error("Price should be a positive number.");
                //return this.View();
            }

            this.tracksService.CreateTrack(inputModel.AlbumId, inputModel.Name, inputModel.Link, inputModel.Price);
            return this.Redirect($"/Albums/Details?id={inputModel.AlbumId}");
        }

        //-------------------- DETAILS -------------------
        // /Tracks/Details?albumId={albumId}&trackId={trackId}
        public HttpResponse Details(string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            DetailsViewModel viewModel = this.tracksService.GetDetails(trackId);
            if (viewModel == null)
            {
                return this.Error("Track not found.");
            }

            return this.View(viewModel);
        }
    }
}
