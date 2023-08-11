using Bethanys.Components;
using Bethanys.Hrm.Client.ApiServices;
using Bethanys.Hrm.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Bethanys.Hrm.Client.Components
{
    public partial class BenefitSelector
    {
        private bool SaveButtonDisabled = true;

        private List<DateField> dateFieldRefs = new List<DateField>();
        private DateField dateFieldRef { set { dateFieldRefs.Add(value); } }

        private IEnumerable<BenefitEmployeeModel> benefits = null;
        [Inject]
        public IBenefitApiService BenefitApiService { get; set; }

        [CascadingParameter]
        public Theme Theme { get; set; }

        [Parameter]
        public EmployeeModel Employee { get; set; }

        [Parameter]
        public EventCallback<bool> OnPremiumToggle { get; set; }

        private async Task RevertClick()
        {
            foreach (var dateRef in dateFieldRefs)
                await dateRef.Revert();
        }

        public async Task CheckBoxChanged(ChangeEventArgs e,
            BenefitEmployeeModel benefit)
        {
            var newValue = e.Value != null && (bool)e.Value;
            benefit.Selected = newValue;
            SaveButtonDisabled = false;

            if (newValue)
            {
                benefit.StartDate = DateTime.Now;
                benefit.EndDate = DateTime.Now.AddYears(1);
            }
            await OnPremiumToggle.InvokeAsync(
                benefits.Any(b => b.Premium && b.Selected));
        }

        public async Task SaveClick()
        {
            await BenefitApiService.UpdateForEmployee(Employee, benefits);
            SaveButtonDisabled = true;
        }

        protected override async Task OnInitializedAsync()
        {
            benefits = 
                await BenefitApiService.GetForEmployee(Employee);
        }
    }
}
