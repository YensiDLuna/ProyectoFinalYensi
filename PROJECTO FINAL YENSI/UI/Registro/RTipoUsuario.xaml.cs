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
	/// Interaction logic for RTipoUsuario.xaml
	/// </summary>
	public partial class RTipoUsuario : Window
	{
		TipoUsuario tipoUsuario = new TipoUsuario();
		public RTipoUsuario()
		{
			InitializeComponent();
			this.DataContext = tipoUsuario;
		}
		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = tipoUsuario;
		}

		private void Limpiar()
		{
			this.tipoUsuario = new TipoUsuario();
			this.DataContext = tipoUsuario;

		}
		private bool Validar()
		{
			bool esValido = true;
			if (IdTextBox.Text.Length <= 0)
			{
				esValido = false;
				MessageBox.Show("Id No es el correcto", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (TipoUTextbox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		
			return esValido;
		}

		private void BuscarButton_Clic(object serder, RoutedEventArgs e)
		{
			TipoUsuario encotrado = TipoUsuarioBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));
			if (encotrado != null)
			{
				this.tipoUsuario = encotrado;
				Cargar();
				MessageBox.Show("Exito!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("Tipo Usuario No Exite", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
			var paso = TipoUsuarioBLL.Guardar(tipoUsuario);
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

			if (TipoUsuarioBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))

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
