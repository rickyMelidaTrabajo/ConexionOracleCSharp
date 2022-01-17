using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ConexionOracle.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public string NRODOCUMENTO { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
    }
}
