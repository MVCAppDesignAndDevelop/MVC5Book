using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF07_StoredProcedure
{
    public class BlogInfo
    {
        public Guid Id { get; set; }
        public string Author { get; set; }

        public Blog Blog { get; set; }
    }
}
