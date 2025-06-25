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

namespace APIDashboard.Infrastructure.Repository.MoviesManage.Implementations
{
    public class MoviesManageCommand : IMoviesManageCommand
    {
        private readonly IDapperHelper _dapperHelper;
        public MoviesManageCommand(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<int> AddMovies(MoviesModel moviesModel)
        {
            try
            {
                string procedureName = "MovieTicketBooking.AddMovies";
                var parameter = new DynamicParameters();
                parameter.Add("Title", moviesModel.Title, DbType.String, ParameterDirection.Input);
                parameter.Add("Genre", moviesModel.Genre, DbType.String, ParameterDirection.Input);
                parameter.Add("DurationMinutes", moviesModel.DurationMinutes, DbType.Int32, ParameterDirection.Input);
                parameter.Add("ReleaseDate", moviesModel.ReleaseDate, DbType.Date, ParameterDirection.Input);

                var result = await _dapperHelper.ExecuteAsync(procedureName, parameter);

                return result;

            }
            catch
            {
                return 0;
            }
        }
    }
}
