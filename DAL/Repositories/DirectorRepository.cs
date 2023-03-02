using DAL.EF;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DirectorRepository : GenericRepository<Director>
    {
        public DirectorRepository(HomeVideoLibraryContext context) : base(context)
        {
        }

        public override void Update(Director director)
        {
            Director EF = _context.Directors.Find(director.ID);

            EF.Name = director.Name;
            EF.Description = director.Description;
            EF.Birthdate = director.Birthdate;
            EF.Country = director.Country;

            for (int i = 0; i < EF.Films.Count; i++)
            {
                if (!director.Films.ToList().Exists(x => x.Name == EF.Films.ToList()[i].Name))
                {
                    string Name = EF.Films.ToList()[i].Name;
                    EF.Films.Remove(_context.Films.Where(x => x.Name == Name).First());

                    i--; // as Count of films change dynamically
                }
            }

            foreach (Film f in director.Films)
            {
                EF.Films.Add(_context.Films.Where(x => x.Name == f.Name).First());
            }
        }
    }
}
