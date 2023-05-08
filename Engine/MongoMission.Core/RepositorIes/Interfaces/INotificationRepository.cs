﻿using MongoMission.Core.Models.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.RepositorIes.Interfaces
{
    // INotificationRepository interface
    public interface INotificationRepository : IMongoRepository<Notification>
    {
    }
}
