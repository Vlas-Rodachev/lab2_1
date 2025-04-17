using lab2_1;

string name = "output.txt";

bool tr1 = true;
while (tr1)
{
    Console.WriteLine("Введите номер задания");
    Console.WriteLine("1 - Произведение максимального и минимального числа в файле");
    Console.WriteLine("2 - Кол-во нечетных чисел в файле");
    Console.WriteLine("3 - Новый файл где строки это длины строк исходного");
    Console.WriteLine("4 - Новый бинарный файл");
    Console.WriteLine("5 - Игрушки");
    Console.WriteLine("6 - Вставка списка после элемента");
    Console.WriteLine("7 - Элемент в начало и конец списка");
    Console.WriteLine("8 - Книги");
    Console.WriteLine("9 - Текст на русском языке");
    Console.WriteLine("10 - Олимпиада");
    Console.WriteLine("0 - выход");
    int number_problem = IntInputValidator.GetValidIntInput();
    if (number_problem == 1)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text1.txt");
        Console.WriteLine(l.mulTwoNumber());
        Console.WriteLine();
    }
    else if (number_problem == 2)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text2.txt");
        Console.WriteLine(l.numberOddNumbers());
        Console.WriteLine();
    }
    else if (number_problem == 3)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text3.txt");
        Console.WriteLine(l.newFile());
        Console.WriteLine();
    }
    else if (number_problem == 4)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text4.bin");
        Console.WriteLine(l.binCopy());
        Console.WriteLine();
    }
    else if (number_problem == 5)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text5.bin");
        l.binToys();
        Console.WriteLine();
    }
    else if (number_problem == 6)
    {
        ClassLab7 l = new ClassLab7();
        l.insertList();
        Console.WriteLine();
    }
    else if (number_problem == 7)
    {
        ClassLab7 l = new ClassLab7();
        Console.WriteLine(l.insertAfterBeforeList());
        Console.WriteLine();
    }
    else if (number_problem == 8)
    {
        ClassLab7 l = new ClassLab7();
        Console.WriteLine(l.hashSetBook());
        Console.WriteLine();
    }
    else if (number_problem == 9)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text9.txt");
        Console.WriteLine(l.hashSetText());
        Console.WriteLine();
    }
    else if (number_problem == 10)
    {
        ClassLab7 l = new ClassLab7("C:\\Users\\roda4\\OneDrive\\Рабочий стол\\lab_c#\\text10.txt");
        Console.WriteLine(l.olimpShcool());
        Console.WriteLine();
    }
    else
    {
        tr1 = false;
    }
}