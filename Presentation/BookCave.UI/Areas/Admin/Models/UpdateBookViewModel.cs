using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.UI.Areas.Admin.Models
{
    public class UpdateBookViewModel
    {
        [Required(ErrorMessage = "Can not pass empty!")]
        [MinLength(13, ErrorMessage = "Only 13 characters")]
        [MaxLength(13, ErrorMessage = "Only 13 characters")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Can not pass empty!")]
        [MaxLength(50, ErrorMessage = "Only 50 characters")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Can not pass empty!")]
        [MaxLength(500, ErrorMessage = "Only 500 characters")]
        public string Details { get; set; }

        [Required(ErrorMessage = "Can not pass empty!")]
        [Range(1700, 2024)]
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }

        [Required(ErrorMessage = "Can not pass empty!")]
        [Range(1, 3000)]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Can not pass empty!")]
        [Range(1, 4000)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Can not pass empty!")]
        [Range(1, 14000)]
        [Display(Name = "Number of Page")]
        public int NumberOfPage { get; set; }
        public int SelectedPublisherId { get; set; }
        public int SelectedCategoryId { get; set; }
        public int SelectedAuthorId { get; set; }
        public string PictureUri { get; set; }
        public IFormFile Picture { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Publishers { get; set; }
        public List<SelectListItem> Authors { get; set; }
    }
}
