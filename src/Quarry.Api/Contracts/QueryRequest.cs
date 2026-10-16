using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quarry.Core.Models;

namespace Quarry.Api.Contracts
{
    public sealed record QueryRequest(DatabaseKind Kind, string ConnectionString, string Sql);

   
}