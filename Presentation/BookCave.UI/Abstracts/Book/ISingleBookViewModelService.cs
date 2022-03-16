using BookCave.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts.Book
{
    public interface ISingleBookViewModelService
    {
        Task<SingleBookViewModel> GetSingleBookViewModelAsync(string isbn);
    }
}
