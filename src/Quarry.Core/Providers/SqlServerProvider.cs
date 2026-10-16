using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace Quarry.Core.Providers
{
    public class SqlServerProvider :AdoNetProvider
    {
         protected override DbConnection CreateConnection(string connectionString)
        => new SqlConnection(connectionString);
    }
}