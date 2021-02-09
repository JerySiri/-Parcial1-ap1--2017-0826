using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parcial1_ap1_2017_0826.DAL;
using Parcial1_ap1_2017_0826.Entidades;
namespace Parcial1_ap1_2017_0826.BLL
{
    public class CiudadBLL
    {
        public static bool insertar(Ciudad ciudad)
        {
            bool p = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Ciudad.Add(ciudad);
                p = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return p;
        }

        public static bool modificar(Ciudad ciudad)
        {
            bool p = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(ciudad).State = EntityState.Modified;
                p = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return p;
        }

        public static bool existe(int idciudad)
        {
            bool p = false;
            Contexto contexto = new Contexto();
            try
            {
                p = contexto.Ciudad.Any(c => c.CiudadId == idciudad);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return p;
        }

        public static bool existeNombre(string nombre)
        {
            bool p = false;
            Contexto contexto = new Contexto();
            try
            {
                p = contexto.Ciudad.Any(c => c.Nombre == nombre);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return p;
        }

        public static bool guardar(Ciudad ciudad)
        {
            if (!existe(ciudad.CiudadId))
            {
                return guardar(ciudad);
            }
            else
            {
                return modificar(ciudad);
            }
        }

        public static Ciudad buscar(int idciudad)
        {
            Contexto contexto = new Contexto();
            Ciudad ciudad;

            try
            {
                ciudad = contexto.Ciudad.Find(idciudad);
            }
            catch
            {
                throw;
            }
            {
                contexto.Dispose();
            }

            return ciudad;

        }

        public static bool eliminar(int idciudad)
        {
            bool p = false;
            Contexto contexto = new Contexto();
            Ciudad ciudad;

            ciudad = contexto.Ciudad.Find(idciudad);
            try{
                if (ciudad != null)
                {
                    contexto.Ciudad.Remove(ciudad);
                    p = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return p;


        }
    }
}
