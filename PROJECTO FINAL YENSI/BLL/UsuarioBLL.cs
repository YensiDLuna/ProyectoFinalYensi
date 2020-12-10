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
	public class UsuarioBLL
	{
        public static bool Guardar(Usuario usuario)
        {
            if (!Existe(usuario.UsuarioID))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Usuario.Add(usuario);
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

        private static bool Modificar(Usuario usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
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


        public static Usuario Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;


            try
            {
                usuario = contexto.Usuario.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static List<Usuario> GetList(Expression<Func<Usuario, bool>> criterio)
        {

            List<Usuario> lista = new List<Usuario>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuario.Where(criterio).ToList();

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
                encontrado = contexto.Usuario.Any(e => e.UsuarioID == id);
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

        public static Usuario BuscarL(string user, string clave)
        {
            Contexto contexto = new Contexto();
            Usuario usuario;

            try
            {
                usuario = contexto.Usuario.Where(u => u.UserName == user && u.PassWord == clave).FirstOrDefault(); 
            }
            catch
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                var usuario = contexto.Usuario.Find(id);

                if (usuario != null)
                {
                    contexto.Usuario
                        .Remove(usuario);
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
