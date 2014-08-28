using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF07_StoredProcedure
{
    public class BlogFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BlogArticle> Articles { get; set; }
    }
}
