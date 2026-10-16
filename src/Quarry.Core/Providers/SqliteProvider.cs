using System.Diagnostics;
using Microsoft.Data.Sqlite;
using Quarry.Core.Models;

namespace Quarry.Core.Providers
{
    public class SqliteProvider : IDatabaseProvider
    {
        public async Task<QueryResult> ExecuteAsync(string connectionString, string sql, CancellationToken ct = default)
        {
            var stopwatch = Stopwatch.StartNew();

            await using var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync(ct);

            await using var command = connection.CreateCommand();
            command.CommandText = sql;

            await using var reader = await command.ExecuteReaderAsync(ct);

            var columns = new List<ColumnInfo>();

            for (var i = 0; i<reader.FieldCount; i++)
            {
                columns.Add(new ColumnInfo(reader.GetName(i),reader.GetDataTypeName(i)));
            }

            var row = new List<Object?[]>();

            while(await reader.ReadAsync(ct))
            {
                var values = new object[reader.FieldCount];
                reader.GetValues(values);
                row.Add(values.Select(v=>v is DBNull ? null: v).ToArray());
            }
            stopwatch.Stop();
            return new QueryResult(columns ,row ,stopwatch.ElapsedMilliseconds);
        }
    }
}