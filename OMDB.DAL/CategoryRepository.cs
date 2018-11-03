using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class CategoryRepository : Repository<Category>
    {
        public List<Category> List()
        {
            return Where(x => true);
        }

        public List<int> GetSelectedCategoriesByMovieId(int movieId)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                MovieCategoryRepository crepo = new MovieCategoryRepository();
                return crepo.Where(x => x.MovieId == movieId).Select(x => x.CategoryId).ToList();
            }
        }
    }
}
