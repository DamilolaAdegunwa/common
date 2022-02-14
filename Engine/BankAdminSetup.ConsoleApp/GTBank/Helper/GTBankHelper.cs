﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace BankAdminSetup.ConsoleApp.GTBank.Helper
{
    public class GTBankHelper
    {
        public static string CreateUserRoleInsert()
        {
            var ur = @"User access
FEP Support
BRAAM
Card Risk
Ebiz-Settlement
Naira Card Solutions";
            var urArr = ur.Split('\n')?.Distinct()?.ToArray();
            var userRoleTemp = "INSERT [ZoneAdminPortal].[dbo].[UserRoles] ([Name], [Code], [Description], [UserCategory], [Scope], [Status]) VALUES (N'{{Name}}', N'{{Code}}', N'{{Description}}', 0, 3, 2);\n\n";
            var userRoleInsertString = "";
            foreach (var r in urArr)
            {
                var temp = userRoleTemp;

                var rr = r?.Trim('\r')?.Trim()?.Replace("'", "''");

                temp = temp.Replace("{{Name}}", rr);
                temp = temp.Replace("{{Code}}", null);
                temp = temp.Replace("{{Description}}", rr);

                userRoleInsertString += temp;

            }
            Console.WriteLine(userRoleInsertString);
            return userRoleInsertString;
        }

        public static string CreateRegionInsert()
        {
            var states = @"ABIA
ABIA
ABIA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ABUJA
ADAMAWA
ADAMAWA
ADAMAWA
AKWA-IBOM
AKWA-IBOM
ANAMBRA
ANAMBRA
ANAMBRA
ANAMBRA
ANAMBRA
ANAMBRA
BAUCHI
BAUCHI
BAYELSA
BENUE
BORNO
BORNO
BORNO
CROSS RIVER
CROSS RIVER
CROSS RIVER
DELTA
DELTA
DELTA
DELTA
DELTA
DELTA
EBONYI
EDO
EDO
EDO
EDO
EDO
EDO
EDO
EDO
EKITI
EKITI
ENUGU
ENUGU
ENUGU
GOMBE
IMO
IMO
IMO
IMO
JIGAWA
KADUNA
KADUNA
KADUNA
KADUNA
KADUNA
KADUNA
KADUNA
KANO
KANO
KANO
KANO
KANO
KANO
KANO
KATSINA
KEBBI
KOGI
KOGI
KOGI
KWARA
KWARA
KWARA
KWARA
KWARA
KWARA
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
LAGOS
NASARAWA
NASARAWA
NASARAWA
NIGER
NIGER
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
OGUN
ONDO
ONDO
ONDO
OSUN
OSUN
OSUN
OSUN
OSUN
OYO
OYO
OYO
OYO
OYO
OYO
OYO
OYO
PLATEAU
PLATEAU
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
RIVERS
SOKOTO
SOKOTO
SOKOTO
TARABA
TARABA
YOBE
ZAMFARA"; // i assume the state to be the region

            var stateArr = states.Split('\n')?.Distinct()?.Select(s => s?.Trim('\r')?.Trim()?.Replace("'", "''"))?.ToArray();
            var regionInsertStr = "";
            var insertTemp = "INSERT INTO [ZoneAdminPortal].[dbo].[Region] ([Code],[Name],[Description],[Status],[MFB_Code]) VALUES ( '{{code}}','{{name}}','{{description}}' ,2 ,NULL);\n\n";
            foreach (var region in stateArr)
            {
                var reg = region?.Trim('\r')?.Trim()?.Replace("'", "''");
                var temp = insertTemp;
                temp = temp.Replace("{{code}}", null);
                temp = temp.Replace("{{name}}", reg);
                temp = temp.Replace("{{description}}", reg);

                regionInsertStr += temp;
            }
            Console.WriteLine(regionInsertStr);
            return regionInsertStr;

            // 
        }

        public static string CreateBranchInsert()
        {
            var branchesString = @"";
            var correspondingZones = @"";

            //convert both to array
            var branchesArr = branchesString.Split('\n');
            var correspondingZonesArr = correspondingZones.Split('\n');

            //template for creating the branch sql
            var branchsqlTemplate = "INSERT INTO [ZoneAdminPortal].[dbo].[Branch] ([Address],[Code],[Name],[BranchCode],[RegionID],[Status],[MFB_Code],[IsHeadOffice],[CPCHubID],[PilotStatus]) VALUES ( '{{address}}','{{code}}','{{branchname}}','{{branchcode}}', (select top(1) ID FROM [ZoneAdminPortal].[dbo].[Region] where Name = '{{regionname}}') ,2 ,NULL ,0, NULL ,0);\n\n";

            if (branchesArr.Length != correspondingZonesArr.Length)
            {
                throw new Exception();
            }

            var branchSqlString = "";

            //for each branch, find the corresponding region using the index number.
            for (int i = 0; i < branchesArr.Length; i++)
            {
                try
                {
                    var temp = branchsqlTemplate;
                    var branchRow = branchesArr[i]?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var correspondingZonesRow = correspondingZonesArr[i]?.Trim('\r')?.Trim();

                    temp = temp.Replace("{{address}}", null);
                    temp = temp.Replace("{{code}}", null);
                    temp = temp.Replace("{{branchname}}", branchRow);
                    temp = temp.Replace("{{branchcode}}", null);
                    temp = temp.Replace("{{regionname}}", correspondingZonesRow);

                    branchSqlString += temp;
                }
                catch (Exception ex)
                {

                }
            }

            Console.WriteLine(branchSqlString);

            return branchSqlString;
        }
        public static void ReadExcelFile(string filePath = @"C:\temp\GTBank Branches.xlsx")
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nReading the Excel File...");
            Console.BackgroundColor = ConsoleColor.Black;

            Application xlApp = new Application();
            Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;

            string firstValue, secondValue;

            for (int rowCount = 1; rowCount <= totalRows; rowCount++)
            {
                GTBankBranches gTBankBranches = new GTBankBranches
                {
                    SN = Convert.ToString((xlRange.Cells[rowCount, 1] as Microsoft.Office.Interop.Excel.Range).Text),
                    BranchCode = Convert.ToString((xlRange.Cells[rowCount, 2] as Microsoft.Office.Interop.Excel.Range).Text),
                    BranchName = Convert.ToString((xlRange.Cells[rowCount, 3] as Microsoft.Office.Interop.Excel.Range).Text),
                    Address = Convert.ToString((xlRange.Cells[rowCount, 4] as Microsoft.Office.Interop.Excel.Range).Text),
                    CityNameBankCode = Convert.ToString((xlRange.Cells[rowCount, 5] as Microsoft.Office.Interop.Excel.Range).Text),
                    State = Convert.ToString((xlRange.Cells[rowCount, 6] as Microsoft.Office.Interop.Excel.Range).Text),

                };

                //firstValue = Convert.ToString((xlRange.Cells[rowCount, 1] as Microsoft.Office.Interop.Excel.Range).Text);
                //secondValue = Convert.ToString((xlRange.Cells[rowCount, 2] as Microsoft.Office.Interop.Excel.Range).Text);

                //Console.WriteLine(firstValue + "\t" + secondValue);

            }

            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            Console.WriteLine("End of the file...");
        }

        public class GTBankBranches
        {
            public string SN { get; set; }//number
            public string BranchCode { get; set; }
            public string BranchName { get; set; }
            public string Address { get; set; }
            public string CityNameBankCode { get; set; }
            public string State { get; set; }//region
        }

    }
}
