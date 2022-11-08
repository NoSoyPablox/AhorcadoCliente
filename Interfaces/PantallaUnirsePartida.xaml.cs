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
    /// Lógica de interacción para PantallaUnirsePartida.xaml
    /// </summary>
    public partial class PantallaUnirsePartida : Window
    {
        public PantallaUnirsePartida()
        {
            InitializeComponent();
        }

        private void BtnVolverClick(object sender, RoutedEventArgs e)
        {
            PantallaJugar pantallaJugar = new PantallaJugar();
            pantallaJugar.Show();
            this.Close();
        }

        private void BtnUnirseClick(object sender, RoutedEventArgs e)
        {
            SalaDeEsperaInvitado salaDeEsperaInvitado = new SalaDeEsperaInvitado();
            salaDeEsperaInvitado.Show();
            this.Close();
        }
    }
}
