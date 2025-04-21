using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
/*namespace Read_strings*/

namespace lab2_1
{
    internal class ClassLab7
    {
        private string name;
        public ClassLab7()
        {
            name = "C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text10.txt";
        }

        public ClassLab7(string tourFile)
        {
            name = tourFile;
        }

        //заполнение файла числами в столбик
        private void completionRandom1(int n)
        {
            var random = new Random();
            using (StreamWriter writer = new StreamWriter(name))
            {
                for (int i = 0; i < n; i++)
                {
                    if (i != n - 1)
                    {
                        int number = random.Next(1, 101);
                        writer.WriteLine(number);
                    }
                    else
                    {
                        int number = random.Next(1, 101);
                        writer.Write(number);
                    }
                }
            }
        }

        //заполнение файла числами в строку
        private void completionRandom2(int n)
        {
            var random = new Random();
            StringBuilder sb = new StringBuilder();

            // Генерируем все числа и добавляем их в StringBuilder
            for (int i = 0; i < n; i++)
            {
                sb.Append(random.Next(1, 101));
                if (i < n - 1) // Добавляем пробел после всех чисел, кроме последнего
                {
                    sb.Append(" ");
                }
            }

            // Записываем всю строку в файл
            File.WriteAllText(name, sb.ToString());
        }

