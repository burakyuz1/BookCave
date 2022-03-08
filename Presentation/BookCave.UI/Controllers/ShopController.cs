using BookCave.Application.Abstracts.Shop;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using BookCave.Application.ViewModels;

namespace BookCave.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBookCategoryService _bookCategoryService;

        public ShopController(IBookCategoryService bookService)
        {
            _bookCategoryService = bookService;
        }
        public async Task<IActionResult> Index(int? categoryId, AuthorViewModel author, int? min, int? max)
        {
            var model = await _bookCategoryService.GetBookCategoryViewModel(categoryId, author, min, max);
            return View(model);
        }
    }
}
