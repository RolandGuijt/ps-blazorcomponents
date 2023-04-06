using Bethanys.Hrm.Shared;

namespace Bethanys.Hrm.Server.Repositories
{
    public interface IBenefitRepository
    {
        IEnumerable<BenefitEmployeeModel> GetForEmployee(EmployeeModel employee);
        void UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitEmployeeModel> model);
    }
}