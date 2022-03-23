using BookCave.Application.Abstracts.Repository;
using BookCave.Domain.Entities;
using BookCave.Persistance.Identity;
using BookCave.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class DashboardController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(
        IRepository<Book> bookRepository,
        IRepository<Author> authorRepository,
        IRepository<Publisher> publisherRepository,
        IRepository<Category> categoryRepository,
        IRepository<Order> orderRepository,
        UserManager<ApplicationUser> userManager,
       IRepository<OrderDetail> orderDetailRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<IActionResult> Index()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            decimal totalIncome = orderDetails.Sum(x => x.Quantity * x.UnitPrice);
            var model = new DashboardViewModel()
            {
                TotalAuthor = (await _authorRepository.GetAllAsync()).Count,
                TotaLPublisher = (await _publisherRepository.GetAllAsync()).Count,
                TotalCategory = (await _categoryRepository.GetAllAsync()).Count,
                TotalOrder = (await _orderRepository.GetAllAsync()).Count,
                TotalOrderToday = (await _orderRepository.GetAllAsync()).Where(x => x.OrderDate == System.DateTime.Now).Count(),
                TotalBookCount = (await _bookRepository.GetAllAsync()).Count,
                TotalIncome = totalIncome,
                TotalUser = _userManager.Users.Count()
            };
            return View(model);
        }
    }
}
