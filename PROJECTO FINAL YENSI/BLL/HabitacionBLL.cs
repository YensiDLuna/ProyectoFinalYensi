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
	public class HabitacionBLL
	{
        public static bool Guardar(Habitacion habitacion)
        {
            if (!Existe(habitacion.HabitacionID))
                return Insertar(habitacion);
            else
                return Modificar(habitacion);
        }

        private static bool Insertar(Habitacion habitacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Habitaciones.Add(habitacion);
                paso = contexto.SaveChanges() > 0;
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Habitacion habitacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(habitacion).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }

            catch (Exception)
            {
                throw;

            }

            finally
            {
                contexto.Dispose();
            }

            return paso;

        }


        public static Habitacion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Habitacion habitacion;


            try
            {
                habitacion = contexto.Habitaciones.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return habitacion;
        }

        public static List<Habitacion> GetList(Expression<Func<Habitacion, bool>> criterio)
        {

            List<Habitacion> lista = new List<Habitacion>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Habitaciones.Where(criterio).ToList();

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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Habitaciones.Any(e => e.HabitacionID == id);
            }

            catch (Exception)
            {
                throw;

            }

            finally
            {

                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                var habitacion = contexto.Habitaciones.Find(id);

                if (habitacion != null)
                {
                    contexto.Habitaciones.Remove(habitacion);
                    paso = contexto.SaveChanges() > 0;

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

            return paso;

        }
    }
}
