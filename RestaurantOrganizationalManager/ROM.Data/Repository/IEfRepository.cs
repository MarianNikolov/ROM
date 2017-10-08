using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
