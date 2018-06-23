using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using RegistroArticulosP.DALL;
namespace RegistroArticulosP.Entidades
{
    public class Cotizacion
    {
        [Key]
        public int IdCotizacion { get; set; }
        public DateTime Fecha  { get; set; }

        [StringLength(100)]
        public string  Comentarios { get; set; }

        public virtual ICollection<CotizacionDetalle> Detalle { get; set; }

        public Cotizacion()
        {
            this.Detalle = new List<CotizacionDetalle>();
        }
        public void AgregarDetalle(int id, int IdCotizacion, int IdArticulos, int IdPersona, int Precio , int Cantidad, int Importe)
        {
            this.Detalle.Add(new CotizacionDetalle(id, IdCotizacion, IdArticulos, IdPersona, Precio, Cantidad, Importe));
        }
    }
}
