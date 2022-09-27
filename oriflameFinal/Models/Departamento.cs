using System;
using System.Collections.Generic;

namespace oriflameFinal.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Puestos = new HashSet<Puesto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public string? pruebaCampo { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
