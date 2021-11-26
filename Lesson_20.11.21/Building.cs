using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_20._11._21
{
    namespace Build
    {
        public class Building
        {
            private int number;
            private static int uniq_num = 1;
            private int height;
            private int count_floors;
            private int count_apartments;
            private int count_entrances;
            public Building()
            {
                number = UniqNumber();
            }
            public Building(int height, int count_floors, int count_apartments, int count_entrances)
            {
                number = UniqNumber();
                this.height = height;
                this.count_floors = count_floors;
                this.count_apartments = count_apartments;
                this.count_entrances = count_entrances;
            }
            public int UniqNumber()
            {
                return uniq_num++;
            }
            public double HeightFloor(double height, double count_floors)
            {
                double height_floor;
                if (count_floors != 0)
                {
                    height_floor = height / count_floors;
                }
                else
                {
                    height_floor = height;
                }
                return height_floor;
            }
            public int CountApartmentsInEntrance(int count_apartments, int count_entrsnces)
            {
                int apart_entrance;
                if (count_entrsnces != 0)
                {
                    apart_entrance = count_apartments / count_entrsnces;
                }
                else
                {
                    apart_entrance = count_apartments;
                }
                return apart_entrance;
            }
            public int CountApartmentsOnFloor(int count_apartments, int count_floors)
            {
                int apat_floor;
                if (count_floors != 0)
                {
                    apat_floor = count_apartments / count_floors;
                }
                else
                {
                    apat_floor = count_apartments;
                }
                return apat_floor;
            }
            public void PrintValues()
            {
                Console.WriteLine($"Номер здания: {number}");
                Console.WriteLine($"Высота здания: {height}");
                Console.WriteLine($"Кол-во этажей в здании: {count_floors}");
                Console.WriteLine($"Кол-во квартир в здании: {count_apartments}");
                Console.WriteLine($"Кол-во подъездов в здании: {count_entrances}");
                Console.WriteLine($"Высота одного этажа: {HeightFloor(height, count_floors)}");
                Console.WriteLine($"Кол-во квартир в подъезде: {CountApartmentsInEntrance(count_apartments, count_entrances)}");
                Console.WriteLine($"Кол-во квартир на этаже: {CountApartmentsOnFloor(count_apartments, count_floors)}");
            }
        }
    }
}
