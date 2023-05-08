using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Models
{
    public class AppSettings
    {
        public DatabaseConnection DatabaseConnection { get; set; }
    }
    public class DatabaseConnection
    {
        public string ConnectionString { get; set; }
    }
}
