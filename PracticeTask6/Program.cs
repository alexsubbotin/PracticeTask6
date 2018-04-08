using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PracticeTask6
{
    class Program
    {
        // Task: input: a1, a2, a3, M, N. Create a sequence of numbers where ak = 3/2*a(k-1) - 2/3*a(k-2) = 1/3*a(k-3) using recursion until ak <= M.
        // Check if ak = M, compare N and J (input number of elements and how many of them there are in reality).
        // Student: Alexey Subbotin. Group: SE-17-1.
        static void Main(string[] args)
        {
            // Expected number of elements.
            int N;

            // Getting the N, N > 3.
            bool ok;
            do
            {
                Console.Write("Enter the number of elements (N): ");
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok || N < 4)
                    Console.WriteLine("Input error! Perhaps you didn't enter a natural number greater than 3");
            } while (!ok || N < 4);

            // Epsilon.
            double M;

            // Getting the M.
            do
            {
                Console.Write("Enter the epsilon (M): ");
                ok = Double.TryParse(Console.ReadLine(), out M);
                if (!ok || M < 0)
                    Console.WriteLine("Input error! Perhaps you didn't enter a real number greater than 0");
            } while (!ok || M < 0);

            // Creating the sequence.
            ArrayList sequence = new ArrayList();

            // Getting the first 3 elements.
            for (int i = 0; i < 3; i++)
            {
                double buf;
                do
                {
                    Console.Write("Enter the {0} element of the sequence: ", i + 1);
                    ok = Double.TryParse(Console.ReadLine(), out buf);
                    if (!ok || buf <= M)
                        Console.WriteLine("Input error! Perhaps you didn't enter a real number greater than M");
                    else
                        sequence.Add(buf);
                } while (!ok || buf <= M);
            }

            // Number of the current element.
            int J = 3;
            double current = CalculateElement(J, J, sequence);

            // While |ak| > M.
            while (Math.Abs(current) > M)
            {
                sequence.Add(current);
                J++;
                current = CalculateElement(J, J, sequence);
            }

            // Printing the sequence.
            Console.Write("Created sequence: ");
            for (int i = 0; i < sequence.Count; i++)
                Console.Write(sequence[i] + " ");
            Console.WriteLine();

            // Checking if last calculated equals M.
            if (current == M)
                Console.WriteLine("The last calucalted element ({0}) equals M", current);
            else
                Console.WriteLine("The last calculted element {0} doesn't equal M", current);

            // Comapring N and J.
            J++;
            if (N > J)
                Console.WriteLine("N > J. Expected number of elements greater than the real one");
            if (N == J)
                Console.WriteLine("N = J. Expected number of elements equals the real one");
            if (N < J)
                Console.WriteLine("N < J. Expected number of elements less than the real one");

            Console.ReadLine();
        }

        // Recurrent function to calculate an element of the sequence.
        public static double CalculateElement(int specIndex, int index, ArrayList sequence)
        {
            double result;
            if (index > 2 && specIndex - index <= 3)
            {
                result = (double)3 /2 * CalculateElement(specIndex, index - 1, sequence) - (double)2 / 3 * CalculateElement(specIndex, index - 2, sequence) - 
                    (double)1 / 3 * CalculateElement(specIndex, index - 3, sequence);
                return result;
            }
            else
                return (double)sequence[index];
        }
    }
}
