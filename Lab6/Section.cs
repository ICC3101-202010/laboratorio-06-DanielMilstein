using System;
using System.Collections.Generic;
namespace Lab6
{
    [Serializable]
    public class Section : Division //div3
    {
        protected List<Division> Blocks;

        public Section(string name, Person manager) : base(name, manager)
        {
            List<Division> divisions = new List<Division>();
            Blocks = divisions;
        }

        public override void AddDivision(Division division)
        {
            try { Blocks.Add(division); }
            catch { }
        }

        public override List<Division> GetDivisions()
        {
            return Blocks;
        }

        public override List<Person> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public override void RemoveDivision(Division division)
        {
            try { Blocks.Remove(division); }
            catch { }
        }
    }
}
