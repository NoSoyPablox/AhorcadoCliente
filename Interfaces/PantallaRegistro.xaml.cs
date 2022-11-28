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
            String AlertLogin = "Registro exitoso";
            String AlertIncorrecto = "No se ha completado el registro de manera exitosa";
            int respuesta = 0;
            ServiceReference1.PlayerClient service = new ServiceReference1.PlayerClient();
            string nombre = tbNombre.Text;
            string usuarname = tbUsuario.Text;
            string email = tbEmail.Text;
            string password = pswContraseña.Password.ToString();
            string passwordRepeat = pswRepetirContraseña.Password.ToString();
            if (nombre != "" && usuarname != "" && email != "" && password != "" && passwordRepeat != "")
            {
                if (password == passwordRepeat)
                {
                    if (password.Length >= 8)
                    {
                        respuesta = service.Register(nombre, email, password, usuarname, 0, 0);
                        if (respuesta != 0)
                        {
                            MessageBox.Show(Properties.Resources.RegisterSuccessful, Properties.Resources.RegisterSuccessfulTittle);
                            tbNombre.Clear();
                            tbUsuario.Clear();
                            tbEmail.Clear();
                            pswContraseña.Clear();
                            pswRepetirContraseña.Clear();
                        }
                        else
                        {
                            MessageBox.Show(Properties.Resources.RegistrationError, Properties.Resources.RegistrationErrorTittle);
                        }
                    }
                    else 
                    {
                        MessageBox.Show(Properties.Resources.LengthPassword, Properties.Resources.LengthPasswordTittle);
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.MatchPassword, Properties.Resources.MatchPasswordTittle);
                }
            }
            else 
            {
                MessageBox.Show(Properties.Resources.Empty, Properties.Resources.EmptyFields);
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
