using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Lab6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Company company = null;
            string exist = "";
            List<string> inicio = new List<string>() { "Welcome", "Create new company", "Load company from existing file", "Exit" };
            while (true)
            {
                Console.CursorVisible = false;
                string select = Control.Start(inicio);
                Console.Clear();
                if (select == inicio[1])
                {
                    company = Control.NewCompany();
                    try { Save(company); exist = "new"; break; }
                    catch (Exception) { exist = ""; }
                    Console.Clear();
                }

                else if (select == inicio[2])
                {
                    try
                    {
                        Console.Clear();
                        Company company2 = Control.NewCompany();
                        company = Load();
                        if (company.GetName() == company2.GetName() && company.GetRut() == company2.GetRut())
                        {
                            exist = "old";
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Company doesn't exist!");
                            Thread.Sleep(1300);
                            company = Control.NewCompany();
                            try { Save(company); exist = "new"; break; }
                            catch (Exception) { exist = ""; }
                            Console.Clear();
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Company doesn't exist!");
                        Thread.Sleep(1300);
                        company = Control.NewCompany();
                        try { Save(company); exist = "new"; break; }
                        catch (Exception) { exist = ""; }
                        Console.Clear();
                    }
                }

                else if (select == inicio[3])
                {
                    try { Save(company); }
                    catch (Exception) { }
                    Environment.Exit(0);
                }
            }

            if (exist == "new")
            {
                Console.Clear();
                // Crear 8 personas para cargos
                Person p1 = new Person("Michael", "Scott", "1", "Regional Manager");
                Person p2 = new Person("Pam", "Halpert", "2", "Office Admin");
                Person p3 = new Person("Jim", "Halpert", "3", "Sales Manager");
                Person p4 = new Person("Angela", "Martin", "4", "Head Accountant");
                Person p5 = new Person("Dwight", "Schrute", "5", "Sales/Ass. to the RM");
                Person p6 = new Person("Phyllis", "Vance", "6", "Sales");
                Person p7 = new Person("Oscar", "Martinez", "7", "Accountant");
                Person p8 = new Person("Kevin", "Malone", "8", "Accountant");

                Department scranton = new Department("Scranton", p1);
                Section office = new Section("Office", p2);
                Block sales = new Block("Sales", p3);
                Block acc = new Block("Accounting", p4);
                sales.AddEmployees(p5);
                sales.AddEmployees(p6);
                acc.AddEmployees(p7);
                acc.AddEmployees(p8);

                office.AddDivision(sales);
                office.AddDivision(acc);
                scranton.AddDivision(office);
                company.AddDivision(scranton);
                        
                try
                {
                    Save(company);
                    exist = "old";
                }
                catch (Exception)
                {
                    exist = "new";
                }
            }

            if (exist == "old")
            {
                Console.Clear();
                Control.NewShowInfo(company, Control.ShowInfoStart(company));
                Console.WriteLine("Press any key to continue: ");
                Console.Read();
                Console.Clear();
            }
                

            

        }


        public static void Save(Company company)
        {
            Stream stream = new FileStream("empresa.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, company);
            stream.Close();
        }

        public static Company Load()
        {
            Stream stream = new FileStream("empresa.bin", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            Company company = (Company)formatter.Deserialize(stream);
            stream.Close();

            return company;
        }
    }
}
