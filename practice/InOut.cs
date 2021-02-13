using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace practice
{
    static class InOut
    {
        public static StudyProgram ReadData(string fileName)
        {
            List<Module> Modules = new List<Module>();
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
            int modulesAmount = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] Values = lines[i].Split(' ');
                string code = Values[0];
                string name = Values[1];
                int dependModAmount = int.Parse(Values[2]);

                List<string> dependentModCodes = new List<string>();
                if(dependModAmount !=0)
                {
                    for (int j = 3; j < Values.Length; j++)
                    {
                        dependentModCodes.Add(Values[j]);
                    }
                }
                
                Module newMod = new Module(code, name, dependModAmount, dependentModCodes);
                Modules.Add(newMod);
            }

            return new StudyProgram(modulesAmount, Modules);
        }

        public static void Print(StudyProgram informatika)
        {
            foreach(Module mod in informatika.Modules)
            {
                Console.WriteLine(mod.ToString());
            }
        }
    }
}
