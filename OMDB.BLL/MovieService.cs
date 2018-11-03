using OMDB.DAL;
using OMDB.DAL.DtoModels;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.BLL
{
    public class MovieService
    {
        public void Create(Movie movie, List<int> MovieCategories)
        {
            MovieRepository mrepository = new MovieRepository();
            mrepository.Create(movie, MovieCategories);
        }

        public List<Movie> List()
        {
            MovieRepository mrepository = new MovieRepository();
            List<Movie> listmovie = mrepository.List();

            return listmovie;
        }

        public List<Movie> ListByCategoryId(int categoryId)
        {
            MovieRepository mrepo = new MovieRepository();
            return mrepo.ListByCategoryId(categoryId);
        }

        public void Remove(int id)
        {
            MovieRepository mrepository = new MovieRepository();
            mrepository.RemoveById(id);
        }

        public Movie GetMovieById(int id)
        {
            MovieRepository mrepository = new MovieRepository();
            return mrepository.GetMovieById(id);

        }

        public void UpdateMovie(Movie movie, List<int> MovieCategories)
        {
            MovieRepository mrepository = new MovieRepository();
            mrepository.UpdateMovie(movie, MovieCategories);
        }

        public void CreateActorRelation(MovieCastCrew movieActor)
        {
            MovieRepository mrepository = new MovieRepository();
            mrepository.CreateActorRelation(movieActor);
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByMovieId(int movieId)
        {
            MovieRepository mrepository = new MovieRepository();
            return mrepository.GetMovieCastCrewByMovieId(movieId);
        }

        public void RemoveActorRelation(int movieCastCrewId)
        {
            MovieRepository mrepository = new MovieRepository();
            mrepository.RemoveActorRelation(movieCastCrewId);
        }
    }
}
