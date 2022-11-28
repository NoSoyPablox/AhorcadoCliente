using AhorcadoCliente.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
        public class Player
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

        private void BtnSalirClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnIniciarSesionClick(object sender, RoutedEventArgs e)
        {
            ServiceReference1.PlayerClient service1 = new ServiceReference1.PlayerClient();
            String correo = tbCorreo.Text;
            String password = pswContraseña.Password.ToString();
            bool respuesta;
            if (correo != "" && password != "")
            {
                respuesta = service1.Login(correo, password);
                if (respuesta == true)
                {
                    Player playerRecibido = new Player();
                    playerRecibido.NamePlayer = service1.recuperarNombreJugador(correo, password);
                    playerRecibido.IdPlayer = service1.recuperarIdPlayer(correo, password);
                    playerRecibido.Username = service1.recuperarUsername(correo, password);
                    playerRecibido.Points = service1.recuperarPoints(correo, password);
                    playerRecibido.GamesWin = service1.recuperarGamesWin(correo, password);
                    playerRecibido.Email = correo;
                    playerRecibido.PasswordPlayer = password;
                    PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                    pantallaPrincipal.recibirJUgador(playerRecibido);
                    pantallaPrincipal.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.WrongField, Properties.Resources.WrongFieldTittle);
                }
            }
            else 
            {
                MessageBox.Show(Properties.Resources.Empty, Properties.Resources.EmptyFields);
            }

        }

        private void CbIdiomaSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String usuarioIntroducido = tbCorreo.Text;
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                InicioDeSesion inicioDeSesion = new InicioDeSesion();
                inicioDeSesion.tbCorreo.Text = usuarioIntroducido;
                inicioDeSesion.cbIdioma.Text = "Español";
                inicioDeSesion.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                InicioDeSesion inicioDeSesion = new InicioDeSesion();
                inicioDeSesion.tbCorreo.Text = usuarioIntroducido;
                inicioDeSesion.cbIdioma.Text = "English";
                inicioDeSesion.Show();
                this.Close();
            }
        }

        private void btnRegistrarmeClick(object sender, RoutedEventArgs e)
        {
            PantallaRegistro pantallaRegistro = new PantallaRegistro();
            pantallaRegistro.Show();
            this.Close();
        }

        private void pswContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                pantallaPrincipal.Show();
                this.Close();
            }
        }

        private void btnJugarInvitado_Click(object sender, RoutedEventArgs e)
        {
            JugarComoInvitado jugarComoInvitado = new JugarComoInvitado();
            jugarComoInvitado.Show();
            this.Close();

        }
    }
}
