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
	/// Interaction logic for RHabitacion.xaml
	/// </summary>
	public partial class RHabitacion : Window
	{
		Habitacion habitacion = new Habitacion();
		public RHabitacion()
		{
			InitializeComponent();
			this.DataContext = habitacion;

			Combo_cb.ItemsSource = TipoHabitacionBLL.GetList(p => true);
			Combo_cb.SelectedValuePath = "TipoHabitacionId";
			Combo_cb.DisplayMemberPath = "Tipo";
		}

		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = habitacion;
		}

		private void Limpiar()
		{
			this.habitacion = new Habitacion();
			this.DataContext = habitacion;

		}

		private bool Validar()
		{
			bool esValido = true;
			if (IDTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Id No es el correcto", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (NumeroTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Valor es 0", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (PrecioTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Valor es 0", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			return esValido;
		}

		private void BuscarButton_Clic(object serder, RoutedEventArgs e)
		{
			Habitacion encotrado = HabitacionBLL.Buscar(Utilidades.ToInt(IDTextbox.Text));
			if (encotrado != null)
			{
				this.habitacion = encotrado;
				Cargar();
				MessageBox.Show("Exito!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("Habitacion No Exite", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
			habitacion.Tipo = Combo_cb.Text;
			var paso = HabitacionBLL.Guardar(habitacion);
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

			if (UsuarioBLL.Eliminar(Utilidades.ToInt(IDTextbox.Text)))

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
