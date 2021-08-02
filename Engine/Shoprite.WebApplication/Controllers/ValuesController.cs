using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace Shoprite.WebApplication.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var file = System.Web.HttpContext.Current.Request.Files[0];
            var paymentFileType = System.Web.HttpContext.Current.Request.Headers["paymentFileType"];
            string filename = file.FileName;
            string ext = filename.Substring(filename.LastIndexOf('.') + 1, filename.Length - (filename.LastIndexOf(".") + 1));
            if (ext?.ToLower() != "txt")
            {
                throw new Exception("File format not supported");
            }
            string line = null;
            if(paymentFileType == "vendor")
            {
                List<VendorPayment> result = new List<VendorPayment>();
                using (var ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    //StreamReader reader = new StreamReader(file.InputStream);
                    StreamReader reader = new StreamReader(ms);
                    //string text = reader.ReadToEnd();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] vendorArr = line.Split('#');
                        result.Add(new VendorPayment
                        {
                            FILLER82 = vendorArr[1],
                            FILLER2 = vendorArr[2],
                            PaymentOrValueDate = vendorArr[3],
                            PaymentCurrency = vendorArr[8],
                            PaymentAmount = vendorArr[9],
                            DebitAccountNumber = vendorArr[11],
                            FILLER18 = vendorArr[21],
                            CustomerReference = vendorArr[24],
                            FILLER36 = vendorArr[41],
                            BeneficiaryBankCode = vendorArr[42],
                            BeneficiaryAccountNumber = vendorArr[43],
                            BeneficiaryName = vendorArr[44],
                            BeneficiaryAddress1 = vendorArr[46],
                            BeneficiaryAddress2 = vendorArr[47],
                            FILLER83 = vendorArr[50],
                            FILLER84 = vendorArr[71],
                            FILLER68 = vendorArr[80],
                        });
                    }
                }
                return Ok(result);
            }
            else if(paymentFileType == "payroll")
            {
                List<PayrollDetails> result = new List<PayrollDetails>();
                using (var ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    //StreamReader reader = new StreamReader(file.InputStream);
                    StreamReader reader = new StreamReader(ms);
                    //string text = reader.ReadToEnd();
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] vendorArr = line.Split('#');
                        result.Add(new PayrollDetails
                        {
                            FILLER3 = vendorArr[1],
                            FILLER4 = vendorArr[2],
                            PaymentOrValueDate = vendorArr[3],
                            PaymentCurrency = vendorArr[8],
                            PaymentAmount = vendorArr[9],
                            DebitAccountNumber = vendorArr[11],
                            CustomerReference = vendorArr[24],
                            BeneficiaryAccountNumber = vendorArr[43],
                            BeneficiaryName = vendorArr[44],
                            BeneficiaryAddress1 = vendorArr[46],
                            BeneficiaryAddress2 = vendorArr[47],
                            BeneficiaryAddress1LocalLanguage = vendorArr[48],
                            BeneficiaryBankCode = vendorArr[50],
                            BeneficiaryNameLine1LocalLanguage = vendorArr[71],
                            PaymentDetailLine1 = vendorArr[72],
                        });
                    }
                }
                return Ok(result);
            }
            return BadRequest();
        }
        public class VendorPayment
        {
            public string FILLER82 { get; set; }//2 - COUNTRY
            public string FILLER2 { get; set; }//3 - 
            public string PaymentOrValueDate { get; set; }//4
            public string PaymentCurrency { get; set; }//9
            public string PaymentAmount { get; set; }//10
            public string DebitAccountNumber { get; set; }//12
            public string FILLER18 { get; set; }//22
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

        //[Route("payroll")]
        //public IHttpActionResult GetPayrollDetails()
        //{
        //    return Ok();
        //}
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
}
