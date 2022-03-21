using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts
{
    public interface IOrderViewModelService
    {
        Task<OrderCompleteViewModel> GetCompletedOrderViewModelAsync(int orderId);
        Task<List<OrderCompleteViewModel>> GetCompletedOrderViewModelAsync(string userId);
    }
}
