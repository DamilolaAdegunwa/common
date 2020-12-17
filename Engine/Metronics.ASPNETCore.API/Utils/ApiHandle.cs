using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Utils
{
    public class ApiHandle
    {
        protected async Task<ServiceResponse<T>> HandleApiOperationAsync<T>(Func<Task<ServiceResponse<T>>> action)
        {
            var serviceResponse = new ServiceResponse<T>();
            var actionResponse = await action();

            serviceResponse.Object = actionResponse.Object;
            serviceResponse.ShortDescription = actionResponse.ShortDescription;
            serviceResponse.Code = actionResponse.Code;
            return serviceResponse;
        }
    }
}
