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
    /// Lógica de interacción para JugarComoInvitado.xaml
    /// </summary>
    public partial class JugarComoInvitado : Window
    {
        public JugarComoInvitado()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
        }

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

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            InicioDeSesion inicioDeSesion = new InicioDeSesion();
            inicioDeSesion.Show();
            this.Close();
        }

        private void CbIdiomaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                JugarComoInvitado jugarComoInvitado = new JugarComoInvitado();
                jugarComoInvitado.cbIdioma.Text = "Español";
                jugarComoInvitado.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                JugarComoInvitado jugarComoInvitado = new JugarComoInvitado();
                jugarComoInvitado.cbIdioma.Text = "English";
                jugarComoInvitado.Show();
                this.Close();
            }
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbUsuario.Text))
            {
                PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                Player player = new Player();
                player.Username = tbUsuario.Text;
                //pantallaPrincipal.recibirJugador();
                pantallaPrincipal.Show();
                this.Close();
            }
            else
            {

            }
        }
    }
}
