using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using BookCave.UI.Abstracts;
using BookCave.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCave.UI.Concretes
{
    public class CartViewModelService : ICartViewModelService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IRepository<Book> _bookrepository;
public CartViewModelService(IRepository<Book> bookrepository)
        {
            _bookrepository = bookrepository;
        }

        public CartViewModelService(IRepository<Cart> cartRepository, IHttpContextAccessor httpContext, ICartService cartService, IOrderService orderService, IRepository<Book> bookRepository)
        {
            _cartRepository = cartRepository;
            _httpContext = httpContext;
            _cartService = cartService;
            _orderService = orderService;
            _bookrepository = bookRepository;
        }

        public async Task<CartViewModel> GetCartViewModelAsync()
        {
            int cartId = (await GetOrCreateCartAsync()).Id;
            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(cartId));
            return CartToViewModel(cart);
        }

        public async Task<NavCartViewModel> GetNavCartViewModelAsync()
        {
            var cart = await GetOrCreateCartAsync();
            var cartVm = CartToViewModel(cart);
            return new()
            {
                TotalPriceCartLine = cartVm.TotalPrice,
                TotalQuantityCartLines = cartVm.TotalCartLines
            };
        }
        public async Task<CartViewModel> AddToCartAsync(string isbn, int quantity)
        {
            var cart = await GetOrCreateCartAsync();
            cart = await _cartService.AddCartLineToCart(isbn, quantity, cart.Id);

            return CartToViewModel(cart);
        }
        public async Task<CartViewModel> UpdateCartAsync(Dictionary<int, int> quantities)
        {
            var cartId = (await GetOrCreateCartAsync()).Id;
            var cart = await _cartService.SetQuantitiesAsync(cartId, quantities);
            return CartToViewModel(cart);
        }
        public async Task RemoveCartAsync()
        {
            var cartId = (await GetOrCreateCartAsync()).Id;
            await _cartService.RemoveCartAsync(cartId);
        }
        public async Task RemoveCartLineAsync(int cartLineId)
        {
            var cartId = (await GetOrCreateCartAsync()).Id;
            await _cartService.RemoveCartLineFromCartAsync(cartId, cartLineId);
        }
        private CartViewModel CartToViewModel(Cart cart)
        {
            return new()
            {
                CartId = cart.Id,
                CustomerId = cart.UserId,
                CartLines = cart.CartLines.Select(x => new CartLineViewModel()
                {
                    BookName = x.Book.Name,
                    ISBN = x.Book.ISBN,
                    UnitPrice = x.Book.UnitPrice,
                    PictureUri = x.Book.ImageUri,
                    Quantity = x.Quantity,
                    CartLineId = x.Id,
                    AuthorName = x.Book.Author.FullName
                }).ToList()
            };
        }
        private async Task<Cart> GetOrCreateCartAsync()
        {
            var userId = await GetOrCreateUserAsync();
            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(userId));

            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId
                };
                await _cartRepository.AddAsync(cart);
            }
            return cart;
        }
        private async Task<string> GetOrCreateUserAsync()
        {
            string loggedUserId = GetUserLogged();
            if (!string.IsNullOrEmpty(loggedUserId)) return loggedUserId;

            string anonUserId = GetUserAnon();
            if (!string.IsNullOrEmpty(anonUserId)) return anonUserId;

            string newUserId = Guid.NewGuid().ToString();

            _httpContext.HttpContext.Response.Cookies.Append(Constants.COOKIE_NAME, newUserId, new CookieOptions()
            {
                IsEssential = true,
                Expires = DateTime.Now.AddDays(14)
            });

            return newUserId;
        }
        private string GetUserAnon() => _httpContext.HttpContext.Request.Cookies[Constants.COOKIE_NAME];
        private string GetUserLogged()
        {
            if (!_httpContext.HttpContext.User.Identity.IsAuthenticated)
                return null;

            return _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<OrderCompleteViewModel> CompleteCheckoutAsync(OrderViewModel orderViewModel)
        {
            var cartId = (await GetOrCreateCartAsync()).Id;
            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(cartId));

            Contact contact = new Contact()
            {
                Name = orderViewModel.Name,
                LastName = orderViewModel.LastName,
                City = orderViewModel.City,
                Country = orderViewModel.Country,
                PhoneNumber = orderViewModel.Phone,
                AddressDescription = orderViewModel.Address
            };

            Order order = await _orderService.AddOrderAsync(cartId, contact);

            foreach (var item in cart.CartLines)
            {
                var book = await _bookrepository.FirstOrDefaultAsync(new BookSpecification(item.ISBN));
                book.SalesQuantity += item.Quantity;
                book.Stock -= item.Quantity;
                await _bookrepository.UpdateAsync(book);
            }

            return new()
            {
                OrderId = order.Id,
                Contact = contact,
                OrderDate = order.OrderDate,
                OrderDetails = order.OrderDetails,
                TotalWithTaxes = order.OrderDetails.Sum(x => x.UnitPrice * x.Quantity) * 1.08m,
                TotalWithoutTaxes = order.OrderDetails.Sum(x => x.UnitPrice * x.Quantity)
            };
        }
        public async Task<bool> CheckCartItemsValid()
        {
            var cartId = (await GetOrCreateCartAsync()).Id;
            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(cartId));
            foreach (var item in cart.CartLines)
            {
                if (!item.Book.Status || item.Book.Stock < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
