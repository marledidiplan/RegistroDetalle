using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroArticulosP.DALL;
using System.Linq.Expressions;
using System.Data.Entity;
using RegistroArticulosP.Entidades;

namespace RegistroArticulosP.BLL

{
    public class CotizacionBLL
    {
        public static bool Guardar(Cotizacion cotizacion)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.cotizacions.Add(cotizacion) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Modificar(Cotizacion cotizacion)
        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
               
                //recorrer el detalle
                foreach (var item in cotizacion.Detalle)
                {
                   
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

               
                contexto.Entry(cotizacion).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }
        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Cotizacion cotizacion = contexto.cotizacions.Find(id);
                contexto.cotizacions.Remove(cotizacion);
                if (contexto.SaveChanges() > 0)
                {

                    paso = true;

                }
                contexto.Dispose();

            }

            catch (Exception)
            {

                throw;

            }

            return paso;
        }
        public static Cotizacion Buscar(int id)
        {

            Cotizacion cotizacion = new Cotizacion();
            Contexto contexto = new Contexto();

            try
            {
                cotizacion = contexto.cotizacions.Find(id);
                //Cargar la lista en este punto porque
                //luego de hacer Dispose() el Contexto 
                //no sera posible leer la lista
                cotizacion.Detalle.Count();
                //Cargar los nombres de las personas y articulos
                foreach (var item in cotizacion.Detalle)
                {
                    //forzando la persona y el articulo a cargarse
                    string m = item.ArticulosProducto.Descripcion;
                    string d = item.Personas.Nombre;
                }
                contexto.Dispose();
            }catch (Exception)
            {

                throw;

            }
            return cotizacion;

        }

        public static List<Cotizacion> GetList(Expression<Func<Cotizacion, bool>> expression)
        {

            List<Cotizacion> Cotizacion = new List<Cotizacion>();
            Contexto contexto = new Contexto();

            try
            {
                Cotizacion = contexto.cotizacions.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
                return Cotizacion;
        }



    }
}
