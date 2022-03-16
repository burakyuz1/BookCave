using System.ComponentModel.DataAnnotations;

namespace BookCave.UI.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage ="Hata var")]
        public string Name { get; set;}
        [Required(ErrorMessage = "Hata var")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Hata var")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Hata var")]
        public string City { get; set; }
        [Required(ErrorMessage = "Hata var")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Hata var")]
        [Phone]
        public string Phone { get; set; }
    }
}
