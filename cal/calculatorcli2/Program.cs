
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace calculatorcli2
{
    class Program
    {
        static string filename = "histori.tex";
        static void Main(string[] args)
        {
            Console.WriteLine("برای دیدن سایقه  history و برای اتمام  finish را بزنید");
            while (true)
            {
                Console.WriteLine("نوع ورودی را مشخص کنید:1. عبارت کامل . 2. وارد کردن تک به تک  ");
                string entekhab= Console.ReadLine();
                if (entekhab.ToUpper() == "FINISH")
                {
                    break;
                }
                if(entekhab.ToUpper() == "HISTORY")
                {
                    showhystory();
                    continue;
                }
                string ebarat1 = "";
                if (entekhab.ToUpper() == "1")
                {
                    Console.WriteLine("عبارت خود را مانند نمونه وارد کنید:. نمونه: (مثال: 2/3*6+1)");
                    ebarat1=Console.ReadLine()?.Trim();
                }
                if (entekhab.ToUpper() == "2") 
                {
                    Console.WriteLine("می‌تونی با زدن ENTER بدون عدد، وارد کردن رو تموم کنی");
                    List<string> parts = new List<string>();
                    while (true)
                    {
                        Console.Write("عدد/عملگر/ پرانتز");
                        string part= Console.ReadLine()?.Trim();

                        if (string.IsNullOrEmpty(part)) break;
                        parts.Add(part);
                    }
                    ebarat1=string.Join(" ", parts);
                }
                if (!isvalidparantez(ebarat1))
                {
                    Console.WriteLine("پرانتز ها مشکل دارند!");
                    continue;
                }
                try
                {
                    var result = calculat(ebarat1);
                    Console.WriteLine("نتیجه = ",result);
                    savetohystory($"{ebarat1}={result}");
                }
                catch(Exception ex) 
                {
                    Console.WriteLine($"خطا {ex.Message}");
                }
            }
        }
        static void showhystory()
        {
            if (File.Exists(filename))
                Console.WriteLine(File.ReadAllText(filename));
            else
                Console.WriteLine("📭 فایل تاریخچه‌ای وجود ندارد.");
        }
        static bool isvalidparantez(string ebarat)
        {
             Stack<char> stack = new Stack<char>();
            foreach (char c in ebarat) 
            {
                if (c == '(') stack.Push(c);
                else if (c == ')')
                {
                    if (stack.Count == 0) return false;
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
        static void savetohystory(string result)
        {
            File.AppendAllText(filename, result + Environment.NewLine);
        }
        static double calculat(string ebarat1)
        {
            var dt = new DataTable();
            return Convert.ToDouble(dt.Compute(ebarat1,""));
        }

    }
}
