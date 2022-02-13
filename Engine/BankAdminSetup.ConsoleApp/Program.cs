using System;
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
            ZenithHelper.CreateUserInsert();
            Console.ReadLine();
        }
    }
}
