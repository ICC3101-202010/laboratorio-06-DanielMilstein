using System;
using System.Collections.Generic;

namespace Lab6
{
    [Serializable]
    public class Block : Division //div4
    {
        protected List<Person> Employees;


        public Block(string name, Person manager) : base(name, manager)
        {
            List<Person> employees = new List<Person>();
            Employees = employees;
        }


        public override List<Person> GetEmployees() { return Employees; }

        public void AddEmployees(Person employee)
        {
            Employees.Add(employee);
                     
        }

        public override void AddDivision(Division division)
        {
            throw new NotImplementedException();
        }

        public override void RemoveDivision(Division division)
        {
            throw new NotImplementedException();
        }

        public override List<Division> GetDivisions()
        {
            throw new NotImplementedException();
        }
    }
}
