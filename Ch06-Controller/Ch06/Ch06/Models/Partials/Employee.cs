using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch06.Models
{
    [MetadataType(typeof(EmployeeMD))]
    public partial class Employee
    {
        public class EmployeeMD
        {
            public int EmployeeID { get; set; }
            [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$")]
            public string LastName { get; set; }
            [RegularExpression(@"^[a-zA-Z''-'\s]{1,10}$")]
            public string FirstName { get; set; }
            public string Title { get; set; }
            public string TitleOfCourtesy { get; set; }
            public Nullable<System.DateTime> BirthDate { get; set; }
            public Nullable<System.DateTime> HireDate { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string HomePhone { get; set; }
            public string Extension { get; set; }
            public byte[] Photo { get; set; }
            public string Notes { get; set; }
            public Nullable<int> ReportsTo { get; set; }
            public string PhotoPath { get; set; }
        }
    }
}