using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDashboard.Domain;

namespace APIDashboard.Infrastructure.Repository.MoviesManage.Interfaces
{
    public interface IMoviesManageCommand
    {
        Task<int> AddMovies(MoviesModel moviesModel);
    }
}
