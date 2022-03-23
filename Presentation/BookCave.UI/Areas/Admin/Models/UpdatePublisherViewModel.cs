using System.ComponentModel.DataAnnotations;

namespace BookCave.UI.Areas.Admin.Models
{
    public class UpdatePublisherViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can not pass empty!")]
        [MaxLength(90)]
        public string Name { get; set; }
    }
}
