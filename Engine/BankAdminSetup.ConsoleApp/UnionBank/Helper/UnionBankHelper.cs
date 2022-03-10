using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdminSetup.ConsoleApp.UnionBank.Helper
{
    public class UnionBankHelper
    {
        public static List<UnionBranch> GetUnionBranches(string filePath = @"C:\temp\Union Bank Branch list.xlsx")
        {
            List<UnionBranch> list = new List<UnionBranch>();
            using (XLWorkbook workbook = new XLWorkbook(filePath))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                bool FirstRow = true;
                //Range for reading the cells based on the last cell used.  
                string readRange = "1:12";
                foreach (IXLRow row in worksheet.RowsUsed())
                {
                    if (FirstRow)
                    {
                        FirstRow = false;
                        continue;
                    }
                    int cellIndex = 1;
                    var unionbankBranchRow = new UnionBranch();
                    foreach (IXLCell cell in row.Cells(readRange))
                    {
                        switch (cellIndex)
                        {
                            case 1:
                                unionbankBranchRow.SN = cell.Value.ToString();
                                break;
                            case 2:
                                unionbankBranchRow.FCUBS_BRANCH_CODE = cell.Value.ToString();
                                break;
                            case 3:
                                unionbankBranchRow.STATUS = cell.Value.ToString();
                                break;
                            case 4:
                                unionbankBranchRow.BRANCH_NAME = cell.Value.ToString();
                                break;
                            case 5:
                                unionbankBranchRow.ZONE = cell.Value.ToString();
                                break;
                            case 6:
                                unionbankBranchRow.REGION = cell.Value.ToString();
                                break;
                            case 7:
                                unionbankBranchRow.BRANCH_ADDRESS = cell.Value.ToString();
                                break;
                            case 8:
                                unionbankBranchRow.STATE = cell.Value.ToString();
                                break;
                            case 9:
                                unionbankBranchRow.SORT_CODE = cell.Value.ToString();
                                break;
                            case 10:
                                unionbankBranchRow.LOCAL_GOVERNMENT = cell.Value.ToString();
                                break;
                            case 11:
                                unionbankBranchRow.OPENING_TIME = cell.Value.ToString();
                                break;
                            case 12:
                                unionbankBranchRow.CLOSING_TIME = cell.Value.ToString();
                                break;
                        };
                        cellIndex++;
                    }
                    list.Add(unionbankBranchRow);
                }
            }
            return list;
        }

        public static string CreateRegionInsert()
        {
            var regions = GetUnionBranches().Select(r => r.REGION)?.Distinct()?.ToArray();
            var regionInsertStr = "";
            var insertTemp = "INSERT INTO [ZoneAdminPortal].[dbo].[Region] ([Code],[Name],[Description],[Status],[MFB_Code]) VALUES ( '{{code}}','{{name}}','{{description}}' ,2 ,NULL);\n\n";
            foreach (var region in regions)
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
        }

        public static string CreateUserRoleInsert()
        {
            #region union bank user roles 
            var ur = @"RECONCILIATION
SETTLEMENT
REFUNDS
ATM BUSINESS
CONTACT CENTER CHANNEL HELP DESK
INTERNAL CONTROL
Audit";
            #endregion
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

        public static string CreateBranchInsert()
        {
            var branches = GetUnionBranches();

            //template for creating the branch sql
            var branchsqlTemplate = "INSERT INTO [ZoneAdminPortal].[dbo].[Branch] ([Address],[Code],[Name],[BranchCode],[RegionID],[Status],[MFB_Code],[IsHeadOffice],[CPCHubID],[PilotStatus]) VALUES ( '{{address}}','{{code}}','{{branchname}}','{{branchcode}}', (select top(1) ID FROM [ZoneAdminPortal].[dbo].[Region] where Name = '{{regionname}}') ,2 ,NULL ,0, NULL ,0);\n\n";

            var branchSqlString = "";

            //for each branch, find the corresponding region using the index number.
            foreach (var b in branches)
            {
                try
                {
                    var temp = branchsqlTemplate;
                    var address = b.BRANCH_ADDRESS?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var code = b.FCUBS_BRANCH_CODE?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var branchname = b.BRANCH_NAME?.Trim('\r')?.Trim()?.Replace("'", "''");
                    var regionname = b.STATE?.Trim('\r')?.Trim()?.Replace("'", "''");

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

        public class UnionBranch
        {
            public string SN { get; set; }
            public string FCUBS_BRANCH_CODE { get; set; }
            public string STATUS { get; set; }
            public string BRANCH_NAME { get; set; }
            public string ZONE { get; set; }
            public string REGION { get; set; }
            public string BRANCH_ADDRESS { get; set; }
            public string STATE { get; set; }
            public string SORT_CODE { get; set; }
            public string LOCAL_GOVERNMENT { get; set; }
            public string OPENING_TIME { get; set; }
            public string CLOSING_TIME { get; set; }
        }
    }
}
