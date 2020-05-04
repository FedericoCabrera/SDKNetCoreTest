using SDKTest.Data.Entities;


namespace SDKTest.Data.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Traject> TrajectRepository { get; }
    }
}
