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
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> letras = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private List<string> letrasPuestas = new List<string>();
        private int numeroCartas;
        private string caracter1;
        private string caracter2;
        private DispatcherTimer temporizador;
        public MainWindow()
        {
            InitializeComponent();
            temporizador = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(2)
            };

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
            numeroCartas = numFilas * 4;
            DibujarFilas(numFilas);

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
                    Random semilla = new Random();

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

                    string letra = letras[semilla.Next(0, 10)];

                    int contador = 0;
                    while (contador <= numeroCartas)
                    {
                        if (Disponible(letra))
                        {
                            tb.Tag = letra;
                            letrasPuestas.Add(letra);
                        }
                            
                        else
                            letra = letras[semilla.Next(0, 10)];
                        contador++;
                    }

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
            


            if (tb.Text.Equals("s"))
            {
                tb.Text = tb.Tag.ToString();
                if (caracter1 == null)
                    caracter1 = tb.Text;
                else if (caracter2 == null)
                    caracter2 = tb.Text;
            }

           







        }

        private bool Disponible(string letras)
        {
            int num = 0;
            for (int indice = 0; indice < letrasPuestas.Count; indice++)
            {
                if (letrasPuestas[indice].Equals(letras))
                    num++;
            }
            return num <= 1;
        }
    }
}
