using PROJECTO_FINAL_YENSI.BLL;
using PROJECTO_FINAL_YENSI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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
	/// Interaction logic for RReservacion.xaml
	/// </summary>
	public partial class RReservacion : Window
	{
		Reservacion reservacion;
	//	Usuario usuario;
	    ReservacionDetalle detalle;
		public RReservacion()
		{
			InitializeComponent();
			reservacion = new Reservacion();
			DataContext = reservacion;
			Combo_cb.ItemsSource = ClienteBLL.GetList(c => true);
			Combo_cb.SelectedValuePath = "ClienteID";
			Combo_cb.DisplayMemberPath = "ClienteID";

			Combo_cb2.ItemsSource = HabitacionBLL.GetList(H => true);
			Combo_cb2.SelectedValuePath = "HabitacionID";
			Combo_cb2.DisplayMemberPath = "HabitacionID";
			reservacion.UsuarioID = 1;
			reservacion.Hotel = "El Paraiso";

			UsuarioTextbox.Text = 1.ToString();
		}

		public void Limpiar()
		{
			//reservacion = new Reservacion() { UsuarioID = usuario.UsuarioID };
			DataContext = reservacion;
			DetalleDataGrid.ItemsSource = new List<ReservacionDetalle>();
		}

	

		public bool Existe()
		{
			var proyecto = ReservacionBLL.Buscar(Convert.ToInt32(IDTextbox.Text));

			return proyecto != null;
		}

		public void GuardarButton_Click(object sender, RoutedEventArgs e)
		{
			bool guardado = false;

			


			if (string.IsNullOrWhiteSpace(IDTextbox.Text) || IDTextbox.Text == "0")
				guardado = ReservacionBLL.Guardar(reservacion);
			else
			{
				if (!Existe())
				{
					MessageBox.Show("No se pudede modificar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				guardado = ReservacionBLL.Modificar(reservacion);
			}

			if (guardado)
			{
				Limpiar();
				MessageBox.Show("Exito.", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("No se puede guardar.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

			}
		}

		    public void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Reservacion anterior = ReservacionBLL.Buscar(Convert.ToInt32(IDTextbox.Text));

            if (anterior != null)
            {
                this.reservacion = anterior;
                this.DataContext = null;
                this.DataContext = reservacion;
				
				MessageBox.Show("Exito!!");
            }
            else
            {
                MessageBox.Show("No existe.");
            }
        }
		public void EliminarButton_Click(object sender, RoutedEventArgs e)
		{
			Reservacion existe = ReservacionBLL.Buscar(this.reservacion.ReservacionID);

			if (existe == null)
			{
				MessageBox.Show("Proyecto no encontrado", "Fallo",
					MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			else
			{
				ReservacionBLL.Eliminar(this.reservacion.ReservacionID);
				MessageBox.Show("Eliminado", "Exito",
					MessageBoxButton.OK, MessageBoxImage.Information);
				Limpiar();
			}
		}
		private void NuevoButton_Click(object sender, RoutedEventArgs e)
		{
			Limpiar();
		}
		private void AgregarButton_Click(object sender, RoutedEventArgs e)
		{
	 	reservacion.Total+= Convert.ToDecimal(Precio.Text);
			 reservacion.reservacionDetalle.Add(new ReservacionDetalle(reservacion.ReservacionID, Utilidades.ToInt(Combo_cb2.SelectedValue.ToString()), Utilidades.ToInt(Combo_cb.SelectedValue.ToString()), Utilidades.ToInt(TiempoTextbox.Text), Utilidades.ToDecimal(Precio.Text)));
			this.DataContext = null;
			this.DataContext = reservacion;

        }

		private void TotalTextbox_TextChanged(object sender, RoutedEventArgs e)
		{
			try
			{
				if (TotalTextbox.Text.Any(char.IsLetter))
				{
					TotalTextbox.BorderBrush = new SolidColorBrush(Colors.Red);
					MessageBox.Show("En el tiempo solo debe ingresar numeros", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					TotalTextbox.BorderBrush = new SolidColorBrush(Colors.Yellow);
				}
			}
			catch
			{
				TotalTextbox.Foreground = SystemColors.ControlTextBrush;
			}
		}

		private void RemoverButton_Click(object sender, RoutedEventArgs e)
		{

			if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
			{
				ReservacionDetalle project = (ReservacionDetalle)DetalleDataGrid.SelectedValue;

				reservacion.reservacionDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
				this.DataContext = null;
				this.DataContext = reservacion;
			}


		}



	}
}
