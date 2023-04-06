using Bethanys.Hrm.Shared;

namespace Bethanys.Hrm.Server.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetEmployeeById(int employeeId);
    }
}
