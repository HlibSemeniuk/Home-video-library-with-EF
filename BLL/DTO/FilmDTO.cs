using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class FilmDTO : INameable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public decimal Budget { get; set; }

        public virtual ICollection<ActorDTO> Actors { get; set; } = new List<ActorDTO>();

        public virtual ICollection<DirectorDTO> Directors { get; set; } = new List<DirectorDTO>();

        public virtual ICollection<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
        public virtual ICollection<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
    }
}
