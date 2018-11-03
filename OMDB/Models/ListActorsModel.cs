using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMDB.Models
{
    public class ListActorsModel
    {
        public List<CastCrew> People { get; set; }
    }
}