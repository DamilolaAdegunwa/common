using Microsoft.Extensions.Options;
using MongoMission.Core.Models;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.Repositories.Interfaces;
using MongoMission.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Repositories
{
    // TransactionRepository class
    public class TransactionRepository : MongoRepository<Transaction>, ITransactionRepository
    {
        private readonly AppSettings _appSettings;
        public TransactionRepository(IOptions<AppSettings> options) : base(options, AppConstants.TransactionCollectionName) { }
    }
}
