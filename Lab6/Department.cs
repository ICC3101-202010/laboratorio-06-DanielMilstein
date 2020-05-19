using System;
using System.Collections.Generic;
namespace Lab6
{
    [Serializable]
    public class Department : Division //div2
    {
        protected List<Division> Sections;

        public Department(string name, Person manager) : base(name, manager)
        {
            List<Division> divisions = new List<Division>();
            Sections = divisions;
        }

        public override void AddDivision(Division division)
        {
            try { Sections.Add(division); }
            catch { }
        }

        public override List<Division> GetDivisions()
        {
            return Sections;
        }

        public override List<Person> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public override void RemoveDivision(Division division)
        {
            try { Sections.Remove(division); }
            catch { }
        }
    }
}
