using OMDB.DAL;
using OMDB.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDB.DAL
{
    public class TitleRepository : Repository<Title>
    {
        public List<Title> List()
        {
            return Where(x => true);
        }
    }
}
