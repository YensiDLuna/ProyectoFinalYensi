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
	public class TipoUsuarioBLL
	{
        public static bool Guardar(TipoUsuario tipoUsuario)
        {
            if (!Existe(tipoUsuario.TipoUsuarioID))
                return Insertar(tipoUsuario);
            else
                return Modificar(tipoUsuario);
        }

        private static bool Insertar(TipoUsuario tipoUsuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.tipoUsuarios.Add(tipoUsuario);
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

        private static bool Modificar(TipoUsuario tipoUsuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tipoUsuario).State = EntityState.Modified;
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


        public static TipoUsuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TipoUsuario tipoUsuario;


            try
            {
                tipoUsuario = contexto.tipoUsuarios.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return tipoUsuario;
        }

        public static List<TipoUsuario> GetList(Expression<Func<TipoUsuario, bool>> criterio)
        {

            List<TipoUsuario> lista = new List<TipoUsuario>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.tipoUsuarios.Where(criterio).ToList();

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
                encontrado = contexto.tipoUsuarios.Any(e => e.TipoUsuarioID == id);
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

                var tipoUsuario = contexto.tipoUsuarios.Find(id);

                if (tipoUsuario != null)
                {
                    contexto.tipoUsuarios.Remove(tipoUsuario);
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
