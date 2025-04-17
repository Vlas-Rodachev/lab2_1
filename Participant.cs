using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class Participant
    {
        public string Surname { get; }
        public string Name { get; }
        public int Grade { get; }
        public int Score { get; }

        public Participant(string surname, string name, int grade, int score)
        {
            Surname = surname;
            Name = name;
            Grade = grade;
            Score = score;
        }
    }
}
