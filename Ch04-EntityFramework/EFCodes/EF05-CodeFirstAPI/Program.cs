using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF05_CodeFirstAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<BlogModel>(new DropCreateDatabaseAlways<BlogModel>());

            using (var blogModel = new BlogModel())
            {
                blogModel.Database.Initialize(true);
            }
        }
    }
}
