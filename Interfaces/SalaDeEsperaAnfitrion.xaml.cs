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
    /// Lógica de interacción para SalaDeEsperaAnfitrion.xaml
    /// </summary>
    public partial class SalaDeEsperaAnfitrion : Window
    {
        public SalaDeEsperaAnfitrion()
        {
            InitializeComponent();
        }

        private void BtnVolverClick(object sender, RoutedEventArgs e)
        {
            PantallaJugar pantallaJugar = new PantallaJugar();
            pantallaJugar.Show();
            this.Close();
        }

        private void BtnIniciarPartidaClick(object sender, RoutedEventArgs e)
        {
            PartidaAdivinador partidaAdivinador = new PartidaAdivinador();
            partidaAdivinador.Show();
            this.Close();
        }
    }
}
