using DAL.EF;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FilmRepository : GenericRepository<Film>
    {
        public FilmRepository(HomeVideoLibraryContext context) : base (context)
        {
        }
    }
}
