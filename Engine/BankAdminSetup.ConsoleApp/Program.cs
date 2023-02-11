using System;
using System.Runtime.CompilerServices;
using BankAdminSetup.ConsoleApp.GTBank.Helper;
using BankAdminSetup.ConsoleApp.ZenithBank.Helper;
namespace BankAdminSetup.ConsoleApp
{
    public  class Program
    {
        public static void Main(string[] args)
        {
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
            UnionBank.Helper.UnionBankHelper.CreateBranchInsert();
            Console.ReadLine();
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
