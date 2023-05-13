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
        private Image CambiarImagen(Uri myUri, Image imagen)
        {
            BitmapImage myBitmap = new BitmapImage();

                    myBitmap.BeginInit();
                    myBitmap.UriSource = myUri;
                    myBitmap.EndInit();

            imagen.Source = myBitmap;
            return imagen;
        }
        private void DesabilitarTodo()
        {
            TextBox1.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Hidden;
            TextBox1.Visibility = Visibility.Hidden;
            TextBox2.Visibility = Visibility.Hidden;
            imgArea.Visibility = Visibility.Hidden;
            imgPerimetro.Visibility = Visibility.Hidden;
            txtArea.Text = "";
            txtPerimetro.Text = "";
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
            btnCalcular.Visibility = Visibility.Visible;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // @"^[0-9](\d*\.?(\d{9})?){1}$"
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void cbSeleccionarFigura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DesabilitarTodo();

            if (cbSeleccionarFigura.SelectedItem == cmiCuadrado)
            {
                // No pude hacerla una uri relativa, sad 
                //C:\Users\CESARLEPEGARCIA\Source\Repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\
                // C:\Users\CESARLEPEGARCIA\Source\Repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\Cuadrado.png
                CambiarImagen(new Uri (@"C:\Users\CESARLEPEGARCIA\Source\Repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\Cuadrado.png"), MyImagen);
                HabilitarTextBox(1);
            }
            else if (cbSeleccionarFigura.SelectedItem == cmiRectangulo)
            {
                CambiarImagen(new Uri("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Rectángulo.png"), MyImagen);
                HabilitarTextBox(2);
            }
        }
        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double lado1;
            double lado2;
            if (cbSeleccionarFigura.SelectedItem == cmiCuadrado)
            {
                try
                { lado1 = double.Parse(TextBox1.Text); }
                catch (FormatException) { lado1 = 1; }
                Cuadrado myCuadrado = new Cuadrado(lado1);
                txtArea.Text = myCuadrado.Area.ToString();
                txtPerimetro.Text = myCuadrado.Perimetro.ToString();
                CambiarImagen(new Uri (@"C:\Users\CESARLEPEGARCIA\Source\Repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\Cuadrado Area.png"), imgArea);
                CambiarImagen(new Uri("C:\\Users\\CESARLEPEGARCIA\\source\\repos\\CesarLepeITT\\Practica1\\WpfApp1\\Imagenes\\Cuadrado Perimetro.png"), imgPerimetro);

                }
            if (cbSeleccionarFigura.SelectedItem == cmiRectangulo)
            {
                try
                {
                    lado1 = double.Parse(TextBox1.Text);
                    lado2 = double.Parse(TextBox2.Text);
                }
                catch (FormatException)
                {
                    lado1 = 1;
                    lado2 = 1;
                }
                Rectangulo myRectangulo = new Rectangulo(lado1 , lado2);
                txtArea.Text = myRectangulo.Area.ToString();
                CambiarImagen(new Uri(@"C:\Users\CESARLEPEGARCIA\source\repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\Rectángulo Area.png"), imgArea);
                txtPerimetro.Text = myRectangulo.Perimetro.ToString();
                CambiarImagen(new Uri(@"C:\Users\CESARLEPEGARCIA\Source\Repos\CesarLepeITT\Practica1\WpfApp1\Imagenes\Rectángulo Perimetro.png"), imgPerimetro);
            }

            txtArea.Visibility = Visibility.Visible;
            txtPerimetro.Visibility = Visibility.Visible;
            imgArea.Visibility = Visibility.Visible;
            imgPerimetro.Visibility = Visibility.Visible;

        }
    }
}