using System.Collections.Generic;

namespace ExamenCrud.Models
{
    public class Socio
    {
        public Socio()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
