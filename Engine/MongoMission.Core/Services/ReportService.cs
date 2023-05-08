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
    public class ReportService : IReportService
    {
        private readonly AppSettings _appSettings;
        //private readonly IProcessor _processor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReportService> _logger;
        private readonly string _fullClassName;

        public ReportService(IOptions<AppSettings> options, /*IProcessor processor,*/ IUnitOfWork unitOfWork, ILogger<ReportService> logger)
        {
            _appSettings = options.Value;
            //_processor = processor;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fullClassName = $"{this.GetType().Namespace}.{this.GetType().Name}";
        }
    }
}
