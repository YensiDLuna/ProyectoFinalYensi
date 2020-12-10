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
	/// Interaction logic for RUsuario.xaml
	/// </summary>
	public partial class RUsuario : Window
	{
		Usuario usuario = new Usuario();
		public RUsuario()
		{
			InitializeComponent();
			this.DataContext = usuario;
			Combo_cb.ItemsSource = TipoUsuarioBLL.GetList(p => true);
			Combo_cb.SelectedValuePath = "TipoUsuarioId";
			Combo_cb.DisplayMemberPath = "Tipo";
		}
		private void Cargar()
		{
			this.DataContext = null;
			this.DataContext = usuario;
			
			PassStackPanel.Visibility = Visibility.Hidden;
			PassConfStackPanel.Visibility = Visibility.Hidden;
		}

		private void Limpiar()
		{
			this.usuario = new Usuario();
			this.DataContext = usuario;
			PasswordTextBox.Password = null;
			PasswordConfTextBox.Password = null;

		}
		private bool Validar()
		{
			bool esValido = true;
			if (IDTextBox.Text.Length <= 0)
			{
				esValido = false;
				MessageBox.Show("Id No es el correcto", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (NombreTextBox.Text.Length == 0)
			{
				esValido = false;
				MessageBox.Show("Campo Vacio", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			if (PasswordTextBox.Password.ToString() != PasswordConfTextBox.Password.ToString())
			{
				esValido = false;
				MessageBox.Show("Contraseña Diferente", "fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			return esValido;
		}

		private void BuscarButton_Clic(object serder, RoutedEventArgs e)
		{
			Usuario encotrado = UsuarioBLL.Buscar(Utilidades.ToInt(IDTextBox.Text));
			if (encotrado != null)
			{
				
				this.usuario = encotrado;
				Cargar();
				MessageBox.Show("Exito!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				Limpiar();
				MessageBox.Show("Usuario No Exite", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
			usuario.PassWord = Utilidades.getHashSha256(PasswordTextBox.Password.Trim());
			usuario.TipoUsuario = Combo_cb.Text; 
			var paso = UsuarioBLL.Guardar(usuario);
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

			if (UsuarioBLL.Eliminar(Utilidades.ToInt(IDTextBox.Text)))

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
