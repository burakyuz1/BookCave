using Ardalis.Specification;
using BookCave.Domain.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.Application.Abstracts.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);
        Task<T> FirstAsync(ISpecification<T> specification);
        Task<T> FirstOrDefaultAsync(ISpecification<T> specification);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
