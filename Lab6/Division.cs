using System;
using System.Collections.Generic;

namespace Lab6
{
    [Serializable]
    abstract public class Division : IDivide
    {
        protected string Name;
        protected Person Manager;

        public Division(string name, Person manager)
        {
            Name = name;
            Manager = manager;

        }

        public string GetName() { return Name; }

        public Person GetManager() { return Manager; }

        public abstract void AddDivision(Division division);
        public abstract void RemoveDivision(Division division);
        public abstract List<Division> GetDivisions();

        public abstract List<Person> GetEmployees();
    }
}
