using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDashboard.Application.Interfaces;
using APIDashboard.Domain;
using APIDashboard.Infrastructure.Repository.MoviesManage.Interfaces;

namespace APIDashboard.Application.Services
{
    public class MoviesManageService : IMoviesManageService
    {
        private readonly IMoviesManageQuery _moviesManageQuery;
        private readonly IMoviesManageCommand _moviesManageCommand;
        public MoviesManageService(IMoviesManageQuery moviesManageQuery,IMoviesManageCommand moviesManageCommand) 
        {
            _moviesManageQuery = moviesManageQuery;
            _moviesManageCommand = moviesManageCommand;
        }

        public async Task<int> AddMovies(MoviesModel moviesModel)
        {
            try
            {
                return await _moviesManageCommand.AddMovies(moviesModel);
            }
            catch
            {
                return 0;
            }
        }
        public async Task<List<MoviesModel>?> GetAllMoviesList()
        {
            try 
            {
                return await _moviesManageQuery.GetAllMovies();
            }
            catch 
            {
                return null;
            }
        }

        public async Task<IEnumerable<MoviesModel>?> GetMovieById(int movieId)
        {
            try
            {
                return await _moviesManageQuery.GetMovieById(movieId);

            }
            catch
            {
                return null;
            }
        } 
    }
}
