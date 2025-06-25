using APIDashboard.Domain;

namespace MovieTicketBookingAPIDashboard.Models.MoviesManage
{
    public class GetAllMoviesResponse
    {
        public GetAllMoviesList? MoviesList { get; set; }
        public ActionResponse? ActionResponse { get; set; }
    }

    public class GetAllMoviesList()
    {
        public List<MoviesModel>? getAllMovies { get; set; }
    }
}