        //задание 1
        public float mulTwoNumber()
        {
            completionRandom1(10);
            try
            {
                StreamReader f = new StreamReader(name);
                string s = f.ReadToEnd();
                f.Close();

                if (string.IsNullOrEmpty(s))
                {
                    return 0;
                }

                string[] numbersStr = s.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                if (numbersStr.Length == 0)
                {
                    return 0;
                }

                float max = float.MinValue;
                float min = float.MaxValue;

                foreach (string numStr in numbersStr)
                {
                    if (float.TryParse(numStr, out float num))
                    {
                        if (num > max) max = num;
                        if (num < min) min = num;
                    }
                }

                // Проверяем, были ли найдены действительные числа
                if (max == float.MinValue || min == float.MaxValue)
                {
                    return 0;
                }

                return max * min;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        //задание 2
        public int numberOddNumbers()
        {
            completionRandom2(10);
            try
            {
                StreamReader f = new StreamReader(name);
                string s = f.ReadToEnd();
                string[] strNumbers = s.Split(' ');
                f.Close();
                int count = 0;

                int lenNumbers = strNumbers.Length;
                for (int i = 0; i < lenNumbers; i++)
                {
                    if (Int32.Parse(strNumbers[i]) % 2 == 1)
                    {
                        count++;
                    }
                }
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        //задание 3
        public int newFile()
        {
            try
            {
                StreamReader f = new StreamReader(name);
                string s;
                int lenStr;
                string newName = "C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\output.txt";
                StreamWriter w = new StreamWriter(newName);

                while ((s = f.ReadLine()) != null) 
                {
                    lenStr = s.Length;
                    w.WriteLine(lenStr);
                }
                w.Close();
                f.Close();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }


        private void completionRandomBin(int n)
        {
            var random = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open(name, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    int number = random.Next(1, 101);
                    writer.Write(number);
                }
            }
        }

        //задание 4
        public int binCopy()
        {
            string sourceFilePath = name;  // Исходный бинарный файл
            string outputFilePath = "C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\output.bin"; // Результирующий бинарный файл

            completionRandomBin(10);

            try
            {
                // Читаем все данные из исходного файла (предполагаем, что это массив int)
                byte[] sourceData = File.ReadAllBytes(sourceFilePath);

                // Проверяем, что данные корректны (должны быть кратны размеру int)
                if (sourceData.Length % sizeof(int) != 0)
                {
                    Console.WriteLine("Ошибка: некорректный размер файла (не кратен размеру char)");
                    return 0;
                }

                using (FileStream fs = new FileStream(outputFilePath, FileMode.Create))
                {
                    int totalNumbers = sourceData.Length / sizeof(int);
                    for (int i = 1; i <= totalNumbers; i++)
                    {
                        byte[] chunk = new byte[i * sizeof(int)];
                        Buffer.BlockCopy(sourceData, 0, chunk, 0, chunk.Length);
                        fs.Write(chunk, 0, chunk.Length);
                    }
                }

                Console.WriteLine($"Файл успешно сформирован: {outputFilePath}");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return 0;
            }
        }

        //задание 5
        public void binToys()
        {
            string binaryFilePath = "toys.dat";
            string xmlFilePath = "toys.xml";

            CreateAndSerializeToys(binaryFilePath, xmlFilePath);
            ProcessToyData(binaryFilePath, xmlFilePath);
        }

        //заполнение файла сериализация
        static void CreateAndSerializeToys(string binaryFilePath, string xmlFilePath)
        {
            // Создаем коллекцию игрушек
            var toyCollection = new ToyCollection();
            toyCollection.Toys.AddRange(new List<Toy>
            {
                new Toy { Name = "Конструктор", Price = 1500, MinAge = 3, MaxAge = 12 },
                new Toy { Name = "Кукла", Price = 800, MinAge = 2, MaxAge = 8 },
                new Toy { Name = "Велосипед", Price = 3500, MinAge = 4, MaxAge = 10 },
                new Toy { Name = "Пазл", Price = 600, MinAge = 4, MaxAge = 12 },
                new Toy { Name = "Мяч", Price = 300, MinAge = 1, MaxAge = 99 }
            });

            // XML-сериализация
            XmlSerializer serializer = new XmlSerializer(typeof(ToyCollection));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, toyCollection);
            }

            // Запись в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(binaryFilePath, FileMode.Create)))
            {
                foreach (var toy in toyCollection.Toys)
                {
                    writer.Write(toy.Name);
                    writer.Write(toy.Price);
                    writer.Write(toy.MinAge);
                    writer.Write(toy.MaxAge);
                }
            }
        }

        //чтение файлов и выбор игрушек сериализация
        static void ProcessToyData(string binaryFilePath, string xmlFilePath)
        {
            // XML-десериализация
            ToyCollection toyCollection;
            XmlSerializer serializer = new XmlSerializer(typeof(ToyCollection));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                toyCollection = (ToyCollection)serializer.Deserialize(fs);
            }

            // Поиск подходящих игрушек
            Console.WriteLine("Игрушки, подходящие и для 4-летних, и для 10-летних детей:");
            bool foundAny = false;

            foreach (Toy toy in toyCollection.Toys)
            {
                if (toy.MinAge >= 4 && toy.MaxAge <= 10)
                {
                    Console.WriteLine(toy);
                    foundAny = true;
                }
            }

            if (!foundAny)
            {
                Console.WriteLine("Подходящих игрушек не найдено.");
            }

            // Чтение из бинарного файла
            Console.WriteLine("\nДанные из бинарного файла:");
            using (BinaryReader reader = new BinaryReader(File.Open(binaryFilePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Toy toy = new Toy
                    {
                        Name = reader.ReadString(),
                        Price = reader.ReadDecimal(),
                        MinAge = reader.ReadInt32(),
                        MaxAge = reader.ReadInt32()
                    };
                    Console.WriteLine(toy);
                }
            }
        }

        // вставка элемента в список
        static List<T> InsertAfterFirst<T>(List<T> list, T element)
        {
            int index = list.IndexOf(element);

            if (index == -1)
            {
                return new List<T>(list); // E не найден, возвращаем копию исходного списка
            }

            List<T> newList = new List<T>(list);
            newList.InsertRange(index + 1, list); // Вставляем весь список L после E
            return newList;
        }

        // Заполняет список числами с клавиатуры
        static List<int> ReadIntListFromKeyboard()
        {
            List<int> list = new List<int>();
            Console.WriteLine("Введите элементы списка (целые числа). Для завершения введите пустую строку:");

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (int.TryParse(input, out int number))
                    list.Add(number);
                else
                    Console.WriteLine("Ошибка: введите целое число или пустую строку для завершения.");
            }
            return list;
        }

        // Заполняет список строками с клавиатуры
        static List<string> ReadStringListFromKeyboard()
        {
            List<string> list = new List<string>();
            Console.WriteLine("Введите элементы списка (строки). Для завершения введите пустую строку:");

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                list.Add(input);
            }
            return list;
        }

