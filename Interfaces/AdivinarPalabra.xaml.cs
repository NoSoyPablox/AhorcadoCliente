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
    /// Lógica de interacción para AdivinarPalabra.xaml
    /// </summary>
    public partial class AdivinarPalabra : Window
    {
        PartidaAdivinador partidaActual;
        public AdivinarPalabra()
        {
            InitializeComponent();
        }
        public void recibirPartida(PartidaAdivinador partidaActual)
        {
            this.partidaActual = partidaActual;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            partidaActual.IsEnabled = true;
            this.Close();
        }
    }
}
