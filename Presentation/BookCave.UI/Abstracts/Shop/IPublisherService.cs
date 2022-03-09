using BookCave.BookCave.UI.ViewModels;
using System.Threading.Tasks;


namespace BookCave.BookCave.UI.Abstracts.Shop
{
    public interface IPublisherService
    {
        Task<PublisherViewModel> GetPublisherViewModelAsync();
    }
}