        // задание 6
        public void insertList()
        {
            Console.WriteLine("Выберите тип списка:");
            Console.WriteLine("1 Целые числа (int)");
            Console.WriteLine("2 Строки (string)");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                List<int> numbers = ReadIntListFromKeyboard();
                Console.Write("Введите элемент E (целое число): ");
                if (int.TryParse(Console.ReadLine(), out int e))
                {
                    List<int> result = InsertAfterFirst(numbers, e);
                    Console.WriteLine("Результат: " + string.Join(", ", result));
                }
                else
                    Console.WriteLine("Ошибка: введено не целое число.");
            }
            else if (choice == "2")
            {
                List<string> strings = ReadStringListFromKeyboard();
                Console.Write("Введите элемент E (строку): ");
                string e = Console.ReadLine();
                List<string> result = InsertAfterFirst(strings, e);
                Console.WriteLine("Результат: " + string.Join(", ", result));
            }
            else Console.WriteLine("Ошибка: выберите 1 или 2.");
        }

        // вставка в начало и в конец списка
        static List<T> InsertAfterAndBefore<T>(List<T> list, T element)
        {
            List<T> newList = new List<T>(list);
            newList.Add(element);
            newList.Insert(0, element); 
            return newList;
        }

        // задание 7
        public int insertAfterBeforeList()
        {
            Console.WriteLine("Выберите тип списка:");
            Console.WriteLine("1 Целые числа (int)");
            Console.WriteLine("2 Строки (string)");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                List<int> numbers = ReadIntListFromKeyboard();
                Console.Write("Введите элемент E (целое число): ");
                if (int.TryParse(Console.ReadLine(), out int e))
                {
                    List<int> result = InsertAfterAndBefore(numbers, e);
                    Console.WriteLine("Результат: " + string.Join(", ", result));
                }
                else
                    Console.WriteLine("Ошибка: введено не целое число.");
            }
            else if (choice == "2")
            {
                List<string> strings = ReadStringListFromKeyboard();
                Console.Write("Введите элемент E (строку): ");
                string e = Console.ReadLine();
                List<string> result = InsertAfterAndBefore(strings, e);
                Console.WriteLine("Результат: " + string.Join(", ", result));
            }
            else Console.WriteLine("Ошибка: выберите 1 или 2.");
            return 1;
        }


        // задание 8
        public int hashSetBook()
        {
            // Все существующие книги
            HashSet<string> allBooks = new HashSet<string>
            {
                "Война и мир", "Преступление и наказание",
                "1984", "Мастер и Маргарита", "Гарри Поттер"
            };

            // Книги, прочитанные каждым читателем
            List<HashSet<string>> readers = new List<HashSet<string>>
            {
                new HashSet<string> { "Война и мир", "1984", "Мастер и Маргарита" },
                new HashSet<string> { "Преступление и наказание", "1984" },
                new HashSet<string> { "1984", "Гарри Поттер" }
            };

            // 1. Книги, прочитанные ВСЕМИ читателями
            HashSet<string> readByAll = new HashSet<string>(readers[0]);
            for (int i = 1; i < readers.Count; i++)
            {
                readByAll.IntersectWith(readers[i]);
            }

            // 2. Книги, прочитанные ХОТЯ БЫ ОДНИМ читателем
            HashSet<string> readBySome = new HashSet<string>();
            foreach (var reader in readers)
            {
                readBySome.UnionWith(reader);
            }

            // 3. Книги, НЕ ПРОЧИТАННЫЕ НИ ОДНИМ читателем
            HashSet<string> readByNone = new HashSet<string>(allBooks);
            readByNone.ExceptWith(readBySome);

            // Вывод результатов
            Console.WriteLine("Книги, прочитанные ВСЕМИ читателями: " + string.Join(", ", readByAll));
            Console.WriteLine("Книги, прочитанные ХОТЯ БЫ ОДНИМ: " + string.Join(", ", readBySome));
            Console.WriteLine("Книги, НЕ ПРОЧИТАННЫЕ НИКЕМ: " + string.Join(", ", readByNone));
            return 1;
        }


        // задание 9
        public int hashSetText()
        {
            // Чтение текста из файла
            string text = File.ReadAllText(name, Encoding.UTF8);

            // Разбиваем текст на слова
            char[] separators = { ' ', ',', '.', '!', '?', ':', ';', '-', '\n', '\r', '\t' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length < 2)
            {
                Console.WriteLine("Файл содержит меньше двух слов. Невозможно выполнить анализ.");
                return 0;
            }

            // Первое слово и его символы
            string firstWord = words[0];
            HashSet<char> firstWordChars = new HashSet<char>(firstWord);

            // Символы, которые есть во всех остальных словах
            HashSet<char> commonCharsInOtherWords = null;

            // Обрабатываем все слова, кроме первого
            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];
                HashSet<char> wordChars = new HashSet<char>(word);

                if (commonCharsInOtherWords == null)
                {
                    commonCharsInOtherWords = new HashSet<char>(wordChars);
                }
                else
                {
                    commonCharsInOtherWords.IntersectWith(wordChars);
                }
            }

            // Символы, которых нет в первом слове, но есть во всех остальных
            HashSet<char> resultChars = new HashSet<char>(commonCharsInOtherWords);
            resultChars.ExceptWith(firstWordChars);

            // Вывод результата
            if (resultChars.Count == 0)
            {
                Console.WriteLine("Нет символов, которые отсутствуют в первом слове, но есть во всех остальных.");
            }
            else
            {
                Console.WriteLine("Символы, которых нет в первом слове, но есть во всех остальных:");
                foreach (char c in resultChars)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }
            return 1;
        }


        // задание 10
        public int olimpShcool()
        {
            string[] lines = File.ReadAllLines(name);
            int N = int.Parse(lines[0]);
            var participants = new List<Participant>();

            // Чтение данных участников
            for (int i = 1; i <= N; i++)
            {
                string[] parts = lines[i].Split(' ');
                string surname = parts[0];
                string name = parts[1];
                int grade = int.Parse(parts[2]);
                int score = int.Parse(parts[3]);

                participants.Add(new Participant(surname, name, grade, score));
            }

            // Сортировка участников по убыванию баллов 
            participants.Sort((p1, p2) => p2.Score.CompareTo(p1.Score));

            // Определение количества участников в топ 25%
            int top25PercentCount = (int)Math.Ceiling(participants.Count * 0.25);

            // Нахождение минимального балла в топ 25%
            int minScoreInTop25 = participants[top25PercentCount - 1].Score;

            // Проверка участников с таким же баллом ниже в списке
            int lastPrizeIndex = top25PercentCount - 1;
            while (lastPrizeIndex + 1 < participants.Count &&
                   participants[lastPrizeIndex + 1].Score == minScoreInTop25)
            {
                lastPrizeIndex++;
            }

            // Проверка условия: балл должен быть больше половины максимального
            if (minScoreInTop25 > 35)
            {
                // Создание списка призеров 
                List<Participant> prizeWinners = new List<Participant>();
                for (int i = 0; i <= lastPrizeIndex; i++)
                {
                    prizeWinners.Add(participants[i]);
                }

                int minPrizeScore = prizeWinners[prizeWinners.Count - 1].Score;

                // Подсчет призеров по классам
                var gradeCounts = new Dictionary<int, int>
                {
                    {7, 0},
                    {8, 0},
                    {9, 0},
                    {10, 0},
                    {11, 0}
                };

                foreach (var winner in prizeWinners)
                {
                    gradeCounts[winner.Grade]++;
                }

                // Вывод результатов
                Console.WriteLine(minPrizeScore);
                Console.WriteLine($"{gradeCounts[7]} {gradeCounts[8]} {gradeCounts[9]} {gradeCounts[10]} {gradeCounts[11]}");
            }

            return 1;
        }
    }
}
