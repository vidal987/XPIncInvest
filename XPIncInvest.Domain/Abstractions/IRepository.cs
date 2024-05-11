using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPIncInvest.Domain.Abstractions;
using XPIncInvest.Domain.Primitives;

namespace XPIncInvest.Infrastructure.Context
{
    public interface IRepository<T> where T : Entity // T is a generic type, it means that it can be of any type
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);
        Task<T> GetByIdAsync<TId>(TId id);
        void Update(T entity);
        void Remove(T entity);
    }
}
