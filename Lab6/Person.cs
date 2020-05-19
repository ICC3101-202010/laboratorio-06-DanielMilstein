using System;
namespace Lab6
{
    [Serializable]
    public class Person
    {
        private string Name;
        private string LastName;
        private string Rut;
        private string Job;
                     
        public Person(string name, string lastName, string rut, string job)
        {
            Name = name;
            LastName = lastName;
            Rut = rut;
            Job = job;
        }

        public string GetName() { return Name; }
        public string GetLast() { return LastName; }
        public string GetRut() { return Rut; }
        public string GetJob() { return Job; }

    }
}
