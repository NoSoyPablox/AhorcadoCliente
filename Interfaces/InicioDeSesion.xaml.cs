using AhorcadoCliente.Interfaces;
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

namespace AhorcadoCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class InicioDeSesion : Window
    {
        public InicioDeSesion()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String usuarioIntroducido = tbUsuario.Text;
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                InicioDeSesion inicioDeSesion = new InicioDeSesion();
                inicioDeSesion.tbUsuario.Text = usuarioIntroducido;
                inicioDeSesion.cbIdioma.Text = "Español";
                inicioDeSesion.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                InicioDeSesion inicioDeSesion = new InicioDeSesion();
                inicioDeSesion.tbUsuario.Text = usuarioIntroducido;
                inicioDeSesion.cbIdioma.Text = "English";
                inicioDeSesion.Show();
                this.Close();
            }
        }
    }
}
