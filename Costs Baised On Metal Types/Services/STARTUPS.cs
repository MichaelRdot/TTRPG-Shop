using Costs_Baised_On_Metal_Types.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costs_Baised_On_Metal_Types.Services
{
    public static class STARTUPS
    {
        public static METALTYPES adamantine = new METALTYPES("Adamantine", 10, 5, 5.2);
        public static METALTYPES adamant = new METALTYPES("Adamant", 10, 4, 5.9);
        public static METALTYPES argentium = new METALTYPES("Argentium", 9, 4, 7.9);
        public static METALTYPES brass = new METALTYPES("Brass", 3, 1, 6.4);
        public static METALTYPES bronze = new METALTYPES("Bronze", 5, 2, 6.5);
        public static METALTYPES celesteel = new METALTYPES("Celesteel", 16, 5, 29.8);
        public static METALTYPES celstialSteel = new METALTYPES("Celestial Steel", 8, 4, 5.9);
        public static METALTYPES chlorophyte = new METALTYPES("Chlorophyte", 9, 5, 6.3);
        public static METALTYPES cobalt = new METALTYPES("Cobalt", 7, 3, 6.6);
        public static METALTYPES coldIron = new METALTYPES("Cold Iron", 7, 4, 6.6);
        public static METALTYPES copper = new METALTYPES("Copper", 3, 1, 6.7);
        public static METALTYPES deepiron = new METALTYPES("Deepiron", 6, 3, 6.4);
        public static METALTYPES ebony = new METALTYPES("Ebony", 9, 4, 6.8);
        public static METALTYPES electrum = new METALTYPES("Electrum", 9, 3, 11.8);
        public static METALTYPES finimagus = new METALTYPES("Finimagus", 8, 4, 5.9);
        public static METALTYPES glassium = new METALTYPES("Glassium", 7, 4, 4.1);
        public static METALTYPES gold = new METALTYPES("Gold", 2, 3, 14.5);
        public static METALTYPES infernalIron = new METALTYPES("Infernal Iron", 8, 4, 5.9);
        public static METALTYPES iron = new METALTYPES("Iron", 7, 2, 5.9);
        public static METALTYPES lead = new METALTYPES("Lead", 2, 7, 8.5);
        public static METALTYPES mithril = new METALTYPES("Mithril", 9, 5, 2.3);
        public static METALTYPES mizzium = new METALTYPES("Mizzium", 10, 5, 5.2);
        public static METALTYPES orichalcum = new METALTYPES("Orichalcum", 11, 5, 4.3);
        public static METALTYPES palladium = new METALTYPES("Palladuim", 9, 4, 8.5);
        public static METALTYPES platinum = new METALTYPES("Platinum", 7, 4, 16.1);
        public static METALTYPES silver = new METALTYPES("Silver", 2, 2, 7.9);
        public static METALTYPES steel = new METALTYPES("Steel", 6, 2, 5.9);
        public static METALTYPES tin = new METALTYPES("Tin", 1, 1, 5.5);
        public static METALTYPES titanium = new METALTYPES("Titanium", 9, 4, 3.4);
        public static METALTYPES tungsten = new METALTYPES("Tungsten", 9, 3, 14.5);
        public static METALTYPES voidmetal = new METALTYPES("Voidmetal", 8, 5, 3.6);
        
        public static ARMORTYPES plate = new ARMORTYPES("Plate", 15, 1, 10, 6);
        public static ARMORTYPES splint = new ARMORTYPES("Splint", 14, 1, 3.5, 40);
    }
}
