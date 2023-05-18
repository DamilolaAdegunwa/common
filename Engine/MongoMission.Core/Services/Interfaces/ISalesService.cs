using MongoMission.Core.Models.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Services.Interfaces
{
    public interface ISalesService
    {
        List<Product> GetProducts(
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
			);
        bool SaveProduct(Product product,
		[CallerMemberName] string memberName = "",
		[CallerFilePath] string filePath = "",
		[CallerLineNumber] int lineNumber = 0
			);
    }
}
