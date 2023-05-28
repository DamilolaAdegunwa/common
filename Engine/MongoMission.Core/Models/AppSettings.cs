using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Models
{
	[System.Diagnostics.DebuggerDisplay("mostly DatabaseConnection")]
	public class AppSettings
    {
        public DatabaseConnection DatabaseConnection { get; set; }
    }
    public class DatabaseConnection
    {
        public string ConnectionString { get; set; }
    }
}
