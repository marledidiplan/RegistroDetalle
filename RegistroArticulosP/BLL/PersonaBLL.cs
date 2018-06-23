using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroArticulosP.Entidades;
using RegistroArticulosP.DALL;
using System.Linq.Expressions;

namespace RegistroArticulosP.BLL
{
    public class PersonaBLL
    {
        
        public static bool Guardar(Persona persona)
        {
            bool paso = false;
            //Creamos Una Instancia de Del contexto Para conectarla con la Base de Dato
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.personas.Add(persona) != null)
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
        public static bool Modificar(Persona persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
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

                Persona persona = new Persona();
                persona = contexto.personas.Find(id);
                contexto.personas.Remove(persona);

                if (contexto.SaveChanges() > 0)
                {

                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }
        public static Persona Buscar(int id)
        {

            Contexto contexto = new Contexto();
            Persona persona = new Persona();
            try
            {
                persona = contexto.personas.Find(id);
                contexto.Dispose();



            }
            catch (Exception)
            {
                throw;
            }
            return persona;

        }
        public static List<Persona> GetList(Expression<Func<Persona, bool>> expression)
        {
            List<Persona> persona= new List<Persona>();
            Contexto contexto = new Contexto();
            try
            {
                persona = contexto.personas.Where(expression).ToList();
            }
            catch
            {
                throw;
            }
            return persona;
        }
    }
}
