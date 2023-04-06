using Bethanys.Hrm.Shared;

namespace Bethanys.Hrm.Server.Repositories
{
    public class BenefitRepository : IBenefitRepository
    {
        private List<BenefitModel> _benefitModels = new List<BenefitModel>
        {
            new BenefitModel { BenefitId = 1, Description = "Health Insurance" },
            new BenefitModel { BenefitId = 2, Description = "Paid Time Off" },
            new BenefitModel { BenefitId = 3, Description = "Wellness", Premium= true },
            new BenefitModel { BenefitId = 4, Description = "Education", Premium= true },
            new BenefitModel { BenefitId = 5, Description = "Store Discount" }
        };


        public IEnumerable<BenefitEmployeeModel> GetForEmployee(EmployeeModel employee)
        {
            foreach (var benefit in _benefitModels)
            {
                var employeeBenefit = employee.Benefits
                    .SingleOrDefault(eb => eb.BenefitId == benefit.BenefitId);

                yield return new BenefitEmployeeModel
                {
                    BenefitId = benefit.BenefitId,
                    Selected = employeeBenefit != null,
                    Description = benefit.Description,
                    StartDate = employeeBenefit?.StartDate,
                    EndDate = employeeBenefit?.EndDate,
                    Premium = benefit.Premium
                };
            }
        }

        public void UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitEmployeeModel> model)
        {
            employee.Benefits.Clear();

            var benefits = model
                .Where(m => m.Selected)
                .Select(m => new EmployeeBenefit
                {
                    BenefitId = m.BenefitId,
                    EmployeeId = employee.EmployeeId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate
                });

            employee.Benefits.AddRange(benefits);
        }
    }
}
