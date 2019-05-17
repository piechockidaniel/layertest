using System;
using System.Linq;

namespace Domain
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        IQueryable<TAggregateRoot> GetAll();

        TAggregateRoot Get(int id);

        TAggregateRoot Get(Guid guid);

    }
}
