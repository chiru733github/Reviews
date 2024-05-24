using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review1
{
    public abstract class Calc<T>
    {
        public abstract T Add(T a, T b);
        public abstract T Sub(T a, T b);
        public abstract T Multiply(T a, T b);
        public abstract T Divide(T a, T b);
    }
    public class LongData : Calc<long>
    {
        public override long Add(long a,long b)
        {
            return a + b;
        }
        public override long Sub(long a,long b)
        {
            return a - b;
        }
        public override long Multiply(long a, long b)
        {
            return a * b;
        }
        public override long Divide(long a, long b)
        {
            return a / b; 
        }

    }
    public class DoubleData : Calc<double>
    {
        public override double Add(double a, double b)
        {
            return a + b;
        }
        public override double Sub(double a, double b)
        {
            return a - b;
        }
        public override double Multiply(double a, double b)
        {
            return a * b;
        }
        public override double Divide(double a, double b)
        {
            return a / b;
        }

    }
}
