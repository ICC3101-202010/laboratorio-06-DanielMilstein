using System;
using System.Collections.Generic;
namespace Lab6
{
    [Serializable]
    public class Area : Division//div1
    {
        protected List<Division> Departments;

        public Area(string name, Person manager) : base(name, manager)
        {
            List<Division> divisions = new List<Division>();
            Departments = divisions;
        }

        
        public override void AddDivision(Division division)
        {
            try { Departments.Add(division); }
            catch { }
        }

        public override List<Division> GetDivisions()
        {
            return Departments;
        }

        public override List<Person> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public override void RemoveDivision(Division division)
        {
            try { Departments.Remove(division); }
            catch { }
        }
    }
}
