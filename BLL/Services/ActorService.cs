using AutoMapper;
using BLL.DTO;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ActorService
    {
        public IUnitOfWork Database { get; set; }

        public ActorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(ActorDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();

            Actor actor = Mapper.Map<ActorDTO, Actor>(dto);

            Database.Actors.Insert(actor);
            Database.Save();
        }

        public List<ActorDTO> GetAll()
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            return Mapper.Map<IEnumerable<Actor>, List<ActorDTO>>(Database.Actors.GetAll());
        }

        public void Delete(ActorDTO dto)
        {
            Database.Actors.Delete(dto.Id);
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
            Actor actor = Mapper.Map<ActorDTO, Actor>(dto);
            Database.Actors.Update(actor);
            Database.Save();
        }
    }
}
