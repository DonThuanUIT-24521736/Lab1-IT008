using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Bai06
{
    internal class Program
    {
        static void OutputMatrix(int[,] matrix, int n, int m) // Hàm xuất ma trận 
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " "); 
                }
                Console.WriteLine(); 
            }
        }
        static int minMember(int[,] matrix) // Hàm tìm phần tử nhỏ nhất trong ma trận 
        {
            int minValue = matrix[0, 0]; 
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minValue)
                    {
                        minValue = matrix[i, j]; 
                    }
                }
            }
            return minValue; 
        }

        static int maxMember(int[,] matrix) // Hàm tìm phần tử lớn nhất trong ma trận 
        {
            int maxValue = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
            }
            return maxValue;
        }
        static int maxSumRow(int[,] matrix) // Hàm trả về hàng có tổng lớn nhất 
        {
            int ind = 0;
            int maxSum = int.MinValue; 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0; 
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j]; 
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    ind = i + 1; 
                }
            }
            return ind; 
        }
        static bool isPrime(int x) // hàm kiểm tra số nguyên tố. 
        {
            if (x < 2) return false; 
            for(int i = 2; i*i <= x; i++)
            {
                if (x % i == 0) return false; 
            }
            return true; 
        }
        static int sumMemberNotPrime(int[,] matrix) // hàm trả về tổng các phần tử không phải số nguyên tố 
        {
            int sum = 0; 
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (isPrime(matrix[i, j]) == false)
                    sum += matrix[i, j]; 
                }
            }
            return sum; 
        }

        static bool deleteRow(int [,]matrix, int k,ref int n,ref int m) // Hàm xóa dòng thứ k trong ma trận
        {
            if(k > n)
            {
                Console.WriteLine($"Lỗi! Ma trận chỉ có {n} dòng, {k} quá lớn ");
                return false; 
            }
            else if(k < 1) 
            {
                Console.WriteLine("Lỗi! không có hàng < 1");
                return false; 
            }
            else
            {
                for(int i = k - 1; i < n-1; i++)
                {
                    for(int j = 0; j < m; j++)
                    {
                        matrix[i, j] = matrix[i + 1, j]; 
                    }
                }
                --n;
                return true; 
            }
        }
        static bool deleteCol(int[,] matrix, int k, ref int n, ref int m) // Hàm xóa hàng thứ k trong ma trận
        {
            if (k > m)
            {
                Console.WriteLine($"Lỗi! Ma trận chỉ có {m} cột, {k} quá lớn ");
                return false;
            }
            else if (k < 1)
            {
                Console.WriteLine("Lỗi! không có cột < 1");
                return false;
            }
            else
            {
                for (int i = k - 1; i < m - 1; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i, j+1];
                    }
                }
                --m;
                return true;
            }
        }
        static int findColHaveMaxValue(int[,] matrix, int n, int m)
        {
            int ind = 0;
            int maxValue = matrix[0, 0]; 
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                  if(matrix[i, j] > maxValue)
                    {
                        ind = j + 1; 
                    }
                }

            }
            return ind; 
        }
        static bool deleteColHaveMaxValue(int[,]matrix,ref int n,ref int m) // Hàm xóa cột cố phần tử lớn nhất 
        {
           int ind = findColHaveMaxValue(matrix, n, m);
            return (deleteCol(matrix, ind, ref n, ref m)); 
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8; 
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Mời nhập vào số hàng : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Mời nhập vào số cột: ");
            int m = int.Parse(Console.ReadLine());

            int[,] Matrix = new int[n, m];
            Random rd = new Random();

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Matrix[i, j] = rd.Next(-100, 101); 
                }
            }
            Console.WriteLine($"Ma trận {n}x{m} vừa tạo là : "); 
            OutputMatrix(Matrix, n, m);
            int minValueinMatrix = minMember(Matrix);
            Console.WriteLine("Phần tử nhỏ nhất trong ma trận là : " + minValueinMatrix);
            int maxValueinMatrix = maxMember(Matrix);
            Console.WriteLine("Phần tử lớn nhất trong ma trận là : " + maxValueinMatrix);

            int indexMaxSumRow = maxSumRow(Matrix);
            Console.WriteLine("Dòng có tổng lớn nhất là : " + indexMaxSumRow);

            int sumofMemberNotPrime = sumMemberNotPrime(Matrix); 
            Console.WriteLine("Tổng của các số không phải là số nguyên tố trong ma trận là : " + sumofMemberNotPrime);

            Console.WriteLine($"Mời nhập vào hàng k mà bạn muốn xóa !(0 < k < {n+1})");
            int k = int.Parse(Console.ReadLine());
            if (deleteRow(Matrix, k, ref n, ref m) == true)
            {
                Console.WriteLine($"Ma trận sau khi xóa hàng thứ {k} là ");
                OutputMatrix(Matrix, n, m); 
            }
            
            if (deleteColHaveMaxValue(Matrix, ref n, ref m))
            {
                Console.WriteLine("Ma trận sau khi xóa cột chứ phần tử lớn nhất là: "); 
                OutputMatrix(Matrix, n, m); 
            }

            Console.ReadLine(); 

        }
    }
}
