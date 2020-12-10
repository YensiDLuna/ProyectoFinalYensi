using PROJECTO_FINAL_YENSI.UI.Consulta;
using PROJECTO_FINAL_YENSI.UI.Registro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROJECTO_FINAL_YENSI.UI
{
	/// <summary>
	/// Interaction logic for Pantalla_Principal.xaml
	/// </summary>
	public partial class Pantalla_Principal : Window
	{
		public Pantalla_Principal()
		{
			InitializeComponent();
		}

		private void ReservacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RReservacion rr = new RReservacion();

			rr.Show();

		}
		private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RUsuario ru = new RUsuario();

			ru.Show();

		}

		private void ClienteMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RCliente rc = new RCliente();

			rc.Show();

		}

		private void HabitacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RHabitacion rh = new RHabitacion();

			rh.Show();

		}

		private void HotelMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RHotel rh = new RHotel();

			rh.Show();

		}
		private void TipoHabitacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RTipoHabitacion rt = new RTipoHabitacion();

			rt.Show();

		}

		private void TipoUsuarioMenuItem_Click(object sender, RoutedEventArgs e)

		{

			RTipoUsuario rt = new RTipoUsuario();

			rt.Show();

		}
		//Consulta

		private void cReservacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cReservacion cr = new cReservacion();

			cr.Show();

		}
		private void cUsuarioMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cUsuario cu = new cUsuario();

			cu.Show();

		}

		private void cClienteMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cCliente cc = new cCliente();

			cc.Show();

		}

		private void cHabitacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cHabitacion ch = new cHabitacion();

			ch.Show();

		}

		private void cHotelMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cHotel ch = new cHotel();

			ch.Show();

		}
		private void cTipoHabitacionMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cTipoHabitacion ct = new cTipoHabitacion();

			ct.Show();

		}

		private void cTipoUsuarioMenuItem_Click(object sender, RoutedEventArgs e)

		{

			cTipoUsuario ct = new cTipoUsuario();

			ct.Show();

		}
	}
}
