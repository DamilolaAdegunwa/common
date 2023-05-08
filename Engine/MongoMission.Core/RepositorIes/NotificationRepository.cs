using Microsoft.Extensions.Options;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.Models;
using MongoMission.Core.Repositories.Interfaces;
using MongoMission.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Repositories
{
    // NotificationRepository class
    public class NotificationRepository : MongoRepository<Notification>, INotificationRepository
    {
        private readonly AppSettings _appSettings;
        public NotificationRepository(IOptions<AppSettings> options) : base(options, AppConstants.NotificationCollectionName) { }
    }
}
