using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoMission.Core.Models;
using MongoMission.Core.Repositories.Interfaces;
using MongoMission.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppSettings _appSettings;
        private readonly IProcessor _processor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<InventoryService> _logger;
        private readonly string _fullClassName;

        public InventoryService(IOptions<AppSettings> options, IProcessor processor, IUnitOfWork unitOfWork, ILogger<InventoryService> logger)
        {
            _appSettings = options.Value;
            _processor = processor;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fullClassName = $"{this.GetType().Namespace}.{this.GetType().Name}";
        }
    }
}
