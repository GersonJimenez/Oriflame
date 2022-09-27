using System;
using System.Collections.Generic;

namespace oriflameFinal.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? EmailVerified { get; set; }
        public string? Password { get; set; }
        public string? RememberToken { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Telefono { get; set; }
        public int? IdPuesto { get; set; }
        public string? Estado { get; set; }

        public virtual Puesto? IdPuestoNavigation { get; set; }
    }
}
