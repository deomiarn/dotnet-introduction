using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1
{
    public enum PrimeType
    {
        Prime,
        NotPrime
    };

    public class Eratosthenes
    {
        public PrimeType[] Sieve(int maxPrime)
        {
            PrimeType[] result = new PrimeType[maxPrime];

            for (int i = 0; i < maxPrime; i++)
            {
                result[i] = PrimeType.Prime;
            }

            for (int i = 2; i <= maxPrime; i++)
            {
                if (result[i - 1] == PrimeType.Prime)
                {
                    for (int j = 2 * i; j < maxPrime; j += i)
                    {
                        result[j] = PrimeType.NotPrime;
                    }
                }
            }

            return result;
        }

        public int[] PrimesAsArray(PrimeType[] primes)
        {
            int count = 0;
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    result[index++] = i;
                }
            }

            return result;
        }

        public List<int> PrimesAsList(PrimeType[] primes)
        {
            List<int> result = new List<int>();
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == PrimeType.Prime)
                {
                    result.Add(result.Count, i);
                }
            }

            return result;
        }

        public void printAll(IEnumerable<int> collection)
        {
            int i = 0;
            foreach (int p in collection)
            {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);
            PrimeType[] primes = eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i < maxPrime; i++)
            {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }

            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());

            Console.ReadLine();
        }
    }
}