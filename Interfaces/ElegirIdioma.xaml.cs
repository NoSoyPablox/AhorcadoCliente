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
    /// Lógica de interacción para ElegirIdioma.xaml
    /// </summary>
    public partial class ElegirIdioma : Window
    {
        public ElegirIdioma()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            PantallaJugar pantallaJugar = new PantallaJugar();
            pantallaJugar.Show();
            this.Close();
        }

        private void btnEspanol_Click(object sender, RoutedEventArgs e)
        {
            PartidaAdivinador partida = new PartidaAdivinador();
            partida.Show();
            this.Close();
        }
    }
}
