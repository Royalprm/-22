using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Упражнение_22
{
    internal class Program
    {
        static int MassSumm(int[] mass)
        {
            return mass.Sum();
        }
        static int MassMax(Task<int> t, object o)
        {
            int[] mass = (int[])o;
            return mass.Max();
        }
        static void Main(string[] args)
        {
            
            Console.Write("Введите размер массива: ");
            int size = Convert.ToInt32(Console.ReadLine());

            
            int[] mass = new int[size];

            
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                mass[i] = rand.Next(0, 1000);
            }

            
            string printMass = "[ ";
            foreach (int i in mass)
            {
                printMass += i + ", ";
            }
            printMass = printMass.Remove(printMass.Length - 2, 2);
            printMass += " ]";
            Console.WriteLine();
            Console.WriteLine(printMass);

            
            Func<int> action = new Func<int>(() => MassSumm(mass));
            Task<int> task1 = new Task<int>(action);
            task1.Start();
            Console.WriteLine($"\nСумма массива: {task1.Result}");

            
            Func<Task<int>, object, int> action2 = new Func<Task<int>, object, int>(MassMax);
            Task<int> task2 = task1.ContinueWith<int>(action2, mass);
            Console.WriteLine($"\nНаибольшее значение: {task2.Result}");

            
            Console.WriteLine("\nНажмите любую кнопку");
            Console.ReadKey();
        }
    }
}

