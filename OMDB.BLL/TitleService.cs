using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.BLL
{
    public class TitleService
    {
        public List<Title> List()
        {
            TitleRepository trepository = new TitleRepository();
            List<Title> listcategory = trepository.List();

            return listcategory;
        }
    }
}
