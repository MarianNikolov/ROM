using ROM.Data.Model;
using System.Linq;

namespace ROM.Data.Repository
{
    public interface IEfRepository<T> where T : class, ROM.Data.Model.Contracts.IDeletable
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
