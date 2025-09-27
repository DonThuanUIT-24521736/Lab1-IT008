using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Program
    {
        static void OutPutArr(int[] arr)
        {
            foreach (int x in arr)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
        static int sumOddSum(int[] arr) // hàm tổng số lẻ 
        {
            int sum = 0;
            foreach (int x in arr)
            {
                if (x % 2 != 0)
                    sum += x;
            }
            return sum; 
        }
        static bool isPrime(int x) // hàm kiểm tra số nguyên tố 
        {
            if (x < 2) return false; 
            for(int i = 2; i*i <= x; i++)
            {
                if (x % i == 0) return false; 
            }
            return true; 
        }
        static int countPrime(int[] arr) // hàm đếm số nguyên tố trong mảng 
        {
            int cnt = 0; 
            foreach (int x in arr)
            {
                if (isPrime(x)) cnt++; 
            }
            return cnt; 
        }

        static bool isSquareNumber(int x) // hàm kiểm tra số chính phương 
        {
            if (x <= 0) return false; 
            int k = (int)Math.Sqrt(x);
            if (k * k == x) return true;
            return false; 
        }
        static int minSquareNumber(int[] arr) // hàm trả về số chính phương nhỏ nhất 
        {
            int minResult = -1; 
            foreach(int x in arr)
            {
                if(isSquareNumber(x))
                {
                    if(minResult == -1)
                    {
                        minResult = x; 
                    }
                    else
                    {
                        minResult = Math.Min(x, minResult); 
                    }
                }
            }
            return minResult; 
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Mời bạn nhập vào n phần tử: ");
            int n = int.Parse(Console.ReadLine());

            // Tạo mảng + sinh giá trị ngẫu nhiên. 
            int[] arr = new int[n];
            Random rd = new Random(); 

            for(int i = 0; i < n; i++)
            {
                arr[i] = rd.Next(-100, 101); // Giá trị số nguyên ngẫu nhiên từ -100 đến 100. 
            }

            Console.WriteLine($"Mảng số nguyên {n} phần tử số nguyên ngẫu nhiên vừa tạo : "); 
            
            OutPutArr(arr);

            int sumOfOddNumberinArr = sumOddSum(arr);
            int theNumberOfPrimeinArr = countPrime(arr);
            int theMinSquareNumber = minSquareNumber(arr);
            Console.WriteLine("Tổng số các số nguyên lẻ trong mảng là: " + sumOfOddNumberinArr);
            Console.WriteLine("Số lượng số nguyên tố trong mảng là: " + theNumberOfPrimeinArr);
            Console.WriteLine("Số chính phương nhỏ nhất trong mảng là: " + theMinSquareNumber); 
            
            Console.ReadLine(); 
        }
    }
}
