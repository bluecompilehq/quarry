using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quarry.Core.Models;

namespace Quarry.Core.Providers
{
    public interface IDatabaseProvider
    {
        Task<QueryResult> ExecuteAsync(string connectionString , string sql  , CancellationToken ct = default);
    }
}