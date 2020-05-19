using System;
using System.Collections.Generic;

namespace Lab6
{
    [Serializable]
    public class Company
    {
        private string Name;
        private string Rut;
        private List<Division> Divisions;

        public Company(string name, string rut)
        {
            Name = name;
            Rut = rut;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetRut()
        {
            return Rut;
        }

        public List<Division> GetDivisions() { return Divisions; }

        public void AddDivision(Division division)
        {
            Divisions.Add(division);
        }

    }
}
