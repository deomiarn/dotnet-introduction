using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {
    public class Space {
        
        static void Main(string[] args) {
            Vector omegaEarth,omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }
        
        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            Vector unitVector = new Vector(0, 1, 0);
            omegaEarth = 2 * Math.PI / (24 * 3600) * unitVector;
            omegaSun = 2 * Math.PI / (365.25 * 24 * 3600) * unitVector;
            omegaGalaxy = 2 * Math.PI / (225e6 * 365.25 * 24 * 3600) * unitVector;
        }
        
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            Vector unitVector = new Vector(1, 0, 0);
            rEarth = 6370 * unitVector;
            rSun = 149.6e6 * unitVector;
            rGalaxy = 9.46e12 * 25e3 * unitVector;
            
        }

        public static double CalcSpeed(Vector omegaEarth,Vector omegaSun, Vector omegaGalaxy,Vector rEarth, Vector rSun, Vector rGalaxy)
        {
            Vector vEarth = omegaEarth * rEarth;
            Vector vSun = omegaSun * rSun;
            Vector vGalaxy = omegaGalaxy * rGalaxy;
            Vector v = vEarth + vSun + vGalaxy;
            return (double)v;

        }
    }
}
