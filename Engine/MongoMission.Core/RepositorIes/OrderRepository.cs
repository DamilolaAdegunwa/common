﻿using Microsoft.Extensions.Options;
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
    // OrderRepository class
    public class OrderRepository : MongoRepository<Order>, IOrderRepository
    {
        private readonly AppSettings _appSettings;
        public OrderRepository(IOptions<AppSettings> options) : base(options, AppConstants.OrderCollectionName) { }
    }
}
