using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public class Module
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int DependentModAmount { get; private set; }
        public List<string> DependentModCodes { get; private set; }

        public Module(string code, string name, int depenentModAmount, List<string> dependentModCodes)
        {
            this.Code = code;
            this.Name = name;
            this.DependentModAmount = depenentModAmount;
            this.DependentModCodes = dependentModCodes;
        }

        public override string ToString()
        {
            return string.Format("|{0,-10}|{1,-9}|{2,10}|{3,-10}|", this.Code, this.Name, this.DependentModAmount, this.DependentModCodes);
        }

        public bool IsPossibleOption(List <Module> currentList)
        {
            if(this.DependentModAmount == 0)
            {
                return true;
            }
            else if (this.DependentModAmount == 1)
            {
                foreach (var option in currentList)
                {
                    if(this.DependentModCodes[0] == option.Code)
                    {
                        return true;
                    }
                }
            }
            else if(this.DependentModAmount == 2)
            {
                int i = 0;
                foreach (var code in this.DependentModCodes)
                {
                    foreach (var option in currentList)
                    {
                        if(code == option.Code)
                        {
                            i++;
                        }
                    } 
                }
                if (i == 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
