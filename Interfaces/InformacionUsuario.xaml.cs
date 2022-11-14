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
    /// Lógica de interacción para InformacionUsuario.xaml
    /// </summary>
    public partial class InformacionUsuario : Window
    {
        public InformacionUsuario()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
            btnGuardarCambios.Opacity = 0;
            btnGuardarCambios.IsEnabled= false;
            tbNombre.IsEnabled= false;
            tbUsuario.IsEnabled= false;
            tbEdad.IsEnabled= false;
            cbEdad.IsEnabled= false;
            pswContraseña.IsEnabled= false;
            pswRepetirContraseña.IsEnabled = false;
            pswcontrasenaActual.IsEnabled= false;
            rbHombre.IsEnabled= false;
            rbMujer.IsEnabled= false;
        }

        private void rbHombre_Checked(object sender, RoutedEventArgs e)
        {
            rbMujer.IsChecked = false;
        }

        private void rbMujer_Checked(object sender, RoutedEventArgs e)
        {
            rbHombre.IsChecked = false;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                InformacionUsuario informacionUsuario = new InformacionUsuario();
                informacionUsuario.cbIdioma.Text = "Español";
                informacionUsuario.Show();
                this.Close();

            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                InformacionUsuario informacionUsuario = new InformacionUsuario();
                informacionUsuario.cbIdioma.Text = "English";
                informacionUsuario.Show();
                this.Close();
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            btnGuardarCambios.Opacity = 1;
            btnGuardarCambios.IsEnabled = true;
            tbNombre.IsEnabled = true;
            tbUsuario.IsEnabled = true;
            tbEdad.IsEnabled = true;
            cbEdad.IsEnabled = true;
            pswContraseña.IsEnabled = true;
            pswRepetirContraseña.IsEnabled = true;
            pswcontrasenaActual.IsEnabled = true;
            rbHombre.IsEnabled = true;
            rbMujer.IsEnabled = true;
        }
    }
}
