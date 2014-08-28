using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericImpl02
{
    class Program
    {
        static void Main(string[] args)
        {
            DataQuery<DataItem> query = new DataQuery<DataItem>();
            query.Query().ToList();
            Console.ReadLine();
        }
    }

    public class DataItem
    {
        public DataItem()
        {
            Console.WriteLine("DataItem created.");
        }
    }

    public class DataQuery<T> where T: class, new()
    {
        private Random rnd = new Random(); // 展示用
        private int rows = 0;

        public DataQuery()
        {
            this.rows = rnd.Next(1, 10); // 展示用，隨機產生 1-10 個物件
        }

        public IEnumerable<T> Query()
        {
            for (int i=0; i<this.rows; i++)
            {
                T item = new T();
                yield return item;
            }
        }
    }
}
