using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Antlr.Runtime;

namespace Ch06.Models
{
    public class Customer : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Email]
        public string Email { get; set; }
        public string Email2 { get; set; }
        [Required]
        [DisplayName("生日")]
        public DateTime Birthday { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 驗證屬性
            if (Name == null)
            {
               yield return new ValidationResult("名稱不得空白。", new [] {"Name"});
            }
            if (Email == null || Email2 == null)
            {
                yield return new ValidationResult("電子郵件不的空白。", new[] { "Email", "Email2" });
            }

            if (Email != Email2)
            {
                yield return new ValidationResult("電子郵件不相符。", new [] {"Email", "Email2"});
            }

            if (Birthday > DateTime.Now)
            {
                yield return new ValidationResult("生日，不可以是未來！", new [] {"Birthday"});
            }
            if (Birthday < DateTime.Now.AddYears(-100))
            {
                yield return new ValidationResult("Wow，有點不敢相信！", new [] {"Birthday"});
            }
        }
    }
}