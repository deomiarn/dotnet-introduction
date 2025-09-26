using System;

namespace DN2 {
    class MainClass {
        const int STEPS = 100;
        const double EPS = 1E-5;
    
        public static void Main(string[] args) {
            Console.WriteLine("Linear fixed [0..10]: "+Integrator.Integrate(x => x,  0,10,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Linear fixed [5..15]: "+Integrator.Integrate(x => x,  5,15,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Linear adapt [0..10]: "+Integrator.Integrate(x => x,   0,10,EPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: "+Integrator.Integrate(x => x*x, 0,10,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Square adapt [0..10]: "+Integrator.Integrate(x => x*x, 0,10,EPS)+" steps: "+Integrator.Steps);
            Console.ReadLine();
        }
    }
  
    public class Integrator {
        public static int Steps;

        public static double Integrate(Func<double, double> f, double start, double end, int steps) {
            Steps = steps;
            // TODO Implement
            return 0;
        }
  
        public static double Integrate(Func<double, double> f, double start, double end, double eps) {
            Steps = 1;
            // TODO Implement
            return 0;
        }
    }

}