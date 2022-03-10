using BookCave.Application;
using BookCave.Application.Enums;
using BookCave.UI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts.Shop
{
    public interface IShopViewModelService
    {
        Task<ShopViewModel> GetShopViewModelAsync(List<AuthorViewModel> authors, List<PublisherViewModel> publisherIds, int? categoryId, int? min, int? max, OrderType orderType, string keyword, SearchType searchType, byte pageNumber);
    }
}
