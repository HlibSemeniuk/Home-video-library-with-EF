﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public virtual int FilmID { get; set; }
        public virtual Film Film { get; set; }
    }
}
