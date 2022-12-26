using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    
    public class IP : IPhone
    {
        private string Name { get; set; }
        private string Number { get; set; }
        public IP(string n, string p) { Name = n; Number = p; }


        public void call()
        {
            Console.WriteLine("звоним по номеру " + Number);
        }

        public void getInfo()
        {
            Console.WriteLine("номер " + Number + ", владелец ИП " + Name);
        }
    }
}
