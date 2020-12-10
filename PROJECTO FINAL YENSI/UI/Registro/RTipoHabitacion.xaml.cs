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
	/// Interaction logic for RTipoHabitacion.xaml
	/// </summary>
	public partial class RTipoHabitacion : Window
	{
		TipoHabitacion tipoHabitacion = new TipoHabitacion();
		public RTipoHabitacion()
		{
			InitializeComponent();
			this.DataContext = tipoHabitacion;
		}
		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = tipoHabitacion;
		}

		private void Limpiar()
		{
			this.tipoHabitacion = new TipoHabitacion();
			this.DataContext = tipoHabitacion;

		}

		private bool Validar()
		{
			bool esValido = true;
			if (IDTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Id No es el correcto", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (TipoTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			
			return esValido;
		}
		private void BuscarButton_Clic(object serder, RoutedEventArgs e)
		{
			TipoHabitacion encotrado = TipoHabitacionBLL.Buscar(Utilidades.ToInt(IDTextBox.Text));
			if (encotrado != null)
			{
				this.tipoHabitacion = encotrado;
				Cargar();
				MessageBox.Show("Exito!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("Tipo de Habitacion No Exite", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
			var paso = TipoHabitacionBLL.Guardar(tipoHabitacion);
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

			if (TipoHabitacionBLL.Eliminar(Utilidades.ToInt(IDTextBox.Text)))

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
