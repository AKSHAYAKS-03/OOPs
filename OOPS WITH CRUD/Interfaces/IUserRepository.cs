using OOPS_WITH_CRUD.Models;
using System.Collections.Generic;

namespace OOPS_WITH_CRUD.Interfaces
{
    public interface IUserRepository<Key , T>
    {
        T Create(T item);
        T? Get(Key id);
        List<T>? GetAll();
        T? Update(Key id ,T item);
        T Delete(Key id);
    }
}