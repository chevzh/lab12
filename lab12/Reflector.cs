using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class Reflector
    {
        public static void GetClassContent(string className)
        {
            string log = @"C:\Users\eugen\Desktop\lab12\log.txt";
            Type type = Type.GetType(className, false, true);
            string buffer = null;

            Console.WriteLine("Содержимое класса " + className);
            foreach (MemberInfo mi in type.GetMembers())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                buffer += mi.DeclaringType + " " + mi.MemberType + " " + mi.Name + "\n";
            }

            using (StreamWriter sw = new StreamWriter(log, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(buffer);
            }

        }

        public static void GetPublicMethods(string className) //?????????????????????
        {
            Type type = Type.GetType(className, false, true);

            Console.WriteLine("\n");
            Console.WriteLine("Публичные методы класса " + className);
            foreach (MethodInfo mi in type.GetMethods(BindingFlags.Public))
            {
                Console.WriteLine(mi.Name);                
            }
        }




    }
}
