using System.Collections.Generic;

namespace OOPS_WITH_CRUD.Repositories
{
    public abstract class BaseRepository<TKey, T>
    {
        protected Dictionary<TKey, T> store = new Dictionary<TKey, T>();
        
        
        public T this[TKey id]
        {
            get { return store[id]; }
            set { store[id] = value; }
        }
    }
    
}