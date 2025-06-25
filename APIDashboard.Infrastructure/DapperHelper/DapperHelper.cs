using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APIDashboard.Infrastructure.DapperHelper
{
    public class DapperHelper : IDapperHelper
    {
        private readonly IDbConnection _dbConnection;
        public DapperHelper(IConfiguration configuration)
        {
           _dbConnection = new SqlConnection(configuration.GetConnectionString("DataBaseConnection"));
        }

       public async Task<int> ExecuteAsync(string procedureName, object parameters)
        {
            return await _dbConnection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object? parameters)
        {
            return await _dbConnection.QueryAsync<T>(procedureName,parameters,commandType:CommandType.StoredProcedure);
        }
    }
}
