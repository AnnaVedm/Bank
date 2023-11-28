namespace Bank_classes
{
    class Program
    {
        //static Bank[] schet = new Bank[3];
        static void Main(string[] args)
        {
            Bank schet1 = new Bank();
            for (int i = 0; i < schet1.schet.Length; i++)
            {
                schet1.schet[i] = new Bank();
                schet1.schet[i].otkryt_shet(i);
                Console.Clear();
                schet1.schet[i].output(schet1.schet[i].shet, schet1.schet[i].FIO, schet1.schet[i].dengi); //обращаемся по инлексу массива
                //schet[i].operation_schet();
                Console.Clear();
            }
            output(schet1.schet);
            Console.ReadKey();
            schet1.operation_schet();
        }
        static void output(Bank[] schet)
        {
            for (int i = 0; i < schet.Length; i++) //Вывод каждого счёте
            {
                Console.WriteLine($"Счёт {i + 1}");
                //schet[i].output(schet1.shet, schet1.FIO, schet1.dengi); //так не работает
                schet[i].output(schet[i].shet, schet[i].FIO, schet[i].dengi); //обращаемся по инлексу массива

                Console.WriteLine();
            }
        }
    }
   
}



