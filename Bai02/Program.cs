using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    internal class Program
    {
        static bool isPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        static void Input(out int n)
        {
            n = int.Parse(Console.ReadLine());
            while (n < 0)
            {
                Console.WriteLine("Hãy nhập n > 0 !!!");
                n = int.Parse(Console.ReadLine());
            }
        }
        static long sumPrime(int n)
        {
            long sum = 0;
            Console.WriteLine($"Các số nguyên tố nhỏ hơn {n} là :");
            Console.Write("[ ");
            for (int i = 2; i < n; i++)
            {
                if (isPrime(i))
                {
                    Console.Write(i + " ");
                    sum += i;
                }
            }
            Console.WriteLine("]");
            return sum;
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;
            while (true)
            {
                Console.WriteLine("Mời bạn nhập vào số tự nhiên n dương");

                Input(out n);

                Console.WriteLine("Tổng các số nguyên tố nhỏ hơn số tự nhiên n là " + sumPrime(n));
                Console.ReadLine();

                Console.WriteLine("Nhấn 'y' nếu muốn tiếp tục, nếu không muốn nhấn ký tự khác");
                char q = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.ReadLine();
                if (q != 'y') break;

            }
        }
    }
}
