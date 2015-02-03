/*
 *  Shamanus simple clicker v0.1.
 *  Absolute FREE, without SMS.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ShmClicker
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.Write("Кнопка для повторения: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            double delay;
            Console.Write("Задерку в секундах: ");
            if (!double.TryParse(Console.ReadLine(), out delay))
            {
                Console.WriteLine("Случился косяк с вводом. Enter - выход.");
                Console.ReadLine();
                return 1;
            }

            double count;
            Console.Write("Количество повторений (Пусто - бесконечный цикл): ");
            if (!double.TryParse(Console.ReadLine(), out count))
            {
                count = double.PositiveInfinity;
            }
            
            string tmp_count = count.ToString() + " раз";
            
            if (count == double.PositiveInfinity)
            {
                tmp_count = "бесконечно";
            }

            Console.WriteLine();
            Console.WriteLine("Итого: Кнопка {0}, повторять {1}, с задержкой {2} секунд",key.KeyChar,tmp_count,delay);
            Console.WriteLine("Enter для старта:");
            Console.ReadLine();

            Console.WriteLine("Обратный отсчет:");
            for (int i = 5; i > 0; i--) // wait 5 sec
            {
                Console.Write(" {0} ",i);
                Thread.Sleep(1 * 1000); // 1 sec
            }
            Console.WriteLine();
            Console.WriteLine("Поехали!");

            for (int i = 0; i < count; i++) 
            {
                Console.WriteLine(" {0}: Нажал {1}.",i,key.KeyChar);
                SendKeys.SendWait(key.KeyChar.ToString());
                Thread.Sleep(Convert.ToInt32(delay * 1000));
            }

            Console.WriteLine("Все! Enter для выхода.");

            Console.ReadLine();
            return 0;
        }
    }
}
