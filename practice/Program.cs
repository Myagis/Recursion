using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Fd = "Modules.txt";
            StudyProgram Informatika = InOut.ReadData(Fd);
            InOut.Print(Informatika);

            Informatika.FindPossibleLists();
        }

    }
}
