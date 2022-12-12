using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Film> Films { get; }
        IGenericRepository<Actor> Actors { get; }
        IGenericRepository<Director> Directors { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Review> Reviews { get; }

        void Save();
    }
}
