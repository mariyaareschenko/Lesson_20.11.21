using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lesson_20._11._21
{
    namespace Build
    {
        public class Creator
        {
            public static Hashtable accounts = new Hashtable();
            public static int CreateBuild(int height, int count_floors, int count_apartments, int count_entrances)
            {
                Building building = new Building(height, count_floors, count_apartments, count_entrances);
                int number = building.UniqNumber();
                accounts[number] = building;
                return number;
            }
            public static int CreateBuild()
            {
                Building building = new Building();
                int number = building.UniqNumber();
                accounts[number] = building;
                return number;
            }
            public static void DeleteBuilding(int number)
            {
                accounts.Remove(number);
                Console.WriteLine("Здание удалено из таблицы");
            }
        }
    }
}
