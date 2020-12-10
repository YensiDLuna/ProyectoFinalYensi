using Microsoft.EntityFrameworkCore;
using PROJECTO_FINAL_YENSI.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECTO_FINAL_YENSI.DAL
{
	public class Contexto : DbContext
	{
		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Reservacion> Reservaciones { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<TipoHabitacion> tipoHabitaciones { get; set; }
		public DbSet<TipoUsuario> tipoUsuarios { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Habitacion> Habitaciones { get; set; }
	

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source = Data\ProyectoFinal.db");
		}
	}
}
