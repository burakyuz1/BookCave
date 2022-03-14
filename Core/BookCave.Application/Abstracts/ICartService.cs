using BookCave.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts
{
    public interface ICartService
    {
        Task<Cart> AddCartLineToCart(string isbn, int quantity, int cartId);
        Task RemoveCartLineFromCartAsync(int cartId, int cartLineId);
        Task RemoveCartAsync(int cartId);    
        Task<Cart> SetQuantitiesAsync(int cartId, Dictionary<int, int> quantities);
        Task TransferCartAsync(string anonymousId, string userId);
    }
}
