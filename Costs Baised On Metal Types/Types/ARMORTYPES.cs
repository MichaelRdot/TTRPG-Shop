using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costs_Baised_On_Metal_Types.Types
{
    public class ARMORTYPES
    {
        string name;
        int baseAC;
        int type;
        double ingotsRequired;
        double baseWeight;
        public ARMORTYPES(string name, int baseAC, int type, double ingotsRequired, double baseWeight)
        {
            this.name = name;
            this.baseAC = baseAC;
            this.type = type;
            this.ingotsRequired = ingotsRequired;
            this.baseWeight = baseWeight;
            CONTAINERS.armors.Add(this);
        }
        public string GetArmorName() => this.name;
        public int GetArmorBaseAC() => this.baseAC;
        public int GetArmorType() => this.type;
        public double GetIngotsRequired() => this.ingotsRequired;
        public double GetBaseWeight() => this.baseWeight;
        public string GetArmorTypeName()
        {
            switch (this.type)
            {
                case 1:
                    return "Heavy";
                case 2:
                    return "Medium";
                case 3:
                    return "Light";
                default:
                    return "Error";
            }
        }
    }
}
