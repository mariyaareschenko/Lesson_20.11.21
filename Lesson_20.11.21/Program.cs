using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson_20._11._21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 11.(1,2)");
            Console.WriteLine("Аккаунт Сида");
            long sids_num = Banking.Bank.CreatAccount();
            Banking.BankAccount sids = Banking.Bank.GetBankAccount(sids_num);
            TestPutMoney(sids);
            TestWithdrawMoney(sids);
            sids.PrintValues();
            PrintTransaction(sids);
            if (Banking.Bank.CloseAccount(sids_num))
            {
                Console.WriteLine("Аккаунта закрыт");
            }
            else
            {
                Console.WriteLine("Что-то пошло не так при закрытии счетa");
            }

            Console.WriteLine("Домашнее задание 11.(1,2)");
            Console.WriteLine("Дом 3/1");
            Console.WriteLine("Введите высоту здания");
            int height;
            while (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите кол-во этажей в здании");
            int count_floors;
            while (!int.TryParse(Console.ReadLine(), out count_floors))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите кол-во квартир в здании");
            int count_apat;
            while (!int.TryParse(Console.ReadLine(), out count_apat))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Console.WriteLine("Введите кол-во подъездов в здании");
            int count_entr;
            while (!int.TryParse(Console.ReadLine(), out count_entr))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            Build.Building building = new Build.Building(height, count_floors, count_apat, count_entr);
            int num_building = Build.Creator.CreateBuild();
            building.PrintValues();
            Build.Creator.DeleteBuilding(num_building);
            Console.ReadKey();
        }
        public static void TestPutMoney(Banking.BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите положить на счёт");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            acc.PutMoney(sum);
        }
        public static void TestWithdrawMoney(Banking.BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите снять со счёта");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (!acc.WithdrawMoney(sum))
            {
                Console.WriteLine("Невозможно снять данную сумму денег");
            }
        }
        static void PrintTransaction(Banking.BankAccount bank_account)
        {
            Console.WriteLine($"Transaction:");
            foreach (Banking.BankTransaction tran in bank_account.Transaction())
            {
                Console.WriteLine($"Date/Time: {tran.When()}. Summa: {tran.Summa()}");
            }
        }
    }
}
