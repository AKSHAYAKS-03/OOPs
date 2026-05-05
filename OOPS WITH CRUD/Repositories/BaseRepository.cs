using System.Collections.Generic;

namespace OOPS_WITH_CRUD.Repositories
{
    public abstract class BaseRepository<TKey, T>
     where TKey : notnull
    {
        protected Dictionary<TKey, T> store = new Dictionary<TKey, T>();
        
        //indexer to access items in the store
        //to use obj as dictionary
        public T this[TKey id]
        {
            get { return store[id]; }
            set { store[id] = value; }
        }
    }
    
}