using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroArticulosP.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set;}
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public Persona()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
        }

    }
}
