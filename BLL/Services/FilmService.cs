using AutoMapper;
using BLL.DTO;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FilmService
    {
        public IUnitOfWork Database { get; set; }

        public FilmService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(FilmDTO dto)
        {
            Mapper.CreateMap<FilmDTO, Film>();

            Database.Films.Insert(Mapper.Map<FilmDTO, Film>(dto));
            Database.Save();
        }

        public List<FilmDTO> GetAll()
        {
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Review, ReviewDTO>();

            return Mapper.Map<IEnumerable<Film>, List<FilmDTO>>(Database.Films.GetAll());
        }

        public void Delete(FilmDTO dto)
        {
            Database.Films.Delete(dto.ID);
            Database.Save();
        }

        public List<FilmDTO> Find(Func<Film, bool> predicate)
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Review, ReviewDTO>();

            return Mapper.Map<IEnumerable<Film>, List<FilmDTO>>(Database.Films.Find(predicate));
        }

        public void ChangeData(FilmDTO dto)
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Review, ReviewDTO>();

            
            Database.Films.Update(Mapper.Map<FilmDTO, Film>(dto);
            Database.Save();
        }
    }
}
