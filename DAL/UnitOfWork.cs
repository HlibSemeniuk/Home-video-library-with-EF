using DAL.EF;
using DAL.Entitys;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HomeVideoLibraryContext _context;

        private ActorRepository actorRepository;
        private DirectorRepository directorRepository;
        private FilmRepository filmRepository;
        private GenreRepository genreRepository;
        private ReviewRepository reviewRepository;

        public IGenericRepository<Actor> Actors
        {
            get
            {
                if (actorRepository == null)
                    actorRepository = new ActorRepository(_context);
                return actorRepository;
            }
        }

        public IGenericRepository<Director> Directors
        {
            get
            {
                if (directorRepository == null)
                    directorRepository = new DirectorRepository(_context);
                return directorRepository;
            }
        }

        public IGenericRepository<Film> Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(_context);
                return filmRepository;
            }
        }

        public IGenericRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(_context);
                return genreRepository;
            }
        }

        public IGenericRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(_context);
                return reviewRepository;
            }
        }

        public UnitOfWork(HomeVideoLibraryContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
