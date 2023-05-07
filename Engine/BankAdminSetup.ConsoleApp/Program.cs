using System;
using System.Runtime.CompilerServices;
using BankAdminSetup.ConsoleApp.GTBank.Helper;
using BankAdminSetup.ConsoleApp.ZenithBank.Helper;
namespace BankAdminSetup.ConsoleApp
{
    public  class Program
    {
		private void TestMethod()
		{
			Action<Exception> errorHandler = (ex) => {
				// write to a log, whatever...
			};

			try
			{
				// try some stuff
			}
			//catch (FormatException ex) { errorHandler(ex); }
			//catch (OverflowException ex) { errorHandler(ex); }
			//catch (ArgumentNullException ex) { errorHandler(ex); }
			catch(Exception ex) when (ex is Exception)
			{
				errorHandler(ex);
			}
			finally { 
			
			}
		}
		public static void Main(string[] args)
        {
			//NSString* cleanedString = [[phoneNumber componentsSeparatedByCharactersInSet:[[NSCharacterSet characterSetWithCharactersInString: @"0123456789-+()"] invertedSet]] componentsJoinedByString: @""];
			//zenith
			//ZenithHelper.CreateRegionInsert();
			//ZenithHelper.CreateUserRoleInsert();
			//ZenithHelper.CreateBranchInsert();
			//ZenithHelper.CreateUserInsert();
			//ZenithHelper.CreateBranchRegionJson();

			//gtbank
			//GTBankHelper.CreateUserRoleInsert();
			//GTBankHelper.CreateRegionInsert();
			//GTBankHelper.ReadGTBankBranchesExcelFile();
			//GTBankHelper.UploadBTBankBranchesExcel();
			//GTBankHelper.CreateBranchInsert();

			//union bank
			//UnionBank.Helper.UnionBankHelper.CreateRegionInsert();
			//UnionBank.Helper.UnionBankHelper.CreateUserRoleInsert();
			//UnionBank.Helper.UnionBankHelper.CreateBranchInsert();

			var s = TrimStringToCertainCharacter("   (+234) - 813 - 136 - 3116😂🚀🧹💯      ");
			Console.WriteLine(s);
        }
		public static string TrimStringToCertainCharacter(string str, string whitelist = "1234567890") 
		{
			foreach(char c in str)
			{
				if(!whitelist.Contains(c))
				{
					str = str.Replace(c.ToString(), "");
				}
			}
			return str;
		}
        public string Sample()
        {
            try
            {
                return "";
            }
			catch (IndexOutOfRangeException ex)
			{

				throw;
			}
			catch (ArgumentNullException ex)
			{

				throw;
			}
			catch (Exception ex)
            {

                throw;
            }

		}
    }
}
