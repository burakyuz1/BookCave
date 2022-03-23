using System.ComponentModel.DataAnnotations;

namespace BookCave.UI.Areas.Admin.Models
{
    public class AddAuthorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can not pass empty!")]
        [MaxLength(100)]
        public string FullName { get; set; }
    }
}
