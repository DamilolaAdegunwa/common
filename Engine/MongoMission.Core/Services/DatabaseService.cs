using MongoMission.Core.Repositories.Interfaces;
using MongoMission.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Services
{
    //table-specific methods
    public class DatabaseService: IDatabaseService
    {
        public IUnitOfWork UnitOfWork { get; }
        public DatabaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
