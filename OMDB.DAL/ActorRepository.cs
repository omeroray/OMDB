using OMDB.DAL.DtoModels;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class ActorRepository : Repository<CastCrew>
    {
        public void Create(CastCrew actor)
        {
            Add(actor);
        }

        public List<CastCrew> List()
        {
            return Where(x => true);
        }

        public CastCrew GetActorById(int id)
        {
            return GetById(id);

        }

        public void UpdateActor(CastCrew actor)
        {
            Update(actor);
        }

        public void RemoveById(int id)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            marepo.RemoveRange(x => x.CastCrewId == id);
            Remove(id);
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByActorId(int actorId)
        {
            MovieCastCrewRepository marepo = new MovieCastCrewRepository();
            return marepo.GetMovieCastCrewByActorId(actorId);
        }
    }
}
