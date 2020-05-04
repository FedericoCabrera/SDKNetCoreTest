using System;
using System.Collections.Generic;
using System.Text;
using SDKTest.Data.Entities;

namespace SDKTest.BusinessLogic
{
    public interface IEmployeeLogic
    {
        void AddEmployee(Employee employee);
        void AddEmployeeTravel(Guid employeeId, Traject traject);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Traject> GetAllTrajects();


    }
}
