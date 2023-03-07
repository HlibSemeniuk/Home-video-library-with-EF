using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFilmCrew
    {
         int Id { get; set; }
         string Name { get; set; }
         DateTime Birthdate { get; set; }
         string Country { get; set; }
         string Description { get; set; }

        ICollection<FilmDTO> Films { get; set; }
    }
}
