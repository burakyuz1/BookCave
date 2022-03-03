using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using BookCave.Application.Abstracts.Repository;
using BookCave.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCave.Persistance.EntityFramework.EfRepository
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly BookCaveDbContext _db;

        public EfRepository(BookCaveDbContext db)
        {
            _db = db;
        }

        public async Task<T> AddAsync(T entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().WithSpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISpecification<T> specification)
        {
            return await _db.Set<T>().ToListAsync(specification);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
