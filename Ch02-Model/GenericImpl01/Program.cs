using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericImpl01
{
    class Program
    {
        static void Main(string[] args)
        {
            SortUtil<SortClass> util = new SortUtil<SortClass>();
            SortClass s1 = new SortClass();

            util.Sort(s1);
            util.SortDesc(s1);

            Console.ReadLine();
        }
    }

    public class SortClass : ISortable
    {
        public void Sort()
        {
            Console.WriteLine("Sort() called.");
        }

        public void SortDesc()
        {
            Console.WriteLine("SortDesc() called.");
        }
    }

    public interface ISortable
    {
        void Sort();
        void SortDesc();
    }

    public class SortUtil
    {
        public void Sort(object target)
        {
            if (target is ISortable)
                ((ISortable)target).Sort();
        }

        public void SortDesc(object target)
        {
            if (target is ISortable)
                ((ISortable)target).SortDesc();
        }
    }

    public class SortUtil<T> where T : ISortable
    {
        public void Sort(T target)
        {
            target.Sort();
        }

        public void SortDesc(T target)
        {
            target.SortDesc();
        }
    }
}
