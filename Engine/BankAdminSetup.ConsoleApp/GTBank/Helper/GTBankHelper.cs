using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office.Interop.Excel;
using ClosedXML;
using ClosedXML.Excel;

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
            var branches = UploadBTBankBranchesExcel();

            //template for creating the branch sql
            var branchsqlTemplate = "INSERT INTO [ZoneAdminPortal].[dbo].[Branch] ([Address],[Code],[Name],[BranchCode],[RegionID],[Status],[MFB_Code],[IsHeadOffice],[CPCHubID],[PilotStatus]) VALUES ( '{{address}}','{{code}}','{{branchname}}','{{branchcode}}', (select top(1) ID FROM [ZoneAdminPortal].[dbo].[Region] where Name = '{{regionname}}') ,2 ,NULL ,0, NULL ,0);\n\n";

            var branchSqlString = "";

            //for each branch, find the corresponding region using the index number.
            foreach (var b in branches)
            {
                try
                {
                    var temp = branchsqlTemplate;
                    var address = b.Address?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var code = b.BranchCode?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var branchname = b.BranchName?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var regionname = b.State?.Trim('\r')?.Trim()?.Replace("'", "''");

                    temp = temp.Replace("{{address}}", address);
                    temp = temp.Replace("{{code}}", code);
                    temp = temp.Replace("{{branchname}}", branchname);
                    temp = temp.Replace("{{branchcode}}", code);
                    temp = temp.Replace("{{regionname}}", regionname);

                    branchSqlString += temp;
                }
                catch (Exception ex)
                {

                }
            }

            Console.WriteLine(branchSqlString);
            return branchSqlString;
        }

        //public static string CreateUserInsert()
        //{
        //    // 
        //    var userInsertSqlTemplate = "INSERT INTO [ZoneAdminPortal].[dbo].[Users] ([Username],[LastName], [OtherNames] ,[PhoneNo] ,[EmployeeNo], [Email] ,[Designation] ,[Role],[CreationDate] ,[BranchID],[HasApprovalRight], [Status], [Discriminator]) VALUES ('{{username}}', '{{lastname}}', '{{othername}}', '{{phone}}', '{{employee}}', '{{email}}', '{{designation}}',(select top(1) ID from [ZoneAdminPortal].[dbo].[UserRoles] where Name = '{{rolename}}'),'{{date}}',(select top(1) ID from [ZoneAdminPortal].[dbo].[Branch] where Name = '{{branchname}}'), '1','2', 'BranchUser');\n\n";
        //}

        public static List<GTBankBranches> UploadBTBankBranchesExcel(string filePath = @"C:\temp\GTBank Branches.xlsx")
        {
            List<GTBankBranches> list = new List<GTBankBranches>();
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                bool FirstRow = true;
                //Range for reading the cells based on the last cell used.  
                string readRange = "1:6";
                foreach (IXLRow row in worksheet.RowsUsed())
                {
                    if (FirstRow)
                    {
                        FirstRow = false;
                        continue;
                    }
                    int cellIndex = 1;
                    var gtbBranchRow = new GTBankBranches();
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        switch (cellIndex)
                        {
                            case 1:
                                gtbBranchRow.SN = cell.Value.ToString();
                                break;
                            case 2:
                                gtbBranchRow.BranchCode = cell.Value.ToString();
                                break;
                            case 3:
                                gtbBranchRow.BranchName = cell.Value.ToString();
                                break;
                            case 4:
                                gtbBranchRow.Address = cell.Value.ToString();
                                break;
                            case 5:
                                gtbBranchRow.CityNameBankCode = cell.Value.ToString();
                                break;
                            case 6:
                                gtbBranchRow.State = cell.Value.ToString();
                                break;
                        };
                        cellIndex++;
                    }
                    list.Add(gtbBranchRow);
                }
            }
            return list;
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
