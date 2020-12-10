using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PROJECTO_FINAL_YENSI.Entidades
{
public	class ReservacionDetalle
	{
		[Key]
		public int Id { get; set; }
		public int ReservacionID { get; set; }
		public int HabitacionID { get; set; }
		public int ClienteID { get; set; }
		public int TiempoDeReserva { get; set; }
		public decimal Precio { get; set; }

		public ReservacionDetalle(int reservacionId, int habitacionID, int clienteID, int tiempoDeReserva,decimal precio)
		{
			ReservacionID = reservacionId;
			HabitacionID = habitacionID;
			ClienteID = clienteID;
			TiempoDeReserva = tiempoDeReserva;
			Precio = precio;
		}
		public ReservacionDetalle()
		{
			ReservacionID = 0;
			HabitacionID = 0;
			ClienteID = 0;
			TiempoDeReserva = 0;
			Precio = 0;
		}
	}
}
