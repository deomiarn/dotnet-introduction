using System;
using Microsoft.VisualBasic.CompilerServices;

namespace DN2
{
    class MainClass
    {
        const int STEPS = 100;
        const double EPS = 1E-5;

        public static void Main(string[] args)
        {
            Console.WriteLine("Linear fixed [0..10]: " + Integrator.Integrate(x => x, 0, 10, STEPS) + " steps: " +
                              Integrator.Steps);
            Console.WriteLine("Linear fixed [5..15]: " + Integrator.Integrate(x => x, 5, 15, STEPS) + " steps: " +
                              Integrator.Steps);
            Console.WriteLine("Linear adapt [0..10]: " + Integrator.Integrate(x => x, 0, 10, EPS) + " steps: " +
                              Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, STEPS) + " steps: " +
                              Integrator.Steps);
            Console.WriteLine("Square adapt [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, EPS) + " steps: " +
                              Integrator.Steps);
            Console.ReadLine();
        }
    }

    public class Integrator
    {
        public static int Steps;

        public static double Integrate(Func<double, double> f, double start, double end, int steps)
        {
            Steps = steps;
            double d = (end - start) / steps;
            double area = 0;

            for (double i = 0; i < steps; i++)
            {
                double stepStart = start + i * d;
                double stepEnd = start + (i + 1) * d;

                area += d * (f(stepStart) + f(stepEnd)) / 2;
            }

            return area;
        }

        public static double Integrate(Func<double, double> f, double start, double end, double eps)
        {
            Steps = 1;
            double accuracy = double.MaxValue;
            double startArea = Integrate(f, start, end, Steps);

            while (accuracy > eps)
            {
                Steps *= 2;
                double newArea = Integrate(f, start, end, Steps);
                accuracy = Math.Abs(newArea - startArea);
                startArea = newArea;
            }

            return startArea;
        }
    }
}