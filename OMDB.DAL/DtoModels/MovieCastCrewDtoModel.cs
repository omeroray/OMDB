using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL.DtoModels
{
    public class MovieCastCrewDtoModel
    {
        public int RelationId { get; set; }
        public Movie Movie { get; set; }
        public CastCrew Actor { get; set; }
        public Title Title { get; set; }
    }
}
