using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts
{
    public interface ICartViewModelService
    {
        Task<CartViewModel> GetCartViewModelAsync();
        Task<NavCartViewModel> GetNavCartViewModelAsync();
        Task<CartViewModel> AddToCartAsync(string isbn, int quantity);
        Task RemoveCartLineAsync(int cartLineId);
        Task RemoveCartAsync();
        Task<CartViewModel> UpdateCartAsync(Dictionary<int, int> quantities);
        Task<OrderCompleteViewModel> CompleteCheckoutAsync(OrderViewModel orderViewModel);
    }
}
