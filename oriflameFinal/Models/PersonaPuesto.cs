using System;
using System.Collections.Generic;

namespace oriflameFinal.Models
{
    public partial class PersonaPuesto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPuesto { get; set; }

        public virtual Puesto? IdPuestoNavigation { get; set; }
    }
}