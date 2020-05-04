using SDKTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest.Data.DataAccess;
using SDKTest.Data.Repository;

namespace SDKTest.Data.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly SDKTestDbContext dbContext;

        public UnitOfWork()
        {
            disposed = false;
        }

        public UnitOfWork(SDKTestDbContext context)
        {
            dbContext = context;
            disposed = false;
        }

        private IRepository<Employee> employeeRepository;
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new Repository<Employee>(dbContext);

                return employeeRepository;
            }
        }

        private IRepository<Traject> trajectRepository;
        public IRepository<Traject> TrajectRepository
        {
            get
            {
                if (trajectRepository == null)
                    trajectRepository = new Repository<Traject>(dbContext);

                return trajectRepository;
            }
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
