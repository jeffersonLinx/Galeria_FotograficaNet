using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriaFotografica.Entidades
{ //clase publica
    public class clsUsuarioBE
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Salt { get; set; }
        // 
        public string Telefono { get; set; }
        public string Cedula {  get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; } // Agregar la propiedad Rol
    }
}
