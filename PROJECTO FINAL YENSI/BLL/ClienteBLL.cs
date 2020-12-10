
using Microsoft.EntityFrameworkCore;
using PROJECTO_FINAL_YENSI.DAL;
using PROJECTO_FINAL_YENSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace PROJECTO_FINAL_YENSI.BLL
{
	public class ClienteBLL
	{
        public static bool Guardar(Cliente cliente)
        {
            if (!Existe(cliente.ClienteID))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        private static bool Insertar(Cliente cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Clientes.Add(cliente);
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

        private static bool Modificar(Cliente cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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


        public static Cliente Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cliente cliente;


            try
            {
				cliente = contexto.Clientes.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }

        public static List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
        {

            List<Cliente> lista = new List<Cliente>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();

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
				encontrado = contexto.Clientes.Any(e => e.ClienteID == id);
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

                var cliente = contexto.Clientes.Find(id);

                if (cliente != null)
                {
                    contexto.Clientes
                        .Remove(cliente);
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
