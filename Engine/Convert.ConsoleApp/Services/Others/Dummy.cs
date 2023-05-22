using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.Junk
{
    public sealed record class Dummy(int Age, DateTimeOffset dob)
    {
        private string _nick_name = "dotman";
        public Dummy() : this(10, DateTime.Parse("31/12/1970"))
        {
            _nick_name = "Edited Dotman";
            Console.WriteLine("dummy constructor was called!");
        }
        public string? Name { get; set; }
        public string? School { get; set; }
        public string? Work { get; set; }

        public void Call()
        {
            Console.WriteLine("damilola is testing!");
        }

        public void Int()
        {
            Console.WriteLine();
        }

        public Dummy _Name(Dummy dummy)
        {
            return new Dummy { Name = _nick_name };
        }
        public Dummy CloneThis(Dummy dummy)
        {
            dummy.Work = "MS";
            return dummy;
        }

        public string this[int index]
        {
            get { return _nick_name; }
            set { _nick_name = value; }
        }
    }
}
/*
 var w = (Dummy)System.Runtime.Serialization.FormatterServices.GetSafeUninitializedObject(typeof(Dummy));
			w.School = "Lautech";
			w.Name = "Self";
			w.Work = "Interswitch";
			//var q = (Dummy)Activator.CreateInstance("ConvertApp.ConsoleApp", "ConvertApp.ConsoleApp.Services.Dummy").Unwrap();
			//Dummy instance = (Dummy)Activator.CreateInstance(typeof(Dummy));
			w.Call();
			Console.WriteLine($"school: {w.School}, work: {w.Work}, name: {w.Name}");
			Console.WriteLine($"done");
 */