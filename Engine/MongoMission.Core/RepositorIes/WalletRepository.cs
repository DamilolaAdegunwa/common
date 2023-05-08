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
    // WalletRepository class
    public class WalletRepository : MongoRepository<Wallet>, IWalletRepository
    {
        private readonly AppSettings _appSettings;
        public WalletRepository(IOptions<AppSettings> options) : base(options, AppConstants.WalletCollectionName) { }
    }
}
