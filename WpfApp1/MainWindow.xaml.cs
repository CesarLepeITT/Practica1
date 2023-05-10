using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Clases;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private DoubleAnimation Parpadeo()
        //{
        //    Storyboard x = new();

        //    DoubleAnimation _animacionParpadeo = new();
        //    _animacionParpadeo.From = 1;
        //    _animacionParpadeo.To = 0;
        //    x.Clone(cb);

        //}

        private Image CambiarImagen(string direccion, Image imagen)
        {
            BitmapImage myBitmap = new BitmapImage();
            if (!string.IsNullOrEmpty(direccion))
            {
                try
                {
                    Uri myUri = new Uri(direccion);
                    myBitmap.BeginInit();
                    myBitmap.UriSource = myUri;
                    myBitmap.EndInit();
                }
                catch (System.UriFormatException) { }
            }
            imagen.Source = myBitmap;
            return imagen;
        }
        private void HabilitarTextBox(int cantidadTB) 
        {
            if (cantidadTB >= 1)
            {
                TextBox1.Visibility = Visibility.Visible;
                TextBox1.IsEnabled = true;
            }
            if (cantidadTB >= 2) 
            {
                TextBox2.Visibility = Visibility.Visible;
                TextBox2.IsEnabled = true;
            }
            if (cantidadTB >= 3) 
            {
                TextBox2.Visibility = Visibility.Visible;
                TextBox2.IsEnabled = true;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // @"^[0-9](\d*\.?(\d{9})?){1}$"
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void cbSeleccionarFigura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSeleccionarFigura.SelectedItem == cmiCuadrado)
            {
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Cuadrado.png", MyImagen);
                HabilitarTextBox(1);
            }
            else if (cbSeleccionarFigura.SelectedItem == cmiRectangulo)
            {
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Rectángulo.png", MyImagen);
                HabilitarTextBox(2);
            }
        }

        private void TextBox2_TextInput(object sender, TextCompositionEventArgs e)
        {
            double lado1;
            try
            {
                lado1 = double.Parse(TextBox2.Text);
            }
            catch (FormatException)
            {
                lado1 = 1;
            }
        }
        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double lado1;
            double lado2;
            if (cbSeleccionarFigura.SelectedItem == cmiCuadrado)
            {
                lado1 = double.Parse(TextBox1.Text);
                Cuadrado myCuadrado = new Cuadrado(lado1);
                txtArea.Text = myCuadrado.Area.ToString();
                txtPerimetro.Text = myCuadrado.Perimetro.ToString();
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Rectángulo Area.png", imgArea);
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Cuadrado Perimetro.png", imgPerimetro);
            }
            if (cbSeleccionarFigura.SelectedItem == cmiRectangulo)
            {
                lado1 = double.Parse(TextBox1.Text);
                lado2 = double.Parse(TextBox2.Text);
                Rectangulo myRectangulo = new Rectangulo(lado1 , lado2);
                txtArea.Text = myRectangulo.Area.ToString();
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Rectángulo Area.png", imgArea);
                txtPerimetro.Text = myRectangulo.Perimetro.ToString();
                CambiarImagen("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Rectángulo Perimetro.png", imgPerimetro);
            }
        }
    }
}