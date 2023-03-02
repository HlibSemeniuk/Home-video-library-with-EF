using DAL.EF;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ActorRepository : GenericRepository<Actor>
    {
        public ActorRepository(HomeVideoLibraryContext context) : base(context)
        {
        }

        public override void Update(Actor actor)
        {
            Actor EF = _context.Actors.Find(actor.Id);

            EF.Name = actor.Name;
            EF.Description = actor.Description;
            EF.Birthdate = actor.Birthdate;
            EF.Country = actor.Country;

            for (int i = 0; i < EF.Films.Count; i++)
            {
                if (!actor.Films.ToList().Exists(x => x.Name == EF.Films.ToList()[i].Name))
                {
                    string Name = EF.Films.ToList()[i].Name;
                    EF.Films.Remove(_context.Films.Where(x => x.Name == Name).First());

                    i--; // as Count of films change dynamically
                }
            }

            foreach (Film f in actor.Films)
            {
                EF.Films.Add(_context.Films.Where(x => x.Name == f.Name).First());
            }
        }
    }
}
