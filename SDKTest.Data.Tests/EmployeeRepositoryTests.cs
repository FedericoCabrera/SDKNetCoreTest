using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDKTest.Data.DataAccess;
using SDKTest.Data.Entities;
using SDKTest.Data.Repository;
using System;
using System.Linq;
using System.Collections;

namespace SDKTest.Data.Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void TestEmployeeAddOk()
        {
            var context = ContextFactory.GetMemoryContext(Guid.NewGuid().ToString());
            IRepository<Employee> employeeRepository = new Repository<Employee>(context);

            var id = Guid.NewGuid();
            Employee employee = new Employee() { Id = id, LastName = "Perez", Name = "Jorge" };

            employeeRepository.Create(employee);
            employeeRepository.Save();

            var employees = employeeRepository.Get(x=>x.Id==id).ToList();

            Assert.AreEqual(employees[0].Id, id);
        }
    }
}
