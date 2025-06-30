using APIDashboard.Domain.Dto_Model;

namespace MovieTicketBookingAPIDashboard.Models.MoviesManage
{
    public class GetMovieByIdResponse
    {
        public GetMoviesModelDto? MovieDetails { get; set; }
        public ActionResponse? ActionResponse { get; set; }
    }
   
}
