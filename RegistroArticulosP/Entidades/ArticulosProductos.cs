using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroArticulosP.Entidades
{
    public class ArticulosProductos
    {
        [Key]
        public int IdArticulos { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int CantidadCotizada { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }

        public ArticulosProductos()
        {
            IdArticulos = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            CantidadCotizada = 0;
            Precio = 0;
            Existencia = 0;
        }
    }

}
