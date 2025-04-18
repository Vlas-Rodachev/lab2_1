using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    internal class IntInputValidator
    {
        public static int GetValidIntInput()
        {
            int result;
            while (true)
            {
                Console.Write("Введите значение: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Ошибка! Неверное значение. Попробуйте снова.");
                }
            }
        }
    }
}
