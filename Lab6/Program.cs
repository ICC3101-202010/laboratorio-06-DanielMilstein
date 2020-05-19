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
            List<string> inicio = new List<string>() {"Welcome","Create new company", "Load company from existing file", "Exit" };
            while (true)
            {
                Console.CursorVisible = false;
                string select = Control.Start(inicio);
                Console.Clear();
                if (select == inicio[1])
                {
                    company = Control.NewCompany();
                    try { Save(company); }
                    catch (Exception) { }
                }

                else if (select == inicio[2])
                {
                    try
                    {
                        company = Load();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Company doesn't exist!");
                        Thread.Sleep(1300);
                        company = Control.NewCompany();
                        try { Save(company); }
                        catch (Exception) { }
                    }
                }

                else if (select == inicio[3])
                {
                    try { Save(company); }
                    catch (Exception) { }
                    Environment.Exit(0);
                }
            }
            
        }




        public static void Save(Company company)
        {
            Stream stream = new FileStream("empresa.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, company);
            stream.Close();
        }

        public static Company Load()
        {
            Stream stream = new FileStream("empresa.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            Company company = (Company)formatter.Deserialize(stream);
            stream.Close();

            return company;
        }
    }
}
