using DAL.EF;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository : GenericRepository<Genre>
    {
        public GenreRepository(HomeVideoLibraryContext context) : base(context)
        {
        }
    }
}
