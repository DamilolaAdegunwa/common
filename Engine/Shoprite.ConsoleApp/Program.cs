using System;

namespace Shoprite.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string vendor_payment_sample = "#NG#DFT#20210611#####NGN# 56348.71##1010822024##########OUR###5221004602#################01#221150014#0025027676#Elysium Diem Nigeria Ltd##Ground Floor, Gwandal Centre, Plot#Fomula Str, Adetokunbo Ademola Cr,###221150014#####################Elysium Diem Nigeria Ltd Novare Cen#########Is Bank#############";
            var vs = vendor_payment_sample.Split('#');
            Console.WriteLine("Hello World!");
        }
    }
}
