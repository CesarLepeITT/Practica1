using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Clases
{
    abstract class ClaseFiguras
    {

       public abstract float CalcularArea();

       public abstract float CalcularPerimetro();

        protected float Area 
        {
            
            set => _area = value; 

            get => _area; 
        
        }
        protected float Perimetro 
        {
            
            set => _perimetro = value; 

            get=> _perimetro; 
        
        }

        protected float _area;
        protected float _perimetro;

    }

    abstract class Paralelogramos : ClaseFiguras
    {

        public float Altura 
        {
            set => _altura = value;

            get => _altura;
        
        }

        public float Base
        {
            set => _base = value;

            get => _base;

        }

        private float _altura;
        private float _base;

    }

    class Cuadrado : Paralelogramos
    {
        public Cuadrado(float lado)
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

        }

        public override float CalcularArea() => CalcularArea(Altura);
        public float CalcularArea(float lado)
        {
            if (lado <= 0)
            {

                lado = 1;

            }

            Altura = lado;

            Area = Altura * Altura;

            return Area;

        }

        public override float CalcularPerimetro() => CalcularPerimetro(Altura); 

        public float CalcularPerimetro(float lado)
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


}
