using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp.Models
{
    public class Customer
    {
        string first = "Damilola"; string last = "Adegunwa";
        public void Deconstruct(out string first, out string last)
        {
            first = this.first; last = this.last;
        }
        public void Deconstruct(out string first, out string last, out string middle)
        {
            first = this.first; last = this.last; middle = "COMPUTER_GENERATED_MIDDLENAME";
        }
        public void Deconstruct(out string first, out string last, out string middle, out string username)
        {
            first = this.first; last = this.last;middle = "COMPUTER_GENERATED_MIDDLENAME";username = "username1" ;
        }
    }
}
