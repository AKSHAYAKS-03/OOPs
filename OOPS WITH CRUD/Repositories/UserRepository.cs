using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPS_WITH_CRUD.Interfaces;
using OOPS_WITH_CRUD.Models;

namespace OOPS_WITH_CRUD.Repositories
{
    // UserRepository inherits from BaseRepository and implements IUserRepository
    class UserRepository : BaseRepository<string, User>, IUserRepository<string, User>
    {
    
        static int idCounter = 1;

        public User Create(User user)
        {
            user.Id = idCounter.ToString();
            idCounter++;

            this[user.Id] = user;  //indexer 
            return user;
        }
        public User? Get(string id)
        {
            if(store.ContainsKey(id))
            {
                return this[id];
            }
            return null;
        }
        public List<User> GetAll()
        {
            return new List<User>(store.Values);
        }
        public User? Update(string id, User user)
        {
            if(store.ContainsKey(id))
            {
                user.Id = id;
                this[id] = user;
                return user;
            }
            return null;
        }
        public User Delete(string id)
        {          
          if(store.ContainsKey(id))
            {
                var user = this[id];
                store.Remove(id);
                return user;
            }
            throw new ArgumentException("User not found");
        }


        

    }
}