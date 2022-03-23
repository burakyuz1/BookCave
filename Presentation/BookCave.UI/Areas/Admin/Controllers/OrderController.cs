using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> Index()
        {
            var order = await _orderRepository.GetAllAsync();
            return View(order);
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(new OrderSpecification(orderId));
            return View(order);
        }

    }
}
