using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Country { get; set; }
        public decimal Budget { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public ICollection<Director> Directors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
