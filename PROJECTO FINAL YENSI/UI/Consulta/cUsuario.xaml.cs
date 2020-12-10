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

namespace PROJECTO_FINAL_YENSI.UI.Consulta
{
	/// <summary>
	/// Interaction logic for cUsuario.xaml
	/// </summary>
	public partial class cUsuario : Window
	{
		public cUsuario()
		{
			InitializeComponent();
		}
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Usuario>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = UsuarioBLL.GetList(p => p.UsuarioID == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:
                        lista = UsuarioBLL.GetList(p => p.Nombre == CriterioTextBox.Text);
                        break;
                    case 2:
                        lista = UsuarioBLL.GetList(p => p.UserName == CriterioTextBox.Text);
                        break;
                  
                        case 3:
                        lista = UsuarioBLL.GetList(p => p.TipoUsuario == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                lista = UsuarioBLL.GetList(c => true);
            }
            if (lista == null)
            {
                MessageBox.Show("No encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}
