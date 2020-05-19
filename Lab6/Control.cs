using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab6
{
    public static class Control
    {
        public static string Start(List<string> inicio)
        {
            
            string select = "";
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                select = RegexUtilities.GetMenu(inicio);

                if (select != "")
                {
                    break;
                }
            }

            return select;

        }



        public static Company NewCompany()
        {
            string name = "";
            string rut = "";
            List<string> newComp = new List<string>() { "Name: ", "Rut: ", "Create!", "Back" };
            Company company = null;


            while (true)
            {
                Console.Clear();
                string selComp = RegexUtilities.GetMenu(newComp);
                if (selComp == newComp[0])
                {
                    newComp[0] = newComp[0].Substring(0, 6);
                    Console.Clear();
                    Console.CursorVisible = true;
                    name = RegexUtilities.WriteData(newComp[0]);
                    newComp[0] += name;
                    Console.CursorVisible = false;
                }

                else if (selComp == newComp[1])
                {
                    newComp[1] = newComp[1].Substring(0, 5);
                    Console.Clear();
                    Console.CursorVisible = true;
                    rut = RegexUtilities.WriteData(newComp[1]);
                    newComp[1] += rut;
                    Console.CursorVisible = false;
                }

                else if (selComp == newComp[2])
                {
                    if (name != "" && rut != "")
                    {
                        try { company = new Company(name, rut); }
                        catch (Exception) { }
                        return company;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Information missing!");
                        Thread.Sleep(1300);
                    }

                    
                }

                else if (selComp == newComp[3])
                {
                    return null;
                }

            }
        }
    }
}
