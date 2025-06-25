using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDashboard.Domain
{
    public class MoviesModel
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
