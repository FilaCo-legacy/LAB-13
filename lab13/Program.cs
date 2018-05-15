using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab13
{
    class Program
    {
        /// <summary>
        /// Функция отображения консольного меню
        /// </summary>
        /// <param name="headLine"> Заголовок меню</param>
        /// <param name="items"> Элементы меню</param>
        /// <returns> Номер выбранного элемента меню (нумерация с нуля) </returns>
        static int Menu(string headLine, params string[] items)
        {
            Console.Clear();
            Console.WriteLine(headLine);
            int paragraph = 0, x = 2, y = 2, oldParagraph = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + i);
                Console.Write("{0}. {1}", i + 1, items[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldParagraph);
                Console.Write("{0}. {1}", oldParagraph + 1, items[oldParagraph] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + paragraph);
                Console.Write("{0}. {1}", paragraph + 1, items[paragraph]);

                oldParagraph = paragraph;

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        paragraph++;
                        break;
                    case ConsoleKey.UpArrow:
                        paragraph--;
                        break;
                    case ConsoleKey.Enter:
                        choice = true;
                        break;
                    case ConsoleKey k when k >= ConsoleKey.D1 && k <= ConsoleKey.D9:
                        paragraph = (int)k % (int)ConsoleKey.D1;
                        choice = true;
                        break;
                    case ConsoleKey k when k >= ConsoleKey.NumPad1 && k <= ConsoleKey.NumPad9:
                        paragraph = (int)k % (int)ConsoleKey.NumPad1;
                        choice = true;
                        break;
                }
                if (paragraph >= items.Length)
                    paragraph = 0;
                else if (paragraph < 0)
                    paragraph = items.Length - 1;
                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    Console.Clear();
                    break;
                }
            }
            Console.Clear();
            Console.CursorVisible = true;
            return paragraph;
        }
        static int ReadNaturalNum()
        {
            int inpNum;
            while (true)
            {
                try
                {
                    inpNum = Convert.ToInt32(Console.ReadLine());
                    return inpNum;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Внимание {0}! Попробуйте ещё раз", e.Message);
                }
            }
        }
        private static void InputName(SailingShip elem)
        {
            Console.WriteLine("Введите имя нового корабля (оставьте пустым для генерации с помощью ДСЧ):");
            string inpStr = Console.ReadLine();
            if (inpStr != "")
                elem.Name = inpStr;
        }
        private static void InputMaxSpeed(SailingShip elem)
        {
            Console.WriteLine("Введите максимальную скорость в узлах (оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.MaxSpeed = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputDateReleased(SailingShip elem)
        {
            Console.WriteLine("Введите дату выпуска корабля в формате дд/мм/гггг или дд.мм.гггг" +
                "(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.DateReleased = inpStr;
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfSails(SailingShip elem)
        {
            Console.WriteLine("Введите количество парусов корабля(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfSails = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static void InputNumOfMasts(SailingShip elem)
        {
            Console.WriteLine("Введите кол-во мачт парусника(оставьте пустым для генерации с помощью ДСЧ):");
            bool check = false;
            string inpStr = "";
            while (!check)
            {
                try
                {
                    inpStr = Console.ReadLine();
                    if (inpStr == "")
                        return;
                    elem.NumOfMasts = Convert.ToInt32(inpStr);
                    check = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    check = false;
                }
            }
        }
        private static SailingShip InputElemFromKeyboard()
        {
            SailingShip elem = new SailingShip();
            InputName(elem);
            InputMaxSpeed(elem);
            InputDateReleased(elem);
                InputNumOfSails(elem);
                InputNumOfMasts(elem);
            return elem;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(@"Вариант 14.
Иерархия классов: Ship->SailingShip
Коллекции: 
    1. Queue<Ship>
    2. Queue<string>
    3. SortedDictionary<Ship, SailingShip>
    4. SortedDictionary<string, SailingShip>
Для продолжения работы нажмите Enter...");
            Console.ReadLine();
            Console.WriteLine("Сколько элементов приготовить для работы?");
            int size = ReadNaturalNum();
            TestCollections test = new TestCollections(size);
            while (true)
            {
                switch (Menu("Выберите действие", "Показать коллекцию", "Добавить элемент", "Удалить элемент",
                    "Результаты поиска первого элемента", "Результаты поиска последнего элемента",
                    "Результаты поиска центрального элемента", "Результаты поиска несуществующего элемента",
                    "Вернуться к заданию коллекций", "Выход"))
                {
                    case 0:
                        test.ShowCollection();
                        break;
                    case 1:
                        test.AddElem(InputElemFromKeyboard());
                        break;
                    case 2:
                        test.RemoveElem();
                        break;
                    case 3:
                        test.FindElem(0);
                        break;
                    case 4:
                        test.FindElem(test.Count - 1);
                        break;
                    case 5:
                        test.FindElem(test.Count / 2);
                        break;
                    case 6:
                        test.FindElem(test.GenerateNewShip());
                        break;
                    case 8:
                        return;
                }
                Console.WriteLine("Для продолжения работы нажмите Enter...");
                Console.ReadLine();
            }
        }
    }
}
