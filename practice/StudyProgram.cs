using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public class StudyProgram
    {
        public int ModulesCount { get; private set; }
        public List<Module> Modules { get; private set; }

        public StudyProgram(int modulesCount, List<Module> modules)
        {
            this.ModulesCount = modulesCount;
            this.Modules = modules;
        }

        public void FindPossibleLists()
        {
            foreach (Module module in this.Modules)
            {
                if(module.DependentModAmount == 0)
                {
                    List<Module> newList = new List<Module>();
                    newList.AddRange(this.Modules);
                    //newList.Remove(module);
                    List<Module> emptyOne = new List<Module>();
                    RecusrionMethod(module, newList, emptyOne);
                    Console.WriteLine();
                    emptyOne.Clear();
                }
            }
        }

        public void RecusrionMethod(Module newElement, List<Module> options, List<Module> list)
        {
            list.Add(newElement);
            options.Remove(newElement);
            if (list.Count == 9)
            {
                foreach (var mod in list)
                {
                    Console.WriteLine(mod.ToString());
                    return;
                }
                
            }
            List<Module> possibleOptions = new List<Module>();
            foreach (var option in options)
            {
                if (option.IsPossibleOption(list))
                {
                    possibleOptions.Add(option);
                }
            }

            foreach (var op in possibleOptions)
            {
                //List<Module> newlist = options;
                //newlist.Remove(op);
                RecusrionMethod(op, options, list);
            }
        }

    }
}
