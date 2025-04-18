using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    [Serializable]
    public class Toy
    {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int MinAge { get; set; }
            public int MaxAge { get; set; }

            public override string ToString()
            {
                return $"{Name} (Цена: {Price} руб., Возраст: {MinAge}-{MaxAge} лет)";
            }
    }
}
