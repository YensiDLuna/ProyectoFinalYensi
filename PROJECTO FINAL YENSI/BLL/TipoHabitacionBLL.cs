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
	public class TipoHabitacionBLL
	{
       
            public static bool Guardar(TipoHabitacion tipoHabitacion)
            {
                if (!Existe(tipoHabitacion.TipoHabitacionID))
                    return Insertar(tipoHabitacion);
                else
                    return Modificar(tipoHabitacion);
            }

            private static bool Insertar(TipoHabitacion tipoHabitacion)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.tipoHabitaciones.Add(tipoHabitacion);
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

            private static bool Modificar(TipoHabitacion tipoHabitacion)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Entry(tipoHabitacion).State = EntityState.Modified;
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


            public static TipoHabitacion Buscar(int id)
            {
                Contexto contexto = new Contexto();
                TipoHabitacion tipoHabitacion;


                try
                {
                    tipoHabitacion = contexto.tipoHabitaciones.Find(id);
                }

                catch (Exception)
                {
                    throw;
                }

                finally
                {
                    contexto.Dispose();
                }
                return tipoHabitacion;
            }

            public static List<TipoHabitacion> GetList(Expression<Func<TipoHabitacion, bool>> criterio)
            {

                List<TipoHabitacion> lista = new List<TipoHabitacion>();
                Contexto contexto = new Contexto();

                try
                {
                    lista = contexto.tipoHabitaciones.Where(criterio).ToList();

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
                    encontrado = contexto.tipoHabitaciones.Any(e => e.TipoHabitacionID == id);
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

                    var tipoHabitacion = contexto.tipoHabitaciones.Find(id);

                    if (tipoHabitacion != null)
                    {
                        contexto.tipoHabitaciones.Remove(tipoHabitacion);
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
