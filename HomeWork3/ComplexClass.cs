namespace HomeWork3
{
    public class ComplexClass
    {
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;
        
        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;

        public ComplexClass(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public ComplexClass() {}

        public ComplexClass Plus(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }
        
        public ComplexClass Minus(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }
        
        public ComplexClass Multiplication(ComplexClass x)
        {
            ComplexClass y = new ComplexClass();
            y.re = (re * x.re) - (im * x.im);
            y.im = (re * x.im) + (x.re * im);
            return y;
        }

        public static ComplexClass Plus(ComplexClass complex1, ComplexClass complex2)
        {
            return new ComplexClass(complex1.re + complex2.re, complex1.im + complex2.im);
        }
        
        public static ComplexClass Minus(ComplexClass complex1, ComplexClass complex2)
        {
            return new ComplexClass(complex1.re - complex2.re, complex1.im - complex2.im);
        }
        
        public static ComplexClass Multiplication(ComplexClass complex1, ComplexClass complex2)
        {
            return new ComplexClass(
                (complex1.re * complex2.re) - (complex1.im * complex2.im), 
                (complex1.re * complex2.im) + (complex2.re * complex1.im));
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}