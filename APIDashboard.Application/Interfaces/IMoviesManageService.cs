using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDashboard.Domain;

namespace APIDashboard.Application.Interfaces
{
    public interface IMoviesManageService
    {
        Task<int> AddMovies(MoviesModel moviesModel);
        Task<List<MoviesModel>?> GetAllMoviesList();
        Task<IEnumerable<MoviesModel>?> GetMovieById(int movieId);
    }
}
