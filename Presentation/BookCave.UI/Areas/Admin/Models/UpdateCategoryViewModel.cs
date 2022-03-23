using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Models
{
    public class UpdateCategoryViewModel
    {
        [Required(ErrorMessage = "Can not pass empty!")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Can not pass empty!")]
        [MaxLength(50, ErrorMessage = "Only 50 characters")]
        public string CategoryName { get; set; }
    }
}
