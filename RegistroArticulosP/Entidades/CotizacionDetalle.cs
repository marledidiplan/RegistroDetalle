using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RegistroArticulosP.Entidades
{
   public  class CotizacionDetalle
    {
        [Key]
        public int Id { get; set; }
        public int IdCotizacion { get; set; }
        public int IdArticulos { get; set; }
        public int IdPersona { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("IdArticulos")]
        public virtual ArticulosProductos ArticulosProducto { get; set; }

        [ForeignKey("IdPersona")]
        public virtual Persona Personas { get; set; }

        public CotizacionDetalle()
        {
            this.Id = 0;
            this.IdCotizacion = 0;

        }

        public CotizacionDetalle(int id , int idCotizacion, int idArticulos, int idPersona,int precio, int cantidad, int importe)
        {
            this.Id = id;
            this.IdCotizacion = IdCotizacion;
            this.IdPersona = idPersona;
            this.IdArticulos = idArticulos;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }
       
    }
}
