using System;
using System.Collections.Generic;

namespace oriflameFinal.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            InverseIdJerarquiaNavigation = new HashSet<Puesto>();
            Personas = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdJerarquia { get; set; }
        public string? Estado { get; set; }
        public int? IdDepartamento { get; set; }

        public virtual Departamento? IdDepartamentoNavigation { get; set; }
        public virtual Puesto? IdJerarquiaNavigation { get; set; }
        public virtual ICollection<Puesto> InverseIdJerarquiaNavigation { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
