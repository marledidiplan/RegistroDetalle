using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroArticulosP.DALL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RegistroArticulosP.BLL
{
    public class RepositorioBase<T> : IDisposable, Repositorio<T> where T : class
    {
        //variable interna tipo Contexto
        internal Contexto _contexto;

        //Constructor de la clase
        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        //Permite guardar una entidad en la base de datos.
        public bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                {
                    _contexto.SaveChanges();//Cerrando la conexión.
                    paso = true;
                }
                _contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Permite buscar una entidad en la base de datos.
        public virtual T Buscar(int id)
        {
            T entity;
            try
            {
                entity = _contexto.Set<T>().Find(id);
                _contexto.Dispose();//Cerrando la conexión.
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        //Permite eliminar una entidad en la base de datos.
        public bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();//Cerrando la conexión.
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Permite extraer una lista de persona de la base de datp
        
        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
                _contexto.Dispose();//Cerrando la conexión.
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

       
        
        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                _contexto.Dispose();//Cerrando la conexión.
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
