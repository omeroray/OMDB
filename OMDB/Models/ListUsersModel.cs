using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class ListUsersModel
    {
        public List<User> User { get; set; }
    }
}