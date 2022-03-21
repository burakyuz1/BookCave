using System.ComponentModel.DataAnnotations;

namespace BookCave.UI.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Phone]
        public string Phone { get; set; }
    }
}
