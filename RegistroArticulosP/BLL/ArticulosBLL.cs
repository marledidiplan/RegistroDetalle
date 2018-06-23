using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroArticulosP.Entidades;
using System.Data.Entity;
using RegistroArticulosP.DALL;
using System.Linq.Expressions;

namespace RegistroArticulosP.BLL

{
    public class ArticulosBLL
    {
        public static bool Guardar(ArticulosProductos articulosProducto)
        {
            bool paso = false;
            
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.ArticulosP.Add(articulosProducto) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Modificar(ArticulosProductos articulosProducto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulosProducto).State = EntityState.Modified;
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
                ArticulosProductos articulosProducto = new ArticulosProductos();
                contexto.ArticulosP.Remove(articulosProducto);

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
        public static ArticulosProductos Buscar(int id)
        {

            Contexto contexto = new Contexto();
            ArticulosProductos articulosProducto = new ArticulosProductos();

            try
            {
                articulosProducto = contexto.ArticulosP.Find(id);
                contexto.Dispose();



            }
            catch (Exception)
            {
                throw;
            }
            return articulosProducto;

        }
        public static List<ArticulosProductos> GetList(Expression<Func<ArticulosProductos, bool>> expression)
        {
            List<ArticulosProductos> articulosProductos = new List<ArticulosProductos>();
            Contexto contexto = new Contexto();
            try
            {
                articulosProductos = contexto.ArticulosP.Where(expression).ToList();
            }
            catch
            {
                throw;
            }
            return articulosProductos;
        }


    }
}
