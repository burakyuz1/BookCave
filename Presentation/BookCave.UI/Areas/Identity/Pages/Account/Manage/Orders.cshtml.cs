using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Persistance.Identity;
using BookCave.UI.Abstracts.Order;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCave.UI.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderViewModelService _orderViewModelService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersModel(IOrderViewModelService orderViewModelService, UserManager<ApplicationUser> userManager)
        {
            _orderViewModelService = orderViewModelService;
            _userManager = userManager;
        }

        public List<OrderCompleteViewModel> Orders { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = (await _userManager.GetUserAsync(User)).Id;
            var orders = await _orderViewModelService.GetCompletedOrderViewModelAsync(userId);
            Orders = orders;
            return Page();
        }
    }
}
