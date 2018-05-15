using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ships;

namespace lab13
{
    class TestCollections
    {
        Queue<Ship> queueShip;
        Queue<string> queueString;
        SortedDictionary<Ship, SailingShip> dictShipSail;
        SortedDictionary<string, SailingShip> dictStringSail;
        public int Count { get { return queueString.Count; } }
        public SailingShip GenerateNewShip()
        {
            while (true)
            {
                SailingShip sailingShip = new SailingShip();
                if (!dictStringSail.ContainsKey(sailingShip.BaseShip.ToString()))
                    return sailingShip;
            }
        }
        private void GenerateCollections(int size)
        {
            queueShip = new Queue<Ship>(size);
            queueString = new Queue<string>(size);
            dictShipSail = new SortedDictionary<Ship, SailingShip>();
            dictStringSail = new SortedDictionary<string, SailingShip>();
            for (int i = 0; i < size;)
            {
                SailingShip curShip = new SailingShip();
                try { AddElem(curShip); i++; }
                catch { }
            }
        }
        public TestCollections (int size)
        {
            GenerateCollections(size);
        }
        public void FindElem(int pos)
        {
            try
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                Ship curShip = queueShip.ElementAt<Ship>(pos);
                Console.WriteLine("Поиск элемента {0} в коллекции Queue<Ship>", curShip);
                sw.Start();
                queueShip.Contains(curShip);
                sw.Stop();
                Console.WriteLine("Результат: {0}\n", sw.ElapsedMilliseconds/100.0);
                Console.WriteLine("Поиск элемента в коллекции Queue<string>");
                sw.Start();
                queueString.Contains(curShip.ToString());
                sw.Stop();
                Console.WriteLine("Результат: {0}\n", sw.ElapsedMilliseconds / 100.0);
                Console.WriteLine("Поиск элемента в коллекции SortedDictionary<Ship, SailingShip>");
                sw.Start();
                dictShipSail.ContainsKey(curShip);
                sw.Stop();
                Console.WriteLine("Результат (.ContainsKey): {0}", sw.ElapsedMilliseconds / 100.0);
                SailingShip curSailShip = dictShipSail[curShip];
                sw.Start();
                dictShipSail.ContainsValue(curSailShip);
                sw.Stop();
                Console.WriteLine("Результат (.ContainsValue): {0}\n", sw.ElapsedMilliseconds / 100.0);
                Console.WriteLine("Поиск элемента в коллекции SortedDictionary<string, SailingShip>");
                sw.Start();
                dictStringSail.ContainsKey(curShip.ToString());
                sw.Stop();
                Console.WriteLine("Результат (.ContainsKey): {0}", sw.ElapsedMilliseconds / 100.0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void FindElem(SailingShip elem)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            Console.WriteLine("Поиск элемента {0} в коллекции Queue<Ship>", elem);
            sw.Start();
            if (!queueShip.Contains(elem.BaseShip))
                Console.WriteLine("Элемент отсутствует в коллекции");
            sw.Stop();
            Console.WriteLine("Результат: {0}\n", sw.ElapsedMilliseconds / 100.0);
            Console.WriteLine("Поиск элемента в коллекции Queue<string>");
            sw.Restart();
            if (!queueString.Contains(elem.BaseShip.ToString()))
                Console.WriteLine("Элемент отсутствует в коллекции");
            sw.Stop();
            Console.WriteLine("Результат: {0}\n", sw.ElapsedMilliseconds / 100.0);
            Console.WriteLine("Поиск элемента в коллекции SortedDictionary<Ship, SailingShip>");
            sw.Restart();
            if (!dictShipSail.ContainsKey(elem.BaseShip))
                Console.WriteLine("Элемент с таким ключом отсутствует в коллекции");
            sw.Stop();
            Console.WriteLine("Результат (.ContainsKey): {0}", sw.ElapsedMilliseconds / 100.0);
            sw.Restart();
            if (!dictShipSail.ContainsValue(elem)) 
                Console.WriteLine("Элемент с таким значением отсутствует в коллекции");
            sw.Stop();
            Console.WriteLine("Результат (.ContainsValue): {0}\n", sw.ElapsedMilliseconds / 100.0);
            Console.WriteLine("Поиск элемента в коллекции SortedDictionary<string, SailingShip>");
            sw.Restart();
            if (!dictStringSail.ContainsKey(elem.BaseShip.ToString()))
                Console.WriteLine("Элемент с таким ключом отсутствует в коллекции");
            sw.Stop();
            Console.WriteLine("Результат (.ContainsKey): {0}", sw.ElapsedMilliseconds / 100.0);
        }
        public void AddElem(SailingShip elem)
        {
            if (dictStringSail.ContainsKey(elem.BaseShip.ToString()))
                throw new ContainException("Элемент с таким ключом уже существует в коллекции");
            Console.WriteLine("Элемент {0} добавлен в коллекции", elem);
            queueShip.Enqueue(elem.BaseShip);
            queueString.Enqueue(elem.BaseShip.ToString());
            dictShipSail.Add(elem.BaseShip, elem);
            dictStringSail.Add(elem.BaseShip.ToString(), elem);
        }
        public void RemoveElem()
        {
            if (queueString.Count == 0)
                throw new Exception("Коллекция пуста, удаление невозможно");
            Console.WriteLine("Элемент {0} удалён из коллекций", queueString.Peek());
            dictShipSail.Remove(queueShip.Peek());
            dictStringSail.Remove(queueString.Peek());
            queueShip.Dequeue();
            queueString.Dequeue();
        }
        public void ShowCollection()
        {
            Console.WriteLine("Сейчас коллекция выглядит так:");
            int iter = 0;
            if (dictShipSail.Count == 0)
                throw new EmptyException("Коллекция пуста");
            foreach (KeyValuePair<Ship, SailingShip> x in dictShipSail)
            {
                Console.WriteLine("Ключ элемента {0}\n{1}\n", iter + 1, x.Key);
                Console.WriteLine("Значение элемента {0}\n{1}\n", iter + 1, x.Value.ToString());
                Console.WriteLine("----------------------------------------------------------------------------");
                iter++;
            }
        }
    }
}
