using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AloftMVC.Models
{
    public class MemberRegisterVM
    {
        [Required, Display(Name="Email"), MaxLength(100)]
        public string Email { get; set; }

        [Required, Display(Name = "Display Name"), MaxLength(50)]
        public string Name { get; set; }

        [Required, Display(Name = "Password"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Login"), MaxLength(100)]
        public string Username { get; set; }

        [Required, Display(Name="Who are you")]
        public string MemberGroup { get; set; }

        public IEnumerable<SelectListItem> MemberGroups { get; set; } 

    }
}