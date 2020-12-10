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
	/// Interaction logic for cReservacion.xaml
	/// </summary>
	public partial class cReservacion : Window
	{
		public cReservacion()
		{
			InitializeComponent();
		}

        private void BuscarButton_Click(object sender, RoutedEventArgs e)

        {

            var listado = new List<Reservacion>();

            if (CriterioTextBox.Text.Trim().Length > 0)

            {

                switch (FiltroComboBox.SelectedIndex)

                {

                    case 0:

                        listado = ReservacionBLL.GetList(e => e.ReservacionID == Utilidades.ToInt(CriterioTextBox.Text));

                        break;



                    case 1:

                        listado = ReservacionBLL.GetList(e => e.UsuarioID == Utilidades.ToInt(CriterioTextBox.Text));

                        break;

                }







            }

            else

            {

                listado = ReservacionBLL.GetList(c => true);

            }



            DatosDataGrid.ItemsSource = null;

            DatosDataGrid.ItemsSource = listado;

        }
    }
}
