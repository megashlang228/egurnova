using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    abstract public class Creator
    { 
        abstract public IPhone GeneratePhone(string n, string p); 

    }

    public class PersonCreator : Creator
    {
        public override IPhone GeneratePhone(string n, string p)
        {
            Person s = new Person(n, p);
            return s;
        }
    }


    public class IPCreator : Creator
    {
        public override IPhone GeneratePhone(string n, string p)
        {
            IP notebook = new IP(n, p);
            return notebook;
        }
    }
}
