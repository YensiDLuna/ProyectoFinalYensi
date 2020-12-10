using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PROJECTO_FINAL_YENSI.Entidades
{
	public class Habitacion
	{
		[Key]
		public int HabitacionID { get; set; }
		public int Numero { get; set; }
		public string Tipo { get; set; }
		public decimal Precio { get; set; }
	}
}
