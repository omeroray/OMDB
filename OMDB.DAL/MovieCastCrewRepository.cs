using OMDB.DAL.DtoModels;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class MovieCastCrewRepository : Repository<MovieCastCrew>
    {
        public void Create(MovieCastCrew movieActor)
        {
            Add(movieActor);
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByMovieId(int movieId)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                var query = (from movieCastCrew in context.MovieCastCrew
                             where movieCastCrew.MovieId == movieId
                             select new MovieCastCrewDtoModel
                             {
                                 RelationId = movieCastCrew.Id,
                                 Movie = movieCastCrew.Movie,
                                 Actor = movieCastCrew.CastCrew,
                                 Title = movieCastCrew.Title
                             });

                return query.ToList();
            }
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByActorId(int actorId)
        {
            using (OMDBEntities context = new OMDBEntities())
            {
                var query = (from movieCastCrew in context.MovieCastCrew
                             where movieCastCrew.CastCrewId == actorId
                             select new MovieCastCrewDtoModel
                             {
                                 RelationId = movieCastCrew.Id,
                                 Movie = movieCastCrew.Movie,
                                 Actor = movieCastCrew.CastCrew,
                                 Title = movieCastCrew.Title
                             });

                return query.ToList();
            }
        }
    }
}
