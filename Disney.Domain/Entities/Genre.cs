using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Domain.Entities
{
    public class Genre : EntityBase
    {
        [Required(ErrorMessage = "Nombre del genero requerido")]
        [Column(TypeName = "VARCHAR(500)")]
        public string Name { get; set; }
        public virtual MovieSerie associatedMovieSerie { get; set; }
        public bool Status { get; set; }
    }
}
