using SDKTest.Data.Entities;
using SDKTest.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDKTest.BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IUnitOfWork unitOfWork;

        public EmployeeLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddEmployee(Employee employee)
        {

            unitOfWork.EmployeeRepository.Create(employee);
            unitOfWork.EmployeeRepository.Save();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return unitOfWork.EmployeeRepository.Get().ToList();
        }

        public IEnumerable<Traject> GetAllTrajects()
        {
            
            /*Test GetById */
            var trajectObtained = unitOfWork.TrajectRepository.GetByID(Guid.Parse("6c54cb75-b931-4637-b627-3c4792c53c59"));

            /*Test Delete*/
            unitOfWork.TrajectRepository.Delete(trajectObtained);
            unitOfWork.TrajectRepository.Save();

            /*Test Get with property*/
            var allTrajects = unitOfWork.TrajectRepository.Get(null, null, "Employee").ToList();

            return allTrajects;
        }

        public void AddEmployeeTravel(Guid employeeId, Traject traject)
        {
            Employee employee = unitOfWork.EmployeeRepository.Get(x => x.Id == employeeId).FirstOrDefault();

            if (employee == null)
                throw new Exception("Employee does not exist.");

            traject.Employee = employee;

            unitOfWork.TrajectRepository.Create(traject);
            unitOfWork.TrajectRepository.Save();
        }
    }
}
