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
	public class HotelBLL
	{
        public static bool Guardar(Hotel hotel)
        {
            if (!Existe(hotel.HotelID))
                return Insertar(hotel);
            else
                return Modificar(hotel);
        }

        private static bool Insertar(Hotel hotel)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Hotel.Add(hotel);
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

        private static bool Modificar(Hotel hotel)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(hotel).State = EntityState.Modified;
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


        public static Hotel Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Hotel hotel;


            try
            {
                hotel = contexto.Hotel.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return hotel;
        }

        public static List<Hotel> GetList(Expression<Func<Hotel, bool>> criterio)
        {

            List<Hotel> lista = new List<Hotel>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Hotel.Where(criterio).ToList();

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
                encontrado = contexto.Hotel.Any(e => e.HotelID == id);
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

                var vehiculos = contexto.Hotel.Find(id);

                if (vehiculos != null)
                {
                    contexto.Hotel.Remove(vehiculos);
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
