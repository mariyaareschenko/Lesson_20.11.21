using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Students>();
            using (StreamReader reader = new StreamReader("Students.txt"))
            {
                string temp;
                while(!string.IsNullOrEmpty(temp = reader.ReadLine()))
                {
                    string surname = temp.Substring(0, temp.IndexOf(' '));
                    temp = temp.Remove(0, temp.IndexOf(' ')+1);
                    string name = temp.Substring(0, temp.IndexOf(' '));
                    int num_group;
                    if(int.TryParse(temp[temp.Length - 1].ToString(), out num_group))
                    {
                        num_group = 1;
                    }
                    students.Add(new Students(surname, name, num_group));
                }
            }
            using (StreamReader reader_lot = new StreamReader("lot.txt"))
            {
                string info;
                while (!string.IsNullOrEmpty(info = reader_lot.ReadLine()))
                {
                    List<Students> students_lot = new List<Students>();
                    List<string> winners = new List<string>();
                    Console.WriteLine("Информация о розыгрыше: ");
                    Console.WriteLine(info);
                    info = info.Replace(" ", "");
                    int tickets;
                    if(!int.TryParse(info[info.Length-1].ToString(), out tickets))
                    {
                        Console.WriteLine("Неверная запись билетов");
                        tickets = 0;
                    }
                    bool flag = true;
                    int temp = 0;
                    while (flag && temp < students.Count)
                    {

                        Console.WriteLine("Введите имена участников розыгрыша или 'выход'");
                        Students.Print(students);
                        string str = Console.ReadLine();
                        if (str.ToLower().Equals("выход"))
                        {
                            flag = false;
                            continue;
                        }
                        else if (Students.ChekStudents(str, students_lot))
                        {
                            Console.WriteLine("Студент уже участвует в конкурсе");
                            continue;
                        }
                        Students.ChooseStudent(str, students, students_lot);
                        Console.WriteLine("Студент добавлен в список участников");
                        temp++;
                    }
                    Console.Clear();
                    Console.WriteLine("Участники распределены. Начинается лотерея");
                    Random r = new Random();
                    while (tickets > 0 && (students_lot.Count > 0))
                    {
                        for (int i = 0; i < students_lot.Count; i++)
                        {
                            double chance = 100 / students_lot.Count;
                            if (students_lot[i].Won())
                            {
                                if(r.Next(101) < chance / 2)
                                {
                                    tickets--;
                                    winners.Add(students_lot[i].GetInfo());
                                    students_lot.Remove(students_lot[i]);
                                }
                            }
                            else if(r.Next(101) < chance)
                            {
                                tickets--;
                                winners.Add(students_lot[i].GetInfo());
                                students_lot.Remove(students_lot[i]);
                            }
                        }
                    }
                    File.AppendAllText("result.txt", info + "\n");
                    File.AppendAllLines("result.txt", winners);
                }
            }
        }
    }
}
