using AutoMapper;
using BLL.DTO;
using DAL.EF;
using DAL;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace BLL.Services
{
    public class ActorService
    {
        public IUnitOfWork Database { get; set; }

        public ActorService(string connectionString)
        {
            Database = new UnitOfWork(connectionString);
        }

        public void Add(ActorDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Actor actor = Mapper.Map<ActorDTO, Actor>(dto);

            List<Film> films = new List<Film>();

            foreach (Film film in actor.Films)
            {
                Film temp = Database.Films.Find(f => f.Name == film.Name).First();
                films.Add(temp);
            }

            actor.Films = films;

            Database.Actors.Insert(actor);
            Database.Save();
        }

        public List<ActorDTO> GetAll()
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            return Mapper.Map<IEnumerable<Actor>, List<ActorDTO>>(Database.Actors.GetAll());
        }

        public void Delete(int id)
        {
            Database.Actors.Delete(id);
            Database.Save();
        }

        public List<ActorDTO> Find(Func<Actor, bool> predicate)
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            return Mapper.Map<IEnumerable<Actor>, List<ActorDTO>>(Database.Actors.Find(predicate));
        }

        public void ChangeData(ActorDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Actor actor = Mapper.Map<ActorDTO, Actor>(dto);

            Database.Actors.Update(actor);
            Database.Save();
        }
    }
}
