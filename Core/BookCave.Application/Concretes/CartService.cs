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
    public class CartService : ICartService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Cart> _cartRepository;

        public CartService(IRepository<Book> bookRepository, IRepository<Cart> cartRepository)
        {
            _bookRepository = bookRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Cart> AddCartLineToCart(string isbn, int quantity, int cartId)
        {
            if (quantity < 1)
                throw new ArgumentNullException("Quantity can not be less than 1.");

            var book = await _bookRepository.FirstOrDefaultAsync(new BookSpecification(isbn));
            if (book == null)
                throw new ArgumentNullException("Book can not be found.");

            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(cartId));
            if (cart == null)
                throw new ArgumentNullException("Cart can not be found.");

            var cartLine = cart.CartLines.FirstOrDefault(x => x.ISBN == isbn);

            if (cartLine == null)
            {
                CartLine newCartLine = new()
                {
                    CartId = cartId,
                    ISBN = isbn,
                    Quantity = quantity,
                    Book = book
                };
                cart.CartLines.Add(newCartLine);
            }
            else
            {
                cartLine.Quantity += quantity;
            }
            await _cartRepository.UpdateAsync(cart);

            return cart;
        }
    }
}
