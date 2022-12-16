using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //TO DO:
        //Додати Find

        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Save();
    }
}
