using PROJECTO_FINAL_YENSI.BLL;
using PROJECTO_FINAL_YENSI.Entidades;
using PROJECTO_FINAL_YENSI.UI;
using PROJECTO_FINAL_YENSI.UI.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROJECTO_FINAL_YENSI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	
	
		private void ISButton_Click(object sender, RoutedEventArgs e)
		{
			//new Pantalla_Principal().Show();
		
			string claveHash = Utilidades.getHashSha256(PassTextbox.Password);
			
				Usuario user = UsuarioBLL.BuscarL(UserTextBox.Text,claveHash);

				if (user == null)
				{
				MessageBox.Show("Usuario o contraseña incorrectos", "Error",MessageBoxButton.YesNo);
			}
				else
				{
				new Pantalla_Principal().Show();
					this.Close();
				}
		
		}



	}
	}

