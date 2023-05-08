using Microsoft.Extensions.Options;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.Models;
using MongoMission.Core.RepositorIes.Interfaces;
using MongoMission.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.RepositorIes
{
    // ReceiptRepository class
    public class ReceiptRepository : MongoRepository<Receipt>, IReceiptRepository
    {
        private readonly AppSettings _appSettings;
        public ReceiptRepository(IOptions<AppSettings> options) : base(options, AppConstants.ReceiptCollectionName) { }
    }
}
