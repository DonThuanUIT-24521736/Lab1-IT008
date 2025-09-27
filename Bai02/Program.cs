using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
class Program
{
    static bool checkDayMonthYear(int d, int m, int y) // Hàm kiểm tra ngày hợp lệ
    {
        if (d <= 0 || d > 31 || m <= 0 || m > 12 || y <= 0)
        {
            return false;
        }
        else
        {
            int daysInMonth = DateTime.DaysInMonth(y, m);
            if (d < 1 || d > daysInMonth)
            {
                return false;
            }
            return true;
        }
    }
    static int daysInMonth(int m, int y)
    {
        if (m <= 0 || m > 12 || y <= 0)
        {
            return -1;
        }
        else
        {
            return DateTime.DaysInMonth(y, m);
        }
    }

    static void daysOfWeek(int d, int m, int y)
    {
        if (checkDayMonthYear(d, m, y) == false)
        {
            Console.WriteLine("Ngày nhập không hợp lệ !");
        }
        else
        {
            DateTime dt = new DateTime(y, m, d);
            string res = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday: res = "Chủ nhật"; break;
                case DayOfWeek.Monday: res = "Thứ hai"; break;
                case DayOfWeek.Tuesday: res = "Thứ ba"; break;
                case DayOfWeek.Wednesday: res = "Thứ tư"; break;
                case DayOfWeek.Thursday: res = "Thứ năm"; break;
                case DayOfWeek.Friday: res = "Thứ sáu"; break;
                case DayOfWeek.Saturday: res = "Thứ bảy"; break;
            }
            Console.WriteLine($"Ngày {dt:dd/MM/yyyy} là {res}");
        }
    }
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Bài 3 : Kiểm tra ngày tháng năm hợp lệ: 
        Console.WriteLine("Bai03: Kiểm tra ngày tháng năm hợp lệ");
        int d, m, y;
        while (true)
        {
            Console.Write("Mời nhập ngày: ");
            d = int.Parse(Console.ReadLine());
            Console.Write("Mời nhập tháng: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Mời nhập năm: ");
            y = int.Parse(Console.ReadLine());

            if (checkDayMonthYear(d, m, y))
            {
                Console.WriteLine($"Ngay {d:00}/{m:00}/{y} hợp lệ. ");
            }
            else Console.WriteLine("Ngày nhập không hợp lệ !");

            Console.WriteLine("Bạn có muốn tiếp tục kiểm tra ngày khác không?");
            Console.WriteLine("Nhấn 'y' nếu muốn tiếp tục, nếu không muốn nhấn ký tự khác");
            char q = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.ReadLine();
            if (q != 'y') break;
        }

        // Bài 4 : Cho biết số ngày trong tháng, năm. 
        Console.WriteLine("Bai04: In Ra số ngày trong tháng, năm đã nhập");
        while (true)
        {
            Console.Write("Mời nhập tháng: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Mời nhập năm: ");
            y = int.Parse(Console.ReadLine());

            int res = daysInMonth(m, y);
            if (res == -1)
            {
                Console.WriteLine("Tháng, năm nhập vào không hợp lệ!");
            }
            else
            {
                Console.WriteLine($"Tháng {m} năm {y} có {res} ngày.");
            }

            Console.WriteLine("Nhấn 'y' nếu muốn tiếp tục, nếu không muốn nhấn ký tự khác");
            char q = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.ReadLine();
            if (q != 'y') break;
        }

        // Bài 05: Cho biết ngày tháng năm nhập vào là thứ mấy. 
        Console.WriteLine("Bai05: In ra thứ trong tuần của ngày tháng năm đã nhập");
        while (true)
        {
            Console.Write("Mời nhập ngày: ");
            d = int.Parse(Console.ReadLine());
            Console.Write("Mời nhập tháng: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Mời nhập năm: ");
            y = int.Parse(Console.ReadLine());

            daysOfWeek(d, m, y);

            Console.WriteLine("Nhấn 'y' nếu muốn tiếp tục, nếu không muốn nhấn ký tự khác");
            char q = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.ReadLine();
            if (q != 'y') break;
        }
    }

}