using System;

namespace SDKTest.Data.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
}
