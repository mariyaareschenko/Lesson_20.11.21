using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    class Lottery
    {
        internal static void Print()
        {
            using (StreamReader reader = new StreamReader("lot.txt"))
            {
                Console.WriteLine("Информация о розыгрыше:");
                Console.WriteLine(reader.ReadLine());
            }

        }
    }
}
