using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.BLL
{
    public class AccountService
    {
        public bool CheckLogin(string username , string password)
        {
            AccountRepository repository = new AccountRepository();
            return repository.CheckLogin(username,password);
        }
        public User GetUserDetailByUsername(string username)
        {
            AccountRepository repository = new AccountRepository();
            return repository.GetUserDetailByUsername(username);
        }
        public List<User> List()
        {
            AccountRepository arepository = new AccountRepository();
            List<User> listuser = arepository.List();

            return listuser;
        }

        public void Remove(int id)
        {
            AccountRepository arepository = new AccountRepository();
            arepository.Remove(id);
        }

        public void Create(User user)
        {
            AccountRepository arepository = new AccountRepository();
            arepository.Create(user);
        }
    }
}
