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
            tbCorreo.IsEnabled = false;
            lbContrasenaActual.Opacity = 0;
            lbNuevaContrasena.Opacity = 0;
            lbRepetirContrasena.Opacity = 0;
            pswcontrasenaActual.Opacity = 0;
            pswNuevaContrasena.Opacity = 0;
            pswRepetirContrasena.Opacity = 0;
            pswNuevaContrasena.IsEnabled= false;
            pswRepetirContrasena.IsEnabled = false;
            pswcontrasenaActual.IsEnabled= false;
            reContrasenas.Opacity = 0;
            imgAlerta.Opacity = 0;
            lbRequerido.Opacity = 0;
        }
        public Player recibirPlayer = new Player();

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

        public void recibirJUgador(PantallaPrincipal.Player player)
        {
            recibirPlayer.IdPlayer = player.IdPlayer;
            recibirPlayer.NamePlayer = player.NamePlayer;
            recibirPlayer.PasswordPlayer = player.PasswordPlayer;
            recibirPlayer.Email = player.Email;
            recibirPlayer.GamesWin = player.GamesWin;
            recibirPlayer.Points = player.Points;
            recibirPlayer.Username = player.Username;
            tbNombre.Text = recibirPlayer.NamePlayer;
            tbCorreo.Text = recibirPlayer.Email;
            tbUsuario.Text = recibirPlayer.Username;
             
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.recibirJUgadorVolver(recibirPlayer);
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
            tbCorreo.IsEnabled = true;
            pswNuevaContrasena.IsEnabled = true;
            pswRepetirContrasena.IsEnabled = true;
            pswcontrasenaActual.IsEnabled = true;
            lbContrasenaActual.Opacity = 1;
            lbNuevaContrasena.Opacity = 1;
            lbRepetirContrasena.Opacity = 1;
            pswcontrasenaActual.Opacity = 1;
            pswNuevaContrasena.Opacity = 1;
            pswRepetirContrasena.Opacity = 1;
            reContrasenas.Opacity = 1;
            imgAlerta.Opacity = 1;
            lbRequerido.Opacity = 1;
            string mensaje = "Si no desea cambiar la contraseña, introduzca la misma contraseña en los tres campos";
            string hola = "Aviso de contraseña";
            MessageBox.Show(mensaje, hola);
        }

        private void btnGuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            int respuesta = 0;
            string password = pswNuevaContrasena.Password.ToString();
            if (pswNuevaContrasena.Password.ToString() == pswRepetirContrasena.Password.ToString())
            {
                if (pswcontrasenaActual.Password.ToString() == recibirPlayer.PasswordPlayer)
                {
                    ServiceReference1.PlayerClient service1 = new ServiceReference1.PlayerClient();
                    respuesta = service1.UpdateDataPlayer(tbNombre.Text, tbCorreo.Text, password, tbUsuario.Text);
                    if (respuesta != 0)
                    {
                        recibirPlayer.Email = tbCorreo.Text;
                        recibirPlayer.NamePlayer = tbNombre.Text;
                        recibirPlayer.PasswordPlayer = password;
                        recibirPlayer.Username = tbUsuario.Text;
                        MessageBox.Show("Actualización exitosa");
                        PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                        pantallaPrincipal.recibirJUgadorVolver(recibirPlayer);
                        pantallaPrincipal.Show();
                        this.Close();   
                    }
                    else 
                    {
                        MessageBox.Show("La actualización no se ha actualizado correctamente, intentelo más tarde");
                        PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                        pantallaPrincipal.recibirJUgadorVolver(recibirPlayer);
                        pantallaPrincipal.Show();
                        this.Close();
                    }
                }
                else {
                    MessageBox.Show("Las contraseñas actual es incorrecta");
                }
            }
            else
            {
                MessageBox.Show("Las contraseña nueva y la confirmación, no coinciden");
            }
        }
    }
}
