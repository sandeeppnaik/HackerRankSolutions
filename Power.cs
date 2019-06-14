namespace Hackerrank
{
    public class Power
    {
        public double MyPow(double x, int n)
        {

            if (n == 0)
                return 1;

            if(n < 0)
            {
                n = -n;
                x = 1 / x;
            }
            
            double y = default;
            if(n % 2 == 0)
            {
                x = MyPow(x, n / 2);
                y = x * x;
            }
            else
            {
                y =  x * MyPow(x, n - 1);
            }

            return double.IsInfinity(y) ? 0.0 : y;
        }
    }
}