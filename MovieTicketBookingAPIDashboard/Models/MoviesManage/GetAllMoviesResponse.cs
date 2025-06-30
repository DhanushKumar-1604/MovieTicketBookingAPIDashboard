using APIDashboard.Domain;
using APIDashboard.Domain.Dto_Model;

namespace MovieTicketBookingAPIDashboard.Models.MoviesManage
{
    public class GetAllMoviesResponse
    {
        public GetAllMoviesList? MoviesList { get; set; }
        public ActionResponse? ActionResponse { get; set; }
    }

    public class GetAllMoviesList()
    {
        public List<GetMoviesModelDto>? getAllMovies { get; set; }
    }
}
