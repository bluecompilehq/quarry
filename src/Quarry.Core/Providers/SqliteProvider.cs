using System.Data.Common;
using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Quarry.Core.Models;

namespace Quarry.Core.Providers
{
    public class SqliteProvider : AdoNetProvider
    {
      protected override DbConnection CreateConnection(string connectionString) => new SqliteConnection(connectionString);
    }
}