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
        List<char> listaLetras = new List<char>(10);
        string caracter1;
        string caracter2;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonIniciar_Click(object sender, RoutedEventArgs e)
        {
            
            Random semilla = new Random();

            int numFilas = 0;
            if (RadioButtonBaja.IsChecked == true)
                numFilas = 3;
            if (RadioButtonMedia.IsChecked == true)
                numFilas = 4;
            if (RadioButtonAlta.IsChecked == true)
                numFilas = 5;
            DibujarFilas(numFilas);

            for (int i = 0; i <= (numFilas * 4) / 2; i++)
                listaLetras.Add((char)semilla.Next(65, 91));

            EscribirCartas();

            
        }

        private void DibujarFilas(int numFilas)
        {
            GridCartas.RowDefinitions.Clear();
            for (int indiceFilas = 0; indiceFilas < numFilas; indiceFilas++)
            {
                GridCartas.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void EscribirCartas()
        {
            Border borde;
            TextBlock tb;
            Viewbox vb;
            const int NUM_COLUMNA = 4;

            for (int contadorFila = 0; contadorFila < GridCartas.RowDefinitions.Count; contadorFila++)
            {
                for (int contadorColumna = 0; contadorColumna < NUM_COLUMNA; contadorColumna++)
                {
                    borde = new Border();
                    tb = new TextBlock();
                    vb = new Viewbox();


                    GridCartas.Children.Add(borde);
                    borde.Child = vb;
                    vb.Child = tb;

                    borde.Margin = new Thickness(5);
                    borde.BorderThickness = new Thickness(3);
                    borde.BorderBrush = Brushes.Black;
                    borde.CornerRadius = new CornerRadius(5);
                    borde.Background = Brushes.LightBlue;
                    borde.MouseDown += Borde_MouseDown;
                    tb.FontFamily = new FontFamily("Webdings");
                    tb.Text = "s";


                    Grid.SetColumn(borde, contadorColumna);
                    Grid.SetRow(borde, contadorFila);
                }
            }
        }

        private void Borde_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border borde = sender as Border;
            Viewbox vb = (Viewbox) borde.Child;
            TextBlock tb = (TextBlock) vb.Child;
            Random semilla = new Random();
            tb.Tag = Convert.ToString(listaLetras[semilla.Next(0, 10)]);


            if (tb.Text.Equals("s"))
            {
                tb.Text = tb.Tag.ToString();
                if (caracter1 == null)
                    caracter1 = tb.Text;
                else if (caracter2 == null)
                    caracter2 = tb.Text;
            }

            if (caracter1 != null && caracter2 != null)
                if(!ComprobarIguales())
                {
                    caracter1 = null;
                    caracter2 = null;
                    tb.Text = "s";
                }







        }

        private bool ComprobarIguales()
        {
            bool iguales = false;
            if (caracter1 == caracter2)
                iguales = true;
            return iguales;
        }
    }
}
