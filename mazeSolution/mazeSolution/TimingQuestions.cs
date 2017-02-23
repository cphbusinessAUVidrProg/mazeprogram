using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mazeSolution
{
    /*
     * Tidstagning
    Som led i løsningen på denne opgave skal der som minimum løses følgende (der skal meget mere til dog):

    tallene i den første linje skal laves om fra tekst til heltal (int)
    der skal allokeres et to dimentionelt array af tegn i passende størrelse
    opg 1. Prøv at tage tid på disse to dele (konvertering fra tekst til heltal og oprettelse af array).

    opg 2. Hvordan afhænger array allokeringen af størrelsen på arrayet?

    opg 3. Kommer der nogle bemærkelsesværdige ændringer i tidsforbruget når det bliver meget store arrays (når man begynder at allokere nær din computers interne lager størrelse).
     */
    class TimingQuestions
    {
        public static double TekstTilTal()
        {
            int count = 10000000;
            string[] numbers = new string[1000];
            Random rnd = new Random();
            int month = rnd.Next(1, 13);
            for (int i = 0; i<1000; i++)
            {
                numbers[i] = "" + rnd.Next(100000, 3000000);
            }
            Console.WriteLine("Heltalslæsning");
            int dummy = 77;
            for (int ii = 0; ii < 10; ii++)
            {
                Timer t = new Timer();
                for (int i = 0; i < count; i++)
                    int.TryParse(numbers[i%1000], out dummy);
                double time = t.Check() * 1e9 / count;
                Console.WriteLine("{0,6:F1} ns", time);
            }
            return dummy;
        }

        public static double InstantiateArray()
        {
            int count = 10;
            int[,] iArr;
            Console.WriteLine("Instantiate Array");
            int dummy = 77;
            long kilo = 2 ^ 10; // kilo, mega, giga , 1000, 1000.000, 1000.000.000
            for (int ii = 0; ii < 10; ii++)
            {
                long size = (long)(Math.Pow(2, ii+kilo));
                Timer t = new Timer();
                for (int i = 0; i < count; i++)
                    iArr = new int[size, size];
                double time = t.Check() * 1e9 / count;
                Console.WriteLine("{0,6:F1} ns for " + size, time);
            }
            return dummy;
        }
    }

    public class Timer
    {
        private readonly System.Diagnostics.Stopwatch stopwatch
          = new System.Diagnostics.Stopwatch();
        public Timer() { Play(); }
        public double Check() { return stopwatch.ElapsedMilliseconds / 1000.0; }
        public void Pause() { stopwatch.Stop(); }
        public void Play() { stopwatch.Start(); }
    }
}
