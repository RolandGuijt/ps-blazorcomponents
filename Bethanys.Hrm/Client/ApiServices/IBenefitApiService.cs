using Bethanys.Hrm.Shared;

namespace Bethanys.Hrm.Client.ApiServices
{
    public interface IBenefitApiService
    {
        Task<IEnumerable<BenefitEmployeeModel>> GetForEmployee(EmployeeModel employee);
        Task UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitEmployeeModel> benefits);
    }
}