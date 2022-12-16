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
    public class DirectorService
    {
        public IUnitOfWork Database { get; set; }

        public DirectorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(DirectorDTO dto)
        {
            Mapper.CreateMap<DirectorDTO, Director>();
            Director director = Mapper.Map<DirectorDTO, Director>(dto);

            Database.Directors.Insert(director);
            Database.Save();
        }
    }
}
