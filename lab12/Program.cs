using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {

            Reflector.GetClassContent("lab12.MyDate");
            Reflector.GetPublicMethods("lab12.MyDate");
            Reflector.GetClassFieldsAndProperties("lab12.MyDate");
            Reflector.GetClassInterfaces("lab12.MyDate");
            Reflector.GetMethodsWithParm("lab12.MyDate", typeof(int));
            Reflector.CallMethod("lab12.MyDate", "GetSum", @"C:\Users\eugen\Desktop\lab12\parms.txt");

        }
    }
}
