using BookCave.BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.BookCave.UI.Abstracts.Shop
{
    public interface IBookCategoryService
    {
        Task<BookCategoryViewModel> GetBookCategoryViewModel(int? categoryId, AuthorViewModel author, int? min, int? max, PublisherViewModel publisher);
    }
}
