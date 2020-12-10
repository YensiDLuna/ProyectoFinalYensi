using Microsoft.EntityFrameworkCore;
using PROJECTO_FINAL_YENSI.DAL;
using PROJECTO_FINAL_YENSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PROJECTO_FINAL_YENSI.BLL
{
	 public class ReservacionBLL
	{
        public static bool Guardar(Reservacion proyecto)
        {
            bool guardado = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Reservaciones.Add(proyecto) != null)
                {
                    guardado = contexto.SaveChanges() > 0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return guardado;
        }

        public static bool Modificar(Reservacion reservacion)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete from ReservacionDetalle where ReservacionID = {reservacion.ReservacionID}");
                foreach (var anterior in reservacion.reservacionDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(reservacion).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        public static bool Eliminar(int Id)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Reservaciones.Find(Id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                eliminado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static Reservacion Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Reservacion reservacion = new Reservacion();

            try
            {
                reservacion = contexto.Reservaciones.Include(x => x.reservacionDetalle).Where(p => p.ReservacionID == Id).SingleOrDefault();

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return reservacion;
        }

        public static List<Reservacion> GetList(Expression<Func<Reservacion, bool>> Proyecto)
        {
            List<Reservacion> lista = new List<Reservacion>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Reservaciones.Where(Proyecto).AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
