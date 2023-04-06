using Bethanys.Hrm.Shared;

namespace Bethanys.Hrm.Client.ApiServices
{
    public interface IEmployeeApiService
    {
        Task<IEnumerable<EmployeeModel>> GetAllEmployees();
    }
}
