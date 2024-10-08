using Costs_Baised_On_Metal_Types;
using Costs_Baised_On_Metal_Types.Services;
using Costs_Baised_On_Metal_Types.Types;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
namespace Program
{
    class MAIN
    {
        static void Main(string[] args)
        {
            string userImput = null;
            bool finished = false;

            Console.WriteLine("Welcome to the shop. Plase imput what you would like to buy. When you are finished looking at your selections, please type 'done' to close the program." +
                "\nFor instructions on how to buy an item please type 'examples'." +
                "\nFor additional commands please type 'help'.");

            while (finished == false)
            {
                Console.WriteLine("");
                userImput = Console.ReadLine();
                METALTYPES metal = STARTUPS.steel;
                ARMORTYPES awe = STARTUPS.plate;

                switch (userImput)
                {
                    case "help":
                        Console.WriteLine("\nAfter imputing what you would like to buy, you may follow the statement with one of any of the following commands:" +
                            "\ntime - Displays the about of time it will take to craft the item by an average smith in days." +
                            "\nper hour - Displays the amount of Gold Per Hour the smith will need to make to agree to craft the item." +
                            "\nsmith's profit - Displays the total amount of Gold that the smith will get paid for crafting the item." +
                            "\ngp per ingot - Displays the amount of gold that it would take to buy one pound of the metal." +
                            "\nmetal weight in item - Displays the weight of the metal in the item." +
                            "\nac - Displays the AC of the armor type with the given metal.");
                        break;
                    case "examples":
                        Console.WriteLine("\nFirst, type the Metal Type followed by the item you would like to buy. Ex:" +
                            "\nsteel plate ac" +
                            "\ncost of item tin longsword" +
                            "\nadamanine arrow");
                        break;
                    case "done":
                        finished = true;
                        break;
                    case string print when userImput.Contains("print"):
                        switch (userImput)
                        {
                            case "print metals":
                                PrintList(CONTAINERS.metals);
                                break;
                            case "print armor":
                                PrintList(CONTAINERS.armors);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        foreach (Object obj in CONTAINERS.metals)
                        {
                            METALTYPES temp = obj as METALTYPES;
                            if (userImput.Contains(temp.GetMetalName(), StringComparison.OrdinalIgnoreCase))
                            {
                                metal = temp;
                                break;
                            }
                        }
                        foreach (Object obj in CONTAINERS.armors)
                        {
                            ARMORTYPES temp = obj as ARMORTYPES;
                            if (userImput.Contains(temp.GetArmorName(), StringComparison.OrdinalIgnoreCase))
                            {
                                awe = temp;
                                break;
                            }
                        }
                        double metalWeightInItem = awe.GetIngotsRequired() * metal.GetWPI();
                        switch (userImput)
                        {
                            case string CostOfItem when userImput.Contains("cost of item", StringComparison.OrdinalIgnoreCase):
                                costOfItem(metal.GetBaseHardness(), metal.GetMetalRarity(), metal.GetMetalHardness(), awe.GetIngotsRequired(), metalWeightInItem, metal.GetWPI(), awe.GetArmorTypeName());
                                break;
                            case string Time when userImput.Contains("time", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nIt will take {0} days to craft this item.", timeInDays(metal.GetMetalHardness(), awe.GetIngotsRequired()));
                                break;
                            case string PerHour when userImput.Contains("per hour", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nThe smith will get paid {0} GP per hour for this item.", GPPerHour(metal.GetMetalHardness(), awe.GetIngotsRequired()));
                                break;
                            case string SmithProfit when userImput.Contains("smith's profit", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nThe smith will get {0} GP of profit for crafting this item.", GPPerHour(metal.GetMetalHardness(), awe.GetIngotsRequired()) * timeInHours(metal.GetMetalHardness(), awe.GetIngotsRequired()));
                                break;
                            case string GPPerLB when userImput.Contains("gp per ingot", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nThe metal will cost {0} GP per pound.", GPPerIngot(metal.GetBaseHardness(), metal.GetMetalRarity(), metal.GetWPI()));
                                break;
                            case string MetalWeight when userImput.Contains("metal weight in item", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nThere are {0} pounds of metal in this item.", metalWeightInItem);
                                break;
                            case string AC when userImput.Contains("ac", StringComparison.OrdinalIgnoreCase):
                                Console.WriteLine("\nYou will have {0} base ac while wearing this armor.", awe.GetArmorBaseAC() + (metal.GetMetalHardness() / 2));
                                break;
                            default:
                                Console.WriteLine("\nThere has been an error with your imput.");
                                break;
                        }
                        break;
                }
            }
        }
        public static void PrintList(IEnumerable list)
        {
            Console.WriteLine("");
            if (list.Equals(CONTAINERS.metals))
            {
                Array array = CONTAINERS.metals.ToArray();
                foreach (Object obj in array)
                {
                    METALTYPES temp = obj as METALTYPES;
                    Console.Write("\n{0}:\nHardness - {1}\nRarity - {2}\n", temp.GetMetalName(), temp.GetMetalHardness(), temp.GetMetalRarityName());
                }
            }
            else if (list.Equals(CONTAINERS.armors))
            {
                Array array = CONTAINERS.armors.ToArray();
                foreach (Object obj in array)
                {
                    ARMORTYPES temp = obj as ARMORTYPES;
                    Console.Write("\n{0}:\nHardness - {1}\nRarity - {2}\n", temp.GetArmorName());
                }
            }
            else
            {
                foreach (Object obj in list) { Console.Write("{0}\n", list); }
            }
            Console.WriteLine();
        }
        public static double GPPerIngot(int baseHardness, int rarity, double weightPerIngot)
        { return Math.Round(weightPerIngot * Math.Pow(baseHardness, rarity) / 20, 3); }
        public static double GPPerHour(int hardness, double ingotsRequired)
        { return Math.Round((hardness * ingotsRequired) / 10, 3); }
        public static double timeInDays(double hardness, double ingotsRequired)
        { return Math.Round((hardness * ingotsRequired) / 2, 3); }
        public static double timeInHours(int hardness, double ingotsRequired)
        { return Math.Round(timeInDays(hardness, ingotsRequired) * 8, 3); }
        public static void costOfItem(int baseHardness, int rarity, int hardness, double ingotsRequired, double metalWeightInItem, double weightPerIngot, string AWE)
        {
            int temp = 1;
            switch (AWE)
            {
                case "weapon":
                    temp = 4;
                    break;
                case "everythingElse":
                    temp = 8;
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n{0} Lbs per ingot * ({1} base hardness rating ^ {2} rarity value) / 20 = {3} GP per ingot", weightPerIngot, baseHardness, rarity, GPPerIngot(baseHardness, rarity, weightPerIngot));
            Console.WriteLine("({0} hardness rating * {1} ingots required) / 10 = {2} GP per hour for blacksmith", hardness, ingotsRequired, GPPerHour(hardness, ingotsRequired));
            Console.WriteLine("{0} hardness rating * {1} ingots required * {2} Lbs of metal weight in item / 2 = {3} days * 8 = {4} hours", hardness, ingotsRequired, metalWeightInItem, timeInDays(hardness, ingotsRequired), timeInHours(hardness, ingotsRequired));
            Console.WriteLine("{0} GP per Ingot * {1} ingots required + {2} GP per hour * {3} hours = {4} GP for item", GPPerIngot(baseHardness, rarity, weightPerIngot), ingotsRequired, GPPerHour(hardness, ingotsRequired), timeInHours(hardness, ingotsRequired), Math.Round((GPPerIngot(baseHardness, rarity, weightPerIngot) * ingotsRequired + GPPerHour(hardness, ingotsRequired) * timeInHours(hardness, ingotsRequired)) / temp, 2));
            return;
        }
    }
}