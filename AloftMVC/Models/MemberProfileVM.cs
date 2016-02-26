using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AloftMVC.Models
{
    public class MemberProfileVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string AvatarCropperImage { get; set; }
    }
}