using System;
using System.Collections.Generic;
using System.Text;

namespace Shoprite.ConsoleApp.Services
{
    public class VendorPaymentService
    {
        private readonly string vendor_payment_sample = "#NG#DFT#20210611#####NGN# 56348.71##1010822024##########OUR###5221004602#################01#221150014#0025027676#Elysium Diem Nigeria Ltd##Ground Floor, Gwandal Centre, Plot#Fomula Str, Adetokunbo Ademola Cr,###221150014#####################Elysium Diem Nigeria Ltd Novare Cen#########Is Bank#############";

        public List<VendorPayment> SplitByHashes()
        {
            vendor_payment_sample.Split('#');
        }
    }
    public class VendorPayment
    {
        public string FILLER82 { get; set; }//2 - COUNTRY
        public string FILLER2 { get; set; }//3 - 
        public string PaymentOrValueDate { get; set; }//4
        public string PaymentCurrency { get; set; }//9
        public string PaymentAmount { get; set; }//10
        public string DebitAccountNumber { get; set; }//12
        public string FILLER18{ get; set; }//22
        public string CustomerReference { get; set; }//25
        public string FILLER36 { get; set; }//42
        public string BeneficiaryBankCode { get; set; }//43
        public string BeneficiaryAccountNumber { get; set; }//44
        public string BeneficiaryName { get; set; }//45
        public string BeneficiaryAddress1 { get; set; }//47
        public string BeneficiaryAddress2 { get; set; }//48
        //51 72 81
        public string FILLER83 { get; set; }//51
        public string FILLER84 { get; set; }//72
        public string FILLER68 { get; set; }//81
    }
}
