using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_classes
{
    class Bank
    {
        public int shet; //Счёт пользователя //паблик чтобы обращаться к нему в класс програм
        private int shet1; // Счёт для перевода
        public string FIO; // Имя владельца счёта
        public double dengi;// Деньги пользователя
        private double dengi1; // Деньги, которые мы переводим
        public Bank[] schet = new Bank[3];
        private int[] id = new int[3] { 1, 2, 3 };
        private int id_number;
        private int i = 0;

        public void otkryt_shet(int i)
        {
            Random rnd = new Random();
            shet = rnd.Next(123235746, 234365687);
            Console.Write($"Здравствуйте! Приветствуем вас в банке Анютка! Спасибо, что выбрали нас. \nВот ваш номер счёта:{shet}");

            Console.Write("\nВведите ваше ФИО: ");
            FIO = Console.ReadLine();

            Console.Write("Введите изначальное количество денег, которое положите на счёт(Руб): ");
            dengi = Convert.ToSingle(Console.ReadLine());

            while (dengi < 0)
            {
                Console.WriteLine("Введите положительное число руб или 0 руб: ");
                dengi = Convert.ToDouble(Console.ReadLine());
            }

            id_number = id[i];
        }
        public void output(int shet, string FIO, double dengi)
        {
            Console.WriteLine("ИНФОРМАЦИЯ О СЧЁТЕ: ");
            Console.WriteLine($"Номер счёта:{shet}");
            Console.WriteLine($"ФИО владельца:{FIO}");
            Console.WriteLine($"Количество денег на счёте:{dengi} руб");
            Console.ReadKey();
        }
        public void operation_schet()
        {
            Console.WriteLine("\nВыберите счёт, на который хотите зайти: ");
            vyvod(schet, 5, 0);
            int vybor = Convert.ToInt32(Console.ReadLine()); //Выбираем номер счета
            int j = vybor - 1; //Представили номер счёта как индекс в массиве

            while (vybor > 3 || j < 0)
            {
                Console.WriteLine("Такого счёта не существует. Попробуйте ввести снова: ");
                vybor = Convert.ToInt32(Console.ReadLine()); //Выбираем номер счета
                j = vybor - 1; //Представили номер счёта как индекс в массиве
            }

            output(schet[j].shet, schet[j].FIO, schet[j].dengi); //обращаемся по индексу массива

            Console.WriteLine("\nВыберите действие:\n1.Положить деньги на счёт\n2.Снять деньги со счёта\n3.Обнулить счёт\n4.Перенести сумму с одного счёта на другой.\n5.Вывести счёт.\n6.Выход");
            int vybory = Convert.ToInt32(Console.ReadLine());

            switch (vybory)
            {
                case 1:
                    Console.WriteLine("Вы выбрали положить деньги на счёт.");
                    dob(j);
                    operation_schet();
                    break;
                case 2:
                    Console.WriteLine("Вы выбрали снять деньги со счёта.");
                    umen(j);
                    break;
                case 3:
                    Console.WriteLine("Вы выбрали обнулить счёт.");
                    obnul(j);
                    operation_schet();
                    break;
                case 4:
                    Console.WriteLine("Вы выбрали перенести сумму с одного счёта на другой");
                    Console.WriteLine("Выберите счет для перевода: ");
                    vyvod(schet, j, vybor);

                    int komu_perevodim = Convert.ToInt32(Console.ReadLine()); //выбрали счет для перевода
                    while (komu_perevodim - 1 == j || komu_perevodim > 3)
                    {
                        Console.Write("Введите заново: ");
                        komu_perevodim = Convert.ToInt32(Console.ReadLine()); //выбрали счет для перевода
                    }

                    Console.Write("Введите сумму для перевода: "); //сделать проверку на дурака: чтобы сумма перевода была меньше баланса
                    int dengi_perevod = Convert.ToInt32(Console.ReadLine());

                    while (dengi_perevod < 0 || schet[j].dengi < dengi_perevod)
                    {
                        Console.WriteLine("На вашем счете не хватает денег. Попробуйте снова:");
                        dengi_perevod = Convert.ToInt32(Console.ReadLine());
                    }

                    schet[komu_perevodim - 1].dengi += dengi_perevod; //переводим на выбранный счет деньги
                    schet[j].dengi -= dengi_perevod; //уменьшаем счет на ту сумму, которую перевели на другой счет
                    //обновить значения счетов после перевода

                    Console.WriteLine("\nИнформация о счете, на который переводились деньги: ");
                    output(schet[komu_perevodim - 1].shet, schet[komu_perevodim - 1].FIO, schet[komu_perevodim - 1].dengi);

                    Console.WriteLine("\nИнформация о счете, с которого переводились деньги: ");
                    output(schet[j].shet, schet[j].FIO, schet[j].dengi);
                    operation_schet();
                    break;
                case 5:
                    Console.WriteLine("Вы выбрали вывести счёт");
                    vyvod(schet, j, vybor);//Закидываем индекс по j(номер счёта)
                    operation_schet();
                    break;
                case 6:
                    Console.WriteLine("Вы выбрали выйти");
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
        private void dob(int j)
        {
            Console.Clear();
            Console.WriteLine("Сколько денег вы хотите внести на счёт?");
            float sum = sum = (float)Convert.ToDouble(Console.ReadLine()); //Переменная прибавки денег
            while (sum <= 0)

            {
                Console.WriteLine("Нельзя перевести отрицательное количество денег или равное 0. Попробуйте снова:");
                sum = sum = (float)Convert.ToDouble(Console.ReadLine());
                //umen(j);
            }

            schet[j].dengi += sum;

            Console.WriteLine($"Теперь на вашем счете {schet[j].dengi} руб");
            output(schet[j].shet, schet[j].FIO, schet[j].dengi);
        }
        private void umen(int j)
        {
            Console.Clear();
            Console.WriteLine("Сколько денег вы хотите вывести со счёта?");
            float minus = minus = (float)Convert.ToDouble(Console.ReadLine()); //Переменная вывода денег

            while (minus > schet[j].dengi || minus < 0)
            {
                Console.WriteLine("У вас не хватает денег для вывода. Попробуйте выбрать сумму поменьше.");
                minus = minus = (float)Convert.ToDouble(Console.ReadLine());
                //umen(j);
            }

            schet[j].dengi -= minus;


            Console.WriteLine($"Вот информация о вашем текущем счёте:");
            output(schet[j].shet, schet[j].FIO, schet[j].dengi);
        }
        private void vyvod(Bank[] schet, int j, int vybor)//Вывод всех счетов
        {
            for (int i = 0; i < schet.Length; i++)
            {
                if (i == j) //пропускаем того чела, с которого зашли на аккаунт
                {
                    continue;
                }
                else//Выводим номер счёта
                {
                    Console.WriteLine($"{schet[i].id_number}.{schet[i].shet}, {schet[i].FIO}");
                }
            }
        }
        private void obnul(int j)
        {
            Console.Clear();
            Console.WriteLine("Вы выбрали обнуление счёта.");
            double obnulenie = dengi; //Приравниваем деньги пользователя к обнулению
            schet[j].dengi = 0; //Вычитаем друг из друга. Обнуляем
            Console.WriteLine($"Теперь на вашем счете {schet[j].dengi} руб. Вот информация о вашем текущем счёте:");
            output(schet[j].shet, schet[j].FIO, schet[j].dengi);
        }
    }
}
