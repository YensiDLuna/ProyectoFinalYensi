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
	/// Interaction logic for cTipoHabitacion.xaml
	/// </summary>
	public partial class cTipoHabitacion : Window
	{
		public cTipoHabitacion()
		{
			InitializeComponent();
		}
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<TipoHabitacion>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = TipoHabitacionBLL.GetList(p => p.TipoHabitacionID == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:
                        lista = TipoHabitacionBLL.GetList(p => p.Tipo == CriterioTextBox.Text);
                        break;
                }
            }
            else
            {
                lista = TipoHabitacionBLL.GetList(c => true);
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

