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
            int respuesta = 0;
            ServiceReference1.PlayerClient service = new ServiceReference1.PlayerClient();
            string nombre = tbNombre.Text;
            string usuarname = tbUsuario.Text;
            string email = tbEmail.Text;
            string password = pswContraseña.Password.ToString();
            String AlertLogin = "Registro exitoso";
            String AlertIncorrecto = "No se ha completado el registro de mner exitosa"; 
            if (pswContraseña.Password.ToString() == pswRepetirContraseña.Password.ToString())
            {
                respuesta = service.Register(nombre, email, password, usuarname, 0, 0);
                if (respuesta != 0) {
                    MessageBox.Show(AlertLogin);
                    tbNombre.Clear();
                    tbUsuario.Clear();
                    tbEmail.Clear();
                    pswContraseña.Clear();
                    pswRepetirContraseña.Clear();
                }
                else
                {
                    MessageBox.Show(AlertIncorrecto);
                }
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
