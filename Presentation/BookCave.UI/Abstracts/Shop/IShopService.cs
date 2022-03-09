using BookCave.Application;
using BookCave.UI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.UI.Abstracts.Shop
{
    public interface IShopService
    {
        Task<ShopViewModel> GetShopViewModelAsync(List<AuthorViewModel> authors, List<PublisherViewModel> publisherIds, int? categoryId, int? min, int? max, OrderType orderType);
    }
}
