﻿using System;
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
    /// Lógica de interacción para PantallaJugar.xaml
    /// </summary>
    public partial class PantallaJugar : Window
    {
        public PantallaJugar()
        {
            InitializeComponent();
            cbIdioma.Text = App.idioma;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
            this.Close();
        }

        private void btnUnirse_Click(object sender, RoutedEventArgs e)
        {
            PantallaUnirsePartida pantallaUnirsePartida = new PantallaUnirsePartida();
            pantallaUnirsePartida.Show();
            this.Close();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            SalaDeEsperaAnfitrion salaDeEsperaAnfitrion = new SalaDeEsperaAnfitrion();
            salaDeEsperaAnfitrion.Show();
            this.Close();
        }
        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdioma.SelectedItem == cbiEspañol && App.idioma != "Español")
            {
                App.IdiomaEspañol();
                PantallaJugar pantallaJugar = new PantallaJugar();
                pantallaJugar.cbIdioma.Text = "Español";
                pantallaJugar.Show();
                this.Close();
            }
            if (cbIdioma.SelectedItem == cbiIngles && App.idioma != "English")
            {
                App.IdiomaIngles();
                PantallaJugar pantallaJugar = new PantallaJugar();
                pantallaJugar.cbIdioma.Text = "Español";
                pantallaJugar.Show();
                this.Close();
            }
        }
    }
}
