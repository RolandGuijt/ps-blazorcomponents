using Bethanys.Hrm.Shared;
using Microsoft.AspNetCore.Components;

namespace Bethanys.Hrm.Client.Components
{
    public class EmployeeRowBase : ComponentBase
    {
        [Parameter]
        public EmployeeModel Employee { get; set; } = default!;

        public void PremiumToggle(bool premiumBenefit)
        {
            Employee.HasPremiumBenefits = premiumBenefit;
        }
    }
}
