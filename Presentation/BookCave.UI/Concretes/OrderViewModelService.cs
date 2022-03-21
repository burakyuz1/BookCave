using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts;
using BookCave.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes
{
    public class OrderViewModelService : IOrderViewModelService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderViewModelService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderCompleteViewModel> GetCompletedOrderViewModelAsync(int orderId)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(new OrderSpecification(orderId));
            return OrderToOrderViewModel(order);
        }

        public async Task<List<OrderCompleteViewModel>> GetCompletedOrderViewModelAsync(string userId)
        {
            var order = await _orderRepository.GetAllAsync(new OrderSpecification(userId));


            return order.Select(a => new OrderCompleteViewModel()
            {
                OrderId = a.Id,
                Contact = a.ContactDetails,
                OrderDate = a.OrderDate,
                OrderDetails = a.OrderDetails,
                TotalWithTaxes = a.OrderDetails.Sum(x => x.Quantity * x.UnitPrice) * 1.08m
            }).ToList();

        }

        private OrderCompleteViewModel OrderToOrderViewModel(Order order)
        {
            return new()
            {
                OrderId = order.Id,
                Contact = order.ContactDetails,
                OrderDate = order.OrderDate,
                OrderDetails = order.OrderDetails,
                TotalWithTaxes = order.OrderDetails.Sum(x => x.UnitPrice * x.Quantity) * 1.08m,
                TotalWithoutTaxes = order.OrderDetails.Sum(x => x.UnitPrice * x.Quantity)
            };
        }
    }
}
