using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    interface IExample { void Example(); }

    public partial class Set<T> : IEnumerable<T>,IExample
    {
        public void Example() { Console.WriteLine("Пример"); }

        private List<T> _items;

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public Set()
        {
            _items = new List<T>();
        }

        public Set(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException();
                        
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (item == null) throw new ArgumentNullException();
            if (!_items.Contains(item)) throw new Exception(); // дописать исключение
            _items.Remove(item);
        }


        public  Set<T> Intersect(Set<T> set1, Set<T> set2)
        {
            if (set1 == null) throw new ArgumentNullException();
            if (set2 == null) throw new ArgumentNullException();

            List<T> list1 = new List<T>(set1);
            List<T> list2 = new List<T>(set2);
            List<T> list3 = new List<T>();

            list3 = list1.Intersect(list2).ToList();

            Set<T> resultSet = new Set<T>(list3);

            return resultSet;
        }

       
        public bool IsSubset(Set<T> set)
        {
            //вернёт true, если set подмножество this
            return !this.Except(set).Any();
        }


        //public bool Equals(Set<T> set)
        //{
        //    if (set == null)
        //        return false;
        //    if (this.Count() != set.Count())
        //        return false;

        //    return set.SequenceEqual(this);
        //} 

        public void Print()
        {
            int counter = 1;
          
            foreach (var item in this)
            {              
               
                if(counter == this.Count())
                {
                    Console.Write(item + ";\n");
                }
                else
                {
                    Console.Write(item + ", ");
                    counter++;
                }
                
            }
        }

        

        //вложенный класс Date
        class Date
        {
            public string date;
            public Date()
            {
                date = DateTime.Now.ToString();
            }
        }

        public class Owner
        {
            Date date = new Date();
            public int Id { get; } = 06041996;     
            public string OwnerName { get; } = "Eugene Chevzhik";
            public string OwnerCompany { get; } = "123 432";

            public void Print()
            {
                Console.Write(OwnerName + " " + date.date + "\n");
            }
        }   

    }
}
