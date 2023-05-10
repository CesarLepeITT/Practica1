using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Clases
{
    abstract class ClaseFiguras
    {

       public abstract double CalcularArea();

       public abstract double CalcularPerimetro();

        public double Area 
        {
            
            set => _area = value; 

            get => _area; 
        
        }
        public double Perimetro 
        {
            
            set => _perimetro = value; 

            get=> _perimetro; 
        
        }

        protected double _area;
        protected double _perimetro;

    }

    abstract class Paralelogramos : ClaseFiguras
    {

        public double Altura 
        {
            set => _altura = value;

            get => _altura;
        
        }

        public double Base
        {
            set => _base = value;

            get => _base;

        }

        private double _altura;
        private double _base;

    }

    class Cuadrado : Paralelogramos
    {
        public Cuadrado(double lado)
        {
            if (lado > 0)
            {

                Altura = lado;

            }
            else
            {

                Altura = 1;

            }

            CalcularArea();
            CalcularPerimetro();

        }

        public override double CalcularArea() => CalcularArea(Altura);
        public double CalcularArea(double lado)
        {
            if (lado <= 0)
            {

                lado = 1;

            }

            Altura = lado;

            Area = Altura * Altura;

            return Area;

        }

        public override double CalcularPerimetro() => CalcularPerimetro(Altura); 

        public double CalcularPerimetro(double lado)
        {

            if (lado <= 0)
            {

                lado = 1;

            }

            Altura = lado;

            Perimetro = 4 * Altura;

            return Perimetro;

        }

    }

    class Rectangulo : Paralelogramos
    {
        public Rectangulo(double altura, double bbase)
        {
            if (altura > 0)
            {
                Altura = altura;
            }
            else
            {
                Altura = 1;
            }            
            if (bbase > 0)
            {
                Base = bbase;
            }
            else
            {
                Base = 1;
            }

            CalcularArea();
            CalcularPerimetro();

        }

        public override double CalcularArea()
        {

            Area = CalcularArea(Base, Altura);

            return Area;

        }        
        public double CalcularArea(double lado1, double lado2)
        {

            Area = lado1 * lado2;

            return Area;

        }      
        public override double CalcularPerimetro()
        {

            Perimetro = CalcularPerimetro(Base, Altura);

            return Perimetro;

        }        
        public double CalcularPerimetro(double lado1, double lado2)
        {

            Perimetro = 2*lado1 + 2* lado2;

            return Perimetro;

        }
    }
}
