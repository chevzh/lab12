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

        public static void GetPublicMethods(string className)
        {
            Type type = Type.GetType(className, false, true);

            Console.WriteLine("\n");
            Console.WriteLine("Публичные методы класса " + className);
            foreach (MethodInfo mi in type.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.Public))
            {
                Console.WriteLine(mi.Name);                
            }
        }


        public static void GetClassFieldsAndProperties(string className)
        {
            Type type = Type.GetType(className, false, true);

            Console.WriteLine("\n");
            Console.WriteLine("Поля класса " + className);
            foreach (FieldInfo fi in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Свойства класса " + className);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                Console.WriteLine(pi.Name);
            }

        }

        public static void GetClassInterfaces(string className)
        {
            Type type = Type.GetType(className, false, true);

            Console.WriteLine("\n");
            Console.WriteLine("Интерфейсы, реализованные классом " + className);
            foreach (Type i in type.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }

        public static void GetMethodsWithParm(string className, Type parm)
        {
            Type type = Type.GetType(className, false, true);

            Console.WriteLine("\n");
            Console.WriteLine("Методы класса " + className + " с параметром " + parm.ToString());
            foreach (MethodInfo mi in type.GetMethods(BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.Public))
            {
                if(mi.GetParameters().Any(pt => pt.ParameterType == parm))
                {
                    Console.WriteLine(mi.Name);
                }
                
            }
        }

        public static void CallMethod(string className, string methodName, string path)
        {
            Type type = Type.GetType(className, false, true);
            object obj = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            string line;

            if (path != null)
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {

                    line = sr.ReadLine();
                   
                }

                

                method.Invoke(obj, new object[] { int.Parse(line)});
            }
            else
            {
                method.Invoke(obj, null);
            }

        }
    }
}
