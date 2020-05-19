using System;
using System.Collections.Generic;

namespace Lab6
{
    public interface IDivide
    {
        void AddDivision(Division division);

        void RemoveDivision(Division division);

        List<Division> GetDivisions();

        List<Person> GetEmployees();
    }
}
