namespace HomeWork3
{
    public struct Complex
    {
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;
        
        public Complex Plus(Complex x)
        {
            Complex y = new Complex();
            y.re = re + x.re;
            y.im = im + x.im;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y = new Complex();
            y.re = re - x.re;
            y.im = re - x.im;
            return y;
        }

        public static Complex Plus(Complex complex1, Complex complex2)
        {
            Complex res = new Complex();
            res.re = complex1.re + complex2.re;
            res.im = complex1.im + complex2.im;
            return res;
        }

        public static Complex Minus(Complex complex1, Complex complex2)
        {
            Complex res = new Complex();
            res.re = complex1.re - complex2.re;
            res.im = complex1.im - complex2.im;
            return res;
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}