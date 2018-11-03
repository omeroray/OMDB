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
    public class ActorService
    {
        public void Create(CastCrew actor)
        {
            ActorRepository arepository = new ActorRepository();
            arepository.Create(actor);
        }
        public List<CastCrew> List()
        {
            ActorRepository arepository = new ActorRepository();
            List<CastCrew> listactor = arepository.List();

            return listactor;
        }
        public void Remove(int id)
        {
            ActorRepository arepository = new ActorRepository();
            arepository.RemoveById(id);
        }

        public CastCrew GetActorById(int id)
        {
            ActorRepository arepository = new ActorRepository();
            return arepository.GetActorById(id);

        }

        public void UpdateActor(CastCrew actor)
        {
            ActorRepository arepository = new ActorRepository();
            arepository.UpdateActor(actor);
        }

        public List<MovieCastCrewDtoModel> GetMovieCastCrewByActorId(int actorId)
        {
            ActorRepository arepository = new ActorRepository();
            return arepository.GetMovieCastCrewByActorId(actorId);
        }
    }
}
