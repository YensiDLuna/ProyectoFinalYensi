using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PROJECTO_FINAL_YENSI.Entidades
{
	 public class Hotel
	{
		[Key]
		public int HotelID { get; set; }
		public string NombreHotel { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
	}
}
