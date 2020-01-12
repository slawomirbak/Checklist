using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Repository.Dapper
{
    public interface ISqlQueries
    {
        Dictionary<string, string> Values { get; }
        string this[string key] { get; }
    }
}
