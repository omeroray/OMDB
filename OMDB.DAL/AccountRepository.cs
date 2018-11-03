using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class AccountRepository : Repository<User>
    {
        public bool CheckLogin(string username, string password)
        {
            return Any(x => x.Username == username && x.Password == password);          
        }

        public User GetUserDetailByUsername(string username)
        {
            return FirstOrDefault(x => x.Username == username);
        }

        public List<User> List()
        {
            return Where(x => true);
        }

        public User GetMovieById(int id)
        {
            return GetById(id);
        }

        public void Create(User user)
        {
            Add(user);
        }
    }
}
