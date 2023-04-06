using Bethanys.Hrm.Client.ApiServices;
using Bethanys.Hrm.Shared;
using Microsoft.AspNetCore.Components;

namespace Bethanys.Hrm.Client.Components
{
    public class BenefitSelectorBase : ComponentBase
    {
        protected bool SaveButtonDisabled { get; set; } = true;
        protected IEnumerable<BenefitEmployeeModel> Benefits { get; set; }

        [Parameter]
        public EmployeeModel Employee { get; set; }

        [Parameter]
        public EventCallback<bool> OnPremiumToggle { get; set; }

        [Inject]
        public IBenefitApiService BenefitApiService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Benefits = await BenefitApiService.GetForEmployee(Employee);
        }


        public async Task CheckBoxChanged(ChangeEventArgs e, BenefitEmployeeModel benefit)
        {
            var newValue = (bool)e.Value;
            benefit.Selected = newValue;
            SaveButtonDisabled = false;

            if (newValue)
            {
                benefit.StartDate = DateTime.Now;
                benefit.EndDate = DateTime.Now.AddYears(1);
            }
            await OnPremiumToggle.InvokeAsync(Benefits.Any(b => b.Premium && b.Selected));
        }

        public async Task SaveClick()
        {
            await BenefitApiService.UpdateForEmployee(Employee, Benefits);
            SaveButtonDisabled = true;
        }
    }
}
