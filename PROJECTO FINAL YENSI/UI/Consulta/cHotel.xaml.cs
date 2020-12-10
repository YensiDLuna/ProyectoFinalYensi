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
    /// Interaction logic for cHotel.xaml
    /// </summary>
    public partial class cHotel : Window
    {
        public cHotel()
        {
            InitializeComponent();
        }
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Hotel>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        lista = HotelBLL.GetList(p => p.HotelID == Convert.ToInt32(CriterioTextBox.Text));
                        break;

                    case 1:
                        lista = HotelBLL.GetList(p => p.NombreHotel == CriterioTextBox.Text);
                        break;
                    case 2:
                        lista = HotelBLL.GetList(p => p.Direccion == CriterioTextBox.Text);
                        break;
                    case 3:
                        lista = HotelBLL.GetList(p => p.Telefono == CriterioTextBox.Text);
                        break;
                }
            }


            else
            {
                lista = HotelBLL.GetList(c => true);
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

