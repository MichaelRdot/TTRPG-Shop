using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costs_Baised_On_Metal_Types.Types
{
    // WPI - Weight per ingot
    public class METALTYPES
    {
        string name;
        int hardness;
        int rarity;
        double wpi;
        public METALTYPES(string name, int hardness, int rarity, double wpi)
        {
            this.name = name;
            this.hardness = hardness;
            this.rarity = rarity;
            this.wpi = wpi;
            CONTAINERS.metals.Add(this);
        }
        public string GetMetalName() => this.name;
        public int GetMetalHardness() => this.hardness;
        public int GetMetalRarity() => this.rarity;
        public double GetWPI() => this.wpi;
        public int GetBaseHardness() => (this.rarity * 2) + 2;
        public string GetMetalRarityName()
        {
            switch (this.rarity)
            {
                case 1:
                    return "Common";
                case 2:
                    return "Uncommon";
                case 3:
                    return "Rare";
                case 4:
                    return "Very Rare";
                case 5:
                    return "Legendary";
                default:
                    return "Error";
            }
        }
    }
}
