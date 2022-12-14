using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public virtual FilmDTO Film { get; set; }
    }
}
