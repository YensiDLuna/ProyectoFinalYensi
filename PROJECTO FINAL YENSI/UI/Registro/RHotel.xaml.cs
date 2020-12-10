using PROJECTO_FINAL_YENSI.BLL;
using PROJECTO_FINAL_YENSI.Entidades;
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

namespace PROJECTO_FINAL_YENSI.UI.Registro
{
	/// <summary>
	/// Interaction logic for RHotel.xaml
	/// </summary>
	public partial class RHotel : Window
	{
		Hotel hotel = new Hotel();
		public RHotel()
		{
			InitializeComponent();
			this.DataContext = hotel;
		}
		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = hotel;
		}

		private void Limpiar()
		{
			this.hotel = new Hotel();
			this.DataContext = hotel;

		}

		private bool Validar()
		{
			bool esValido = true;
			if (IDTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Id No es el correcto", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (NombreTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (DireecionTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (TelefonoTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}


			return esValido;
		}

		private void BuscarButton_Clic(object serder, RoutedEventArgs e)
		{
			Hotel encotrado = HotelBLL.Buscar(Utilidades.ToInt(IDTextbox.Text));
			if (encotrado != null)
			{
				this.hotel = encotrado;
				Cargar();
				MessageBox.Show("Exito!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("Hotel No Exite", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void NuevoButton_Click(object serder, RoutedEventArgs e)
		{
			Limpiar();
		}
		private void GuardarButton_Click(object serder, RoutedEventArgs e)
		{

			if (!Validar())
			{
				return;
			}
			var paso = HotelBLL.Guardar(hotel);
			if (paso)
			{
				Limpiar();
				MessageBox.Show("Exito Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Fallo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void EliminarButton_Click(object sender, RoutedEventArgs e)

		{

			if (HotelBLL.Eliminar(Utilidades.ToInt(IDTextbox.Text)))

			{

				Limpiar();

				MessageBox.Show("Eliminado", "EXITO");

			}

			else

			{

				MessageBox.Show("Fallo", "Error");

			}

		}
	}
}
