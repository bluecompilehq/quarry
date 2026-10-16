using System.Data.Common;
using System.Diagnostics;
using Quarry.Core.Models;

namespace Quarry.Core.Providers
{
    public  abstract class AdoNetProvider : IDatabaseProvider
    {
        protected abstract DbConnection CreateConnection(string connectionString);
        public async Task<QueryResult> ExecuteAsync(string connectionString, string sql, CancellationToken ct = default)
        {
            var stopwatch = Stopwatch.StartNew();

        await using var connection = CreateConnection(connectionString);
        await connection.OpenAsync(ct);

        await using var command = connection.CreateCommand();
        command.CommandText = sql;

        await using var reader = await command.ExecuteReaderAsync(ct);

        var columns = new List<ColumnInfo>();
        for (var i = 0; i < reader.FieldCount; i++)
        {
            columns.Add(new ColumnInfo(reader.GetName(i), reader.GetDataTypeName(i)));
        }

        var rows = new List<object?[]>();
        while (await reader.ReadAsync(ct))
        {
            var values = new object[reader.FieldCount];
            reader.GetValues(values);
            rows.Add(values.Select(v => v is DBNull ? null : v).ToArray());
        }

        stopwatch.Stop();
        return new QueryResult(columns, rows, stopwatch.ElapsedMilliseconds);
        }
    }
}