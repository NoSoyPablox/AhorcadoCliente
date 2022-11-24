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
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
        }

        private Player player = new Player();
        private class Player
        {
            public int IdPlayer { get; set; }
            public string NamePlayer { get; set; }
            public string Lastname { get; set; }
            public string Email { get; set; }
            public string PasswordPlayer { get; set; }
            public string Username { get; set; }
            public int Points { get; set; }
            public int GamesWin { get; set; }
            public Nullable<int> IdAvatar { get; set; }
        }
        private void BtnCerrarSesionClick(object sender, RoutedEventArgs e)
        {
            InicioDeSesion inicioDeSesion = new InicioDeSesion();
            inicioDeSesion.Show();
            this.Close();
        }

        private void BtnJugarClick(object sender, RoutedEventArgs e)
        {
            PantallaJugar pantallaJugar = new PantallaJugar();
            pantallaJugar.Show();
            this.Close();
        }

        private void BtnSalirClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbIdiomaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                pantallaPrincipal.cbIdioma.Text = "Español";
                pantallaPrincipal.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                pantallaPrincipal.cbIdioma.Text = "English";
                pantallaPrincipal.Show();
                this.Close();
            }
        }

        private void btnInformacion_Click(object sender, RoutedEventArgs e)
        {
            InformacionUsuario informacionUsuario = new InformacionUsuario();
            informacionUsuario.Show();
            this.Close();
        }
        private void recibirJugador(Player player)
        {
            this.player = player;
        }
    }
}
