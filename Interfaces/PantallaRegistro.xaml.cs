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
using System.Windows.Shapes;

namespace AhorcadoCliente.Interfaces
{
    /// <summary>
    /// Lógica de interacción para PantallaRegistro.xaml
    /// </summary>
    public partial class PantallaRegistro : Window
    {
        public PantallaRegistro()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
        }

        private void rbHombre_Checked(object sender, RoutedEventArgs e)
        {
            rbMujer.IsChecked = false;
        }

        private void rbMujer_Checked(object sender, RoutedEventArgs e)
        {
            rbHombre.IsChecked = false;
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                PantallaRegistro pantallaRegistro = new PantallaRegistro();
                pantallaRegistro.cbIdioma.Text = "Español";
                pantallaRegistro.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                PantallaRegistro pantallaRegistro = new PantallaRegistro();
                pantallaRegistro.cbIdioma.Text = "English";
                pantallaRegistro.Show();
                this.Close();
            }
        }

        private void btnRegistrarme_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(pswContraseña.Password.ToString());
            if (pswContraseña.Password.ToString() == pswRepetirContraseña.Password.ToString())
            {
                Console.WriteLine("Si coincide");
                
            }
            else
            {
                Console.WriteLine("No coincide man :C");
                
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            InicioDeSesion inicioDeSesion = new InicioDeSesion();
            inicioDeSesion.Show();
            this.Close();
        }
    }
}
