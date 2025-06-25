using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDashboard.Domain;
using APIDashboard.Infrastructure.DapperHelper;
using APIDashboard.Infrastructure.Repository.MoviesManage.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APIDashboard.Infrastructure.Repository.MoviesManage.Implementations
{
    public class MoviesManageQuery : IMoviesManageQuery
    {
        private readonly IDapperHelper _dapperHelper;
        public MoviesManageQuery(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }


       
        public async Task<List<MoviesModel>?> GetAllMovies()
        {
            try
            {
                string procedureName = "MovieTicketBooking.GetAllMoviesList";
                var result = await _dapperHelper.QueryAsync<MoviesModel>(procedureName);

                return result.ToList();
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
                string procedurName = "MovieTicketBooking.GetMovieById";
                var result = await _dapperHelper.QueryAsync<MoviesModel>(procedurName,new {@MovieId=movieId});
                return result.ToList(); 
            }
            catch
            {
                return null;
            }
        }

    }
}
