using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Cart> _cartRepo;

        public OrderService(IRepository<Order> orderRepo, IRepository<Cart> cartRepo)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
        }

        public async Task<Order> AddOrderAsync(int cartId, Contact contact)
        {
            var cart = await _cartRepo.FirstOrDefaultAsync(new CartSpecification(cartId));
            if (cart == null)
                throw new ArgumentNullException("Cart can not be null");

            if (cart.CartLines.Count < 1)
                throw new ArgumentNullException("Cart items can not be null");

            Order order = new Order()
            {
                UserId = cart.UserId,
                OrderDate = DateTime.UtcNow,
                ContactDetails = contact,
                OrderDetails = cart.CartLines.Select(x => new OrderDetail()
                {
                    UnitPrice = x.Book.UnitPrice,
                    BookName = x.Book.Name,
                    ISBN = x.ISBN,
                    Quantity = (byte)x.Quantity
                }).ToList()
            };
            await _orderRepo.AddAsync(order);
            await _cartRepo.DeleteAsync(cart);
            return order;
        }
    }
}