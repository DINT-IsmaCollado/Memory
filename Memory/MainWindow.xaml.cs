using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonBaja.IsChecked == true)
                FilasPartidaFacil();
            if (RadioButtonMedia.IsChecked == true)
                FilasPartidaMedia();
            if (RadioButtonAlta.IsChecked == true)
                FilasPartidaAlta();
        }

        private void FilasPartidaFacil()
        {
            GridCartas.Children.Clear();

            Border borde;
            TextBlock tb;
            Viewbox vb;

            const int NUM_FILAS = 3;
            for (int indiceFilas = 0; indiceFilas <= NUM_FILAS; indiceFilas++)
            {
                    borde = new Border();
                    tb = new TextBlock();
                    vb = new Viewbox();
                    GridCartas.RowDefinitions.Add(new RowDefinition());
                    GridCartas.Children.Add(borde);
                    borde.Child = vb;
                    vb.Child = tb;
    
                    tb.FontFamily = new FontFamily("Webdings");
    

                    tb.Text += "s";
            }
        }

        private void FilasPartidaMedia()
        {

            const int NUM_FILAS = 4;
            for (int indiceFilas = 0; indiceFilas < NUM_FILAS; indiceFilas++)
            {
                GridCartas.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void FilasPartidaAlta()
        {

            GridCartas.Children.Clear();

            const int NUM_FILAS = 5;
            for (int indiceFilas = 0; indiceFilas < NUM_FILAS; indiceFilas++)
            {
                GridCartas.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void EscribirCartas()
        {
            Border borde;
            TextBlock tb;
            Viewbox vb;

            for (int contadorFila = 0; contadorFila < GridCartas.RowDefinitions.Count; contadorFila++)
            {
                for (int contadorColumna = 0; contadorColumna < 4; contadorColumna++)
                {
                    borde = new Border();
                    tb = new TextBlock();
                    vb = new Viewbox();


                    GridCartas.Children.Add(borde);
                    borde.Child = vb;
                    vb.Child = tb;

                    tb.FontFamily = new FontFamily("Webdings");

                    Grid.SetColumn(tb, contadorColumna);
                    Grid.SetRow(tb, contadorFila);

                    tb.Text = "s";

                    borde.Margin = new Thickness(3);
                }
            }
        }
    }
}
