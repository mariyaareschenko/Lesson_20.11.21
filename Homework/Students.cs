using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    class Students
    {
        private string name;
        private string surname;
        private int num_group;
        public Students(string surname, string name, int num_group)
        {
            this.num_group = num_group;
            this.name = name;
            this.surname = surname;
        }
        internal static void Print(List<Students> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"{student.surname} {student.name} {student.num_group}");
            }
        }
        internal static void ChooseStudent(string str, List<Students> students, List<Students> students_lot)
        {
            bool is_found = false;
            foreach(var student in students)
            {
                if (student.name.Equals(str))
                {
                    students_lot.Add(student);
                    is_found = true;
                }
            }
            if (!is_found)
            {
                Console.WriteLine("Студент не найден");
            }
        }
        internal static bool ChekStudents(string str, List<Students> students_lot)
        {
            foreach(var student in students_lot)
            {
                if (student.name.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
        internal bool Won()
        {
            using (StreamReader reader = new StreamReader("result.txt"))
            {
                string temp;
                while((temp = reader.ReadLine()) != null)
                {
                    if (temp.Equals(GetInfo()))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        internal string GetInfo()
        {
            return $"{surname} {name} {num_group}";
        }
    }
}
