﻿using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ActorDTO : INameable, IFilmCrew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FilmDTO> Films { get; set; } = new List<FilmDTO>();
    }
}
