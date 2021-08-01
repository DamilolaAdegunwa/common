using System;

namespace Shoprite.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string vendor_payment_sample = "#NG#DFT#20210611#####NGN# 56348.71##1010822024##########OUR###5221004602#################01#221150014#0025027676#Elysium Diem Nigeria Ltd##Ground Floor, Gwandal Centre, Plot#Fomula Str, Adetokunbo Ademola Cr,###221150014#####################Elysium Diem Nigeria Ltd Novare Cen#########Is Bank#############";
            //var vs = vendor_payment_sample.Split('#');

            string payroll2 = "#NG#DFT#20210527#####NGN#        100000.00##1010861290#############00075729###################0007411325#Employee Name##4a Ogui Railway Quaters#Nigeria#100001##221150014#####################Employee Name#May 2021 Salary##";
            var vs2 = payroll2.Split('#');
            Console.WriteLine("Hello World!");
        }

    }

    public class PayrollDetails
    {
        public string FILLER3 { get; set; }//2
        public string FILLER4 { get; set; }//3
        public string PaymentOrValueDate { get; set; }//4
        public string PaymentCurrency { get; set; }//9
        public string PaymentAmount { get; set; }//10
        public string DebitAccountNumber { get; set; }//12
        public string CustomerReference { get; set; }//25
        public string BeneficiaryAccountNumber { get; set; }//44
        public string BeneficiaryName { get; set; }//45
        public string BeneficiaryAddress1 { get; set; }//47 - Address
        public string BeneficiaryAddress2 { get; set; }//48 - Country
        public string BeneficiaryAddress1LocalLanguage { get; set; }//49 - ZipCode
        public string BeneficiaryBankCode { get; set; }//51
        public string BeneficiaryNameLine1LocalLanguage { get; set; }//72
        public string PaymentDetailLine1 { get; set; }//73
    }
}
