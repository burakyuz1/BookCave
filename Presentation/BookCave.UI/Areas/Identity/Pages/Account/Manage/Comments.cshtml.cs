using BookCave.Persistance.Identity;
using BookCave.UI.Abstracts.Comment;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Identity.Pages.Account.Manage
{
    public class CommentsModel : PageModel
    {
        private readonly ICommentViewModelService _commentViewModelService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsModel(ICommentViewModelService commentViewModelService, UserManager<ApplicationUser> userManager)
        {
            _commentViewModelService = commentViewModelService;
            _userManager = userManager;
        }
        public List<CommentViewModel> Comments { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;
            var comments = await _commentViewModelService.GetCommentViewModelAsync(userId);
            Comments = comments;
            return Page();
        }
    }
}
