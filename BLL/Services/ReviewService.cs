using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Entitys;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReviewService
    {
        public IUnitOfWork Database { get; set; }

        public ReviewService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void Add(ReviewDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Review review = Mapper.Map<ReviewDTO, Review>(dto);
            
            Database.Reviews.Insert(review);
            Database.Save();
        }

        public List<ReviewDTO> GetAll(int filmID)
        {
            Mapper.CreateMap<Actor, ActorDTO>();
            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<Review, ReviewDTO>();
            Mapper.CreateMap<Director, DirectorDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            Func<Review, bool> filmIDMatch = r => r.FilmID == filmID;

            return Mapper.Map<IEnumerable<Review>, List<ReviewDTO>>(Database.Reviews.Find(filmIDMatch));
        }

        public void Delete(int id)
        {
            Database.Reviews.Delete(id);
            Database.Save();
        }

        public void ChangeData(ReviewDTO dto)
        {
            Mapper.CreateMap<ActorDTO, Actor>();
            Mapper.CreateMap<FilmDTO, Film>();
            Mapper.CreateMap<ReviewDTO, Review>();
            Mapper.CreateMap<DirectorDTO, Director>();
            Mapper.CreateMap<GenreDTO, Genre>();

            Review review = Mapper.Map<ReviewDTO, Review>(dto);

            Database.Reviews.Update(review);
            Database.Save();
        }
    }
}
