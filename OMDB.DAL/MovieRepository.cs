using OMDB.DAL.DtoModels;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class MovieRepository : Repository<Movie>
    {
        public void Create(Movie movie, List<int> MovieCategories)
        {

            Add(movie);

            if (MovieCategories != null)
            {
                MovieCategoryRepository crepo = new MovieCategoryRepository();
                foreach (var item in MovieCategories)
                {
                    MovieCategory mcategory = new MovieCategory();
                    mcategory.MovieId = movie.Id;
                    mcategory.CategoryId = item;
                    crepo.Create(mcategory);
                }
            }
        }

        public List<Movie> List()
        {
            return Where(x => true);
        }

        public List<Movie> ListByCategoryId(int categoryId)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                var query = (from movie in context.Movie
                             join movieCategory in context.MovieCategory on movie.Id equals movieCategory.MovieId
                             where movieCategory.CategoryId == categoryId
                             select movie);
                return query.ToList();
            }
        }

        public Movie GetMovieById(int id)
        {
            return GetById(id);
        }

        public void UpdateMovie(Movie movie, List<int> MovieCategories)
        {
            MovieCategoryRepository crepo = new MovieCategoryRepository();

            Update(movie);
            crepo.RemoveAllByMovieId(movie.Id);

            if (MovieCategories != null)
            {
                foreach (var item in MovieCategories)
                {
                    MovieCategory mcategory = new MovieCategory();
                    mcategory.MovieId = movie.Id;
                    mcategory.CategoryId = item;
                    crepo.Create(mcategory);
                }
            }
        }

        public void CreateActorRelation(MovieCastCrew movieActor)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            marepo.Create(movieActor);
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByMovieId(int movieId)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            return marepo.GetMovieCastCrewByMovieId(movieId);
        }

        public void RemoveActorRelation(int movieCastCrewId)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            marepo.Remove(movieCastCrewId);
        }

        public void RemoveById(int id)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            MovieCategoryRepository crepo = new MovieCategoryRepository();

            marepo.RemoveRange(x => x.MovieId == id);
            crepo.RemoveRange(x => x.MovieId == id);
            Remove(id);
        }
    }
}
