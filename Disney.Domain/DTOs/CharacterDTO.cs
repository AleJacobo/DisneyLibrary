using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Domain.DTOs
{
    public class CharacterDTO
    {
        public string urlImage { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public virtual MovieSerieDTO associatedMovieSerie { get; set; }
        public bool Status { get; set; }
    }
}
