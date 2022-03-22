using BookCave.Domain.Entities;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(int cartId, Contact contact);
    }
}
