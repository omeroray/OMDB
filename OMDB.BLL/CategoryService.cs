using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.BLL
{
    public class CategoryService
    {
        public List<Category> List()
        {
            CategoryRepository crepository = new CategoryRepository();
            List<Category> listcategory = crepository.List();

            return listcategory;
        }

        public List<int> GetSelectedCategoriesByMovieId(int movieId)
        {
            CategoryRepository crepository = new CategoryRepository();
            List<int> listcategory = crepository.GetSelectedCategoriesByMovieId(movieId);

            return listcategory;
        }
    }
}
