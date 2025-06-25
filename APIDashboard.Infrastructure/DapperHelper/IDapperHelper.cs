using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDashboard.Infrastructure.DapperHelper
{
    public interface IDapperHelper
    {
        Task<int> ExecuteAsync(string procedureName, object parameters);
        Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object? parameters = null);
    }
}
