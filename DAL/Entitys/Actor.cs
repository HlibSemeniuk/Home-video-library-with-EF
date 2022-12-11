using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Film> Films { get; set; }

    }
}
