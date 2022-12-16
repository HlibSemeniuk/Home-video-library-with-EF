using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (HomeVideoLibraryContext context = new HomeVideoLibraryContext())
            {
                IUnitOfWork uow = new UnitOfWork(context);
                ActorService actorService = new ActorService(uow);

               /* List<ActorDTO> actors = actorService.GetAll();

                foreach (ActorDTO actor in actors)
                {
                    Console.WriteLine(actor.Name);
                }*/
                actorService.Delete(new ActorDTO() {Id = 2, Name = "Test", Birthdate = new DateTime(1990, 07, 23), Country = "Україна", Description = "..." });
            }
           
        }

    }
}
