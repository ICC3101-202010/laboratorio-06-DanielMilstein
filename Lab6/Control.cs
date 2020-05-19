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
            List<string> newComp = new List<string>() { "Name: ", "Rut: ", "Go!", "Back" };
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

        public static string CompanyMenu(Company company)
        {
            List<string> menu = new List<string>() { $"Welcome to {company.GetName()}", "Add/Remove Employee",
                "Add/Remove Area", "Add/Remove Department", "Add/Remove section", "Add/Remove Block", "Show Info", "Back" };
            string sel = "";
            while (true)
            {
                sel = RegexUtilities.GetMenu(menu);
                if (sel != "") { return ""; }

            }

        }


        public static void MvEmployee(Company company)
        {

        }

        public static void MvDivision(Company company)
        {

        }

        public static void ShowEmployees(Division block)
        {
            
            
            List<Person> people = block.GetEmployees();
            Console.WriteLine("Employees: ");
            string n = RegexUtilities.Order("Name", "left");
            string j = RegexUtilities.Order("Job", "centre");
            string r = RegexUtilities.Order("Rut", "right");
            Console.WriteLine(n + j + r);
            foreach (Person emp in people)
            {
                string full = $"{emp.GetName()} {emp.GetLast()}";
                string fullName = RegexUtilities.Order(full, "left");
                string jp = RegexUtilities.Order(emp.GetJob(), "centre");
                string rp = RegexUtilities.Order(emp.GetRut(), "right");
                Console.WriteLine(fullName + jp + rp + "\n");
            }

            
            
        }

        public static void ShowDiv(Division division)
        {
            string div = division.GetName(); //Area o dpto
            Console.WriteLine("\n" + div + "\n");
            Console.WriteLine($"{div} Manager\n");
            string n = RegexUtilities.Order("Name", "left");
            string j = RegexUtilities.Order("Job", "centre");
            string r = RegexUtilities.Order("Rut", "right");
            Console.WriteLine(n + j + r);
            Person man = division.GetManager();
            string full = $"{man.GetName()} {man.GetLast()}";
            string fullName = RegexUtilities.Order(full, "left");
            string jp = RegexUtilities.Order(man.GetJob(), "centre");
            string rp = RegexUtilities.Order(man.GetRut(), "right");
            Console.WriteLine(fullName + jp + rp);
           
        }
        
        public static void NewShowInfo(Company company, bool start)
        {
            bool a = false;
            Console.WriteLine(company.GetName() + "\n");
            foreach (Division area in company.GetDivisions())
            {
                ShowDiv(area);
                foreach (Division dpto in area.GetDivisions())
                {
                    ShowDiv(dpto);
                    foreach (Division sec in dpto.GetDivisions())
                    {
                        ShowDiv(sec);
                        if (start == true)
                        {
                            foreach (Division block in sec.GetDivisions())
                            {
                                ShowDiv(block);
                                ShowEmployees(block);
                            }
                        }

                        else
                        {
                            ShowEmployees(sec);
                        }
                    }
                }
            }
            
        }

        public static bool ShowInfoStart(Company company)
        {
            try
            {
                foreach (Division area in company.GetDivisions())
                {
                    foreach (Division dpto in area.GetDivisions())
                    {
                        foreach (Division sec in dpto.GetDivisions())
                        {
                            foreach (Division blo in sec.GetDivisions())
                            {
                                
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }






        public static void ShowInfo(Company company)
        {
            Console.WriteLine(company.GetName() + "\n");
            foreach (Division area in company.GetDivisions())
            {
                string div = area.GetName(); //Area o dpto
                Console.WriteLine(div + "\n");
                Console.WriteLine($"{div} Manager\n");
                string n = RegexUtilities.Order("Name", "left");
                string j = RegexUtilities.Order("Job", "centre");
                string r = RegexUtilities.Order("Rut", "right");
                Console.WriteLine(n + j + r);
                Person man = area.GetManager();
                string full = $"{man.GetName()} {man.GetLast()}";
                string fullName = RegexUtilities.Order(full, "left");
                string jp = RegexUtilities.Order(man.GetJob(), "centre");
                string rp = RegexUtilities.Order(man.GetRut(), "right");
                Console.WriteLine(fullName + jp + rp);

                try
                {
                    List<Division> deps = area.GetDivisions(); //Depto o section
                    foreach (Division dep in deps)
                    {
                        string sDiv1 = dep.GetName();
                        Console.WriteLine(sDiv1 + "\n");
                        Console.WriteLine($"{sDiv1} Manager" + "\n");
                        n = RegexUtilities.Order("Name", "left");
                        j = RegexUtilities.Order("Job", "centre");
                        r = RegexUtilities.Order("Rut", "right");
                        Console.WriteLine(n + j + r);
                        man = dep.GetManager();
                        full = $"{man.GetName()} {man.GetLast()}";
                        fullName = RegexUtilities.Order(full, "left");
                        jp = RegexUtilities.Order(man.GetJob(), "centre");
                        rp = RegexUtilities.Order(man.GetRut(), "right");
                        Console.WriteLine(fullName + jp + rp);
                        try
                        {

                            List<Division> secs = dep.GetDivisions(); //Section o Block
                            foreach (Division sec in secs)
                            {
                                string sDiv2 = sec.GetName();
                                Console.WriteLine(sDiv2 + "\n");
                                Console.WriteLine($"{sDiv2} Manager" + "\n");
                                n = RegexUtilities.Order("Name", "left");
                                j = RegexUtilities.Order("Job", "centre");
                                r = RegexUtilities.Order("Rut", "right");
                                Console.WriteLine(n + j + r);
                                man = sec.GetManager();
                                full = $"{man.GetName()} {man.GetLast()}";
                                fullName = RegexUtilities.Order(full, "left");
                                jp = RegexUtilities.Order(man.GetJob(), "centre");
                                rp = RegexUtilities.Order(man.GetRut(), "right");
                                Console.WriteLine(fullName + jp + rp);
                                try
                                {
                                    

                                }
                                catch (Exception)
                                {

                                }
                                
                            }
                        }
                        catch (Exception)
                        {
                           ShowEmployees(dep);
                        }
                    }


                }
                catch (Exception)
                {

                }
            }
        }

        

    }
}
