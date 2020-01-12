using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Checklist.DataLogic.Repository.Dapper
{
    public class SqlQueries : ISqlQueries
    {
        public string this[string key]
        {
            get
            {
                return Values[key.ToLower()];
            }

        }

        public Dictionary<string, string> Values { get; private set; }


        public SqlQueries()
        {
            Values = new Dictionary<string, string>();

            var directories = Directory.GetDirectories("./../Checklist.DataLogic/Sql");

            foreach (var dir in directories)
            {
                var directoryName = dir.Replace("\\", "/").Split("/").Last();
                var files = Directory.GetFiles($"{dir}");
                foreach (var file in files)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var key = $"{directoryName}.{fileName}".ToLower();
                    Values[key] = File.ReadAllText($"{file}");
                }

            }
        }
    }
}
