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
    //"transaction service" or "financial service"
    public class PaymentService : IPaymentService
    {
        private readonly AppSettings _appSettings;
        //private readonly IProcessor _processor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentService> _logger;
        private readonly string _fullClassName;

        public PaymentService(IOptions<AppSettings> options, /*IProcessor processor,*/ IUnitOfWork unitOfWork, ILogger<PaymentService> logger)
        {
            _appSettings = options.Value;
            //_processor = processor;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _fullClassName = $"{this.GetType().Namespace}.{this.GetType().Name}";
        }
    }
}
