using System;
using BankAdminSetup.ConsoleApp.GTBank.Helper;
using BankAdminSetup.ConsoleApp.ZenithBank.Helper;
namespace BankAdminSetup.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ZenithHelper.CreateRegionInsert();
            //ZenithHelper.CreateUserRoleInsert();
            //ZenithHelper.CreateBranchInsert();
            //ZenithHelper.CreateUserInsert();

            //gtbank
            //GTBankHelper.CreateUserRoleInsert();
            GTBankHelper.CreateRegionInsert();
            Console.ReadLine();
        }
    }
}
