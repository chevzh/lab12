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
            List<string> buffer = new List<string>();

            Console.WriteLine("Содержимое класса " + className);
            foreach (MemberInfo mi in type.GetMembers())
            {
                Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
                buffer.Add(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            }

            using (StreamWriter sw = new StreamWriter(log, false, System.Text.Encoding.Default))
            {
                foreach(var str in buffer)
                {
                    sw.WriteLine(str);
                }
                
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
