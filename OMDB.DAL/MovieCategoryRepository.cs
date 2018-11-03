using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
   public class MovieCategoryRepository : Repository<MovieCategory>
    {
        public void Create(MovieCategory moviecategory)
        {
            moviecategory.CreatedDate = DateTime.Now;
            Add(moviecategory);
        }

        public void RemoveAllByMovieId(int movieId)
        {
            RemoveRange(x => x.MovieId == movieId);
        }
    }
}
