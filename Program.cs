using System;
enum Coor
{
    A = 1, B, C, D, E, F, G, H
}
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Coordinate;
            Console.WriteLine("Введите координаты клетки");
            Coordinate = Console.ReadLine();
            while (true)
            {
                while (Coordinate.Length != 2) // проверка длины 
                {
                    Console.WriteLine("Неправильная запись. Координаты клетки состоит из 2-х символов. Например D5");
                    Coordinate = Console.ReadLine();
                }

                while (
                        !(int.TryParse(Coordinate.Substring(1, 1), out var number)) //Преобразование строкового представление числа в эквивалентное ему 32-разрядное целое число
                        ||
                        !(Enum.IsDefined(typeof(Coor), Coordinate.Substring(0, 1).ToUpper())) //проверка на существование заданного имени в виде строки в указанном перечислении.
                        ||
                        !(Enum.IsDefined(typeof(Coor), number)) //проверка на существование заданного значения в указанном перечислении.
                        )
                {
                    Console.WriteLine("Неправильная запись. Координаты клетки находятся в промежутке от 1 до 8 и от A до H");
                    Coordinate = Console.ReadLine();
                    if (Coordinate.Length != 2) //проверка длины
                    {
                        break; //завершение выполнения текущего цикла
                    }
                }

                if (Coordinate.Length != 2) //проверка длины
                {
                    continue;
                }
                break;
            }

            int vertical = Convert.ToInt32(Coordinate.Substring(1, 1)); //извлечение второго элемента строки 
            var aa = Enum.Parse(typeof(Coor), Coordinate.Substring(0, 1)); //Преобразование первого элемента строки в эквивалентный перечисляемый объект
            int horizontal = Convert.ToInt32(Enum.Format(typeof(Coor), aa, "d")); // Преобразование указанного значения указанного перечисляемого типа в его эквивалентное строковое представление 
            if (((vertical + horizontal) % 2) == 0)
            {
                Console.WriteLine("BLACK");
            }
            else
            {
                Console.WriteLine("WHITE");
            }
            Coordinate = Console.ReadLine();
        }
    }
}