using BookCave.Application.Abstracts;
using BookCave.Application.Abstracts.Repository;
using BookCave.Application.Feature.Specifications;
using BookCave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Application.Concretes
{
    public class CartService : ICartService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<CartLine> _cartLineRepository;

        public CartService(IRepository<Book> bookRepository, IRepository<Cart> cartRepository, IRepository<CartLine> cartLineRepository)
        {
            _bookRepository = bookRepository;
            _cartRepository = cartRepository;
            _cartLineRepository = cartLineRepository;
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

        public async Task RemoveCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetAsync(cartId);
            if (cart == null)
            {
                throw new ArgumentNullException("Cart couldnt found!");
            }
            await _cartRepository.DeleteAsync(cart);
        }

        public async Task RemoveCartLineFromCartAsync(int cartId, int cartLineId)
        {
            var cartLine = await _cartLineRepository.GetAsync(cartLineId);
            if (cartLine == null && cartLine.CartId != cartId) throw new ArgumentNullException("Cart line error.");
            await _cartLineRepository.DeleteAsync(cartLine);
        }

        public async Task<Cart> SetQuantitiesAsync(int cartId, Dictionary<int, int> quantities)
        {
            if (quantities.Values.Any(a => a < 1)) throw new ArgumentNullException("Quantity can not lower than 1");
            
            var cart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(cartId));
            if (cart == null) throw new ArgumentNullException("Cart line could not found.");

            foreach (var key in quantities.Keys)
                cart.CartLines.FirstOrDefault(x => x.Id == key).Quantity = quantities[key];

            await _cartRepository.UpdateAsync(cart);

            return cart;
        }

        public async Task TransferCartAsync(string anonymousId, string userId)
        {
            var sourceCart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(anonymousId));
            if (sourceCart == null) return;

            var destinationCart = await _cartRepository.FirstOrDefaultAsync(new CartSpecification(userId));

            if (destinationCart == null)
            {
                destinationCart = new Cart()
                {
                    CustomerId = userId
                };
                await _cartRepository.AddAsync(destinationCart);
            }

            foreach (var sourceItem in sourceCart.CartLines)
            {
                var targetItem = destinationCart.CartLines.FirstOrDefault(x => x.ISBN == sourceItem.ISBN);
                if (targetItem == null)
                    destinationCart.CartLines.Add(new CartLine() { Quantity = sourceItem.Quantity, ISBN = sourceItem.ISBN , CartId = sourceItem.CartId });
                else
                    targetItem.Quantity += sourceItem.Quantity;
            }

            await _cartRepository.UpdateAsync(destinationCart);
            await _cartRepository.DeleteAsync(sourceCart);
        }
    }
}
