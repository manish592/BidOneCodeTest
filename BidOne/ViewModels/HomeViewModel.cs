using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BidOne.ViewModels
{
    public class HomeViewModel
    {
        public RegistertViewModel RegistertViewModel { get; set; }
    }

    public partial class RegistertViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Firstname cannot be longer than 20 characters.")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Lastname cannot be longer than 20 characters.")]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

    }

}
