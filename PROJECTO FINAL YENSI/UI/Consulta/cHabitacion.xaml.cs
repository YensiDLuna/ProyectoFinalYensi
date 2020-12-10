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
	/// Interaction logic for cHabitacion.xaml
	/// </summary>
	public partial class cHabitacion : Window
	{
		public cHabitacion()
		{
			InitializeComponent();
		}

        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Habitacion>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = HabitacionBLL.GetList(p => p.HabitacionID == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:
                        lista = HabitacionBLL.GetList(p => p.Numero == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                    case 2:
                        lista = HabitacionBLL.GetList(p => p.Tipo == CriterioTextBox.Text);
                        break;
                    case 3:
                        lista = HabitacionBLL.GetList(p => p.Precio == Utilidades.ToDecimal( CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                lista = HabitacionBLL.GetList(c => true);
            }
            if (lista == null)
            {
                MessageBox.Show("Proyecto no encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = lista;
        }
    }
}
