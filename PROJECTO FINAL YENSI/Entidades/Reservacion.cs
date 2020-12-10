using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PROJECTO_FINAL_YENSI.Entidades
{
	public class Reservacion
	{
		[Key]
		public int ReservacionID { get; set; }
		public string Hotel { get; set; }
	    public decimal Total { get; set; }
		public int UsuarioID { get; set; }
		

		[ForeignKey("ReservacionID")]
		public List<ReservacionDetalle> reservacionDetalle { get; set; }

		public Reservacion(int reservacionID, string hotel, decimal total, int usuarioID)
		{
			ReservacionID = reservacionID;
			Hotel = hotel;
			Total = total;
			UsuarioID = usuarioID;
			
		}
		public Reservacion()
		{
			ReservacionID = 0;
			Hotel = string.Empty;
			Total = 0;
			UsuarioID = 0;
			reservacionDetalle = new List<ReservacionDetalle>();

		}
	}
}
