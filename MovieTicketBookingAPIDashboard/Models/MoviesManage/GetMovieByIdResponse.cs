namespace MovieTicketBookingAPIDashboard.Models.MoviesManage
{
    public class GetMovieByIdResponse
    {
        public GetMovieByIdModel? MovieDetails { get; set; }
        public ActionResponse? ActionResponse { get; set; }
    }
    public class GetMovieByIdModel 
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
