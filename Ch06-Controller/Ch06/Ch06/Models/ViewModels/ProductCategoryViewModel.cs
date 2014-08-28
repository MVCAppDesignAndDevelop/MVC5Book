using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ch06.Models;

namespace Ch06.Models.ViewModels
{
    public class ProductCategoryViewModel
    {
        public string Author { get; set; }
        public string Book { get; set; }
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}