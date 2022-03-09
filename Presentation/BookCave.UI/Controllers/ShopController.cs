using BookCave.BookCave.UI.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using BookCave.BookCave.UI.ViewModels;

namespace BookCave.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBookCategoryService _bookCategoryService;

        public ShopController(IBookCategoryService bookService)
        {
            _bookCategoryService = bookService;
        }
        public async Task<IActionResult> Index(AuthorViewModel author, PublisherViewModel publisher,int? categoryId, int? min, int? max)
        {
            var model = await _bookCategoryService.GetBookCategoryViewModel(categoryId, author, min, max, publisher);
            return View(model);
        }
    }
}
