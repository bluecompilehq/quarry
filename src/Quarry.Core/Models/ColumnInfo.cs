using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quarry.Core.Models
{
    public sealed record ColumnInfo(string name ,string DataType );

    public sealed record QueryResult(
        IReadOnlyList<ColumnInfo> Columns,
        IReadOnlyList<Object?[]> Rows,long ElapsedMs);
    
   
}