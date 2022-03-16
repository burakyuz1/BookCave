using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.UI.Abstracts.Order;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookCave.UI.Areas.Identity.Pages.Account.Manage
{
    public class ViewOrderModel : PageModel
    {
        private readonly IOrderViewModelService _orderViewModelService;

        public ViewOrderModel(IOrderViewModelService orderViewModelService)
        {
            _orderViewModelService = orderViewModelService;
        }

        public OrderCompleteViewModel OrderDetail { get; set; }
        public async Task<IActionResult> OnGet(int orderId)
        {
            var orderDetail = await _orderViewModelService.GetCompletedOrderViewModelAsync(orderId);

            OrderDetail = orderDetail;
            return Page();
        }
    }
}
