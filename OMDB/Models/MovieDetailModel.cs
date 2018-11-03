using OMDB.DAL.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class MovieDetailModel
    {
        public string PosterFileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public List<MovieCastCrewDtoModel> Actors { get; set; }
    }
}