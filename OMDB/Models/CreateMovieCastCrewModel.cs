using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class CreateMovieCastCrewModel
    {
        public int MovieId { get; set; }
        public int CastCrewId { get; set; }
        public int Title { get; set; }
    }
}