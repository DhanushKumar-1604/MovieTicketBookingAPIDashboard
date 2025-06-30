using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDashboard.Domain.Dto_Model
{
    public class GetMoviesModelDto
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
