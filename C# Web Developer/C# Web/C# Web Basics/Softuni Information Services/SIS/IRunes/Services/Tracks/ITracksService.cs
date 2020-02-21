namespace IRunes.Services.Tracks
{
    using IRunes.ViewModels.Tracks;

    public interface ITracksService
    {
        void CreateTrack(string albumId, string name, string link, decimal price);
        DetailsViewModel GetDetails(string trackId);
    }
}
