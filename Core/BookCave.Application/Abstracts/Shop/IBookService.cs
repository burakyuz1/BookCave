using BookCave.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts.Shop
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetBookViewModelAsync();
    }
}
