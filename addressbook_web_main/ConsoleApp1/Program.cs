using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using addressbook_web_main;

namespace addressbook_test_data_generation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count =Convert.ToInt32(args[0]);//тут передаем количество данных которые хотим сгенерировать
            System.Console.Out.Write("Hello World!");
            StreamWriter writer = new StreamWriter(args[1]);//(args[1])-потому что не указываем конкретное имяфайла, абудем указывать его все время разное при запуске
            for (int i = 1;i< count;i++)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",   //writer.WriteLine- чтобы строка автоматически завершилась перводом строки
                TestBase.GenerateRandomString(10),
                TestBase.GenerateRandomString(100),
                TestBase.GenerateRandomString(100)
                ));

        }
       
        }
    }
}