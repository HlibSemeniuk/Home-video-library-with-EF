using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface  IGenericService<T, DTOEntity> 
    {
        IUnitOfWork Database { get; set; }
        void Add(DTOEntity entity);
        DTOEntity Get(int id);
        void ChangeData(DTOEntity entity);
    }
}
