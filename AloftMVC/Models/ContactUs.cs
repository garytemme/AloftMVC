using System.ComponentModel.DataAnnotations;

namespace AloftMVC.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mesasge { get; set; }
    }

}