using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DirectorService
    {
        public IUnitOfWork Database { get; set; }

        public DirectorService(string connectionString)
        {
            Database = new UnitOfWork(connectionString);
        }

        public void Add(DirectorDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Director director = Mapper.Map<DirectorDTO, Director>(dto);

            List<Film> films = new List<Film>();

            foreach (Film film in director.Films)
            {
                Film temp = Database.Films.Find(f => f.Name == film.Name).First();
                films.Add(temp);
            }

            director.Films = films;

            Database.Directors.Insert(director);
            Database.Save();
        }

        public List<DirectorDTO> GetAll()
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<Review, ReviewDTO>();
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            return Mapper.Map<IEnumerable<Director>, List<DirectorDTO>>(Database.Directors.GetAll());
        }

        public List<DirectorDTO> Find(Func<Director, bool> predicate)
        {
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            return Mapper.Map<IEnumerable<Director>, List<DirectorDTO>>(Database.Directors.Find(predicate));
        }

        public void ChangeData(DirectorDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Director director = Mapper.Map<DirectorDTO, Director>(dto);

            Database.Directors.Update(director);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Directors.Delete(id);
            Database.Save();
        }
    }
}
