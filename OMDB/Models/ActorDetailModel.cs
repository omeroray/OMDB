using OMDB.DAL.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class ActorDetailModel
    {
        public string ProfilePictureFileName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime BirthDate { get; set; }
        public List<MovieCastCrewDtoModel> Movies { get; set; }
    }
}