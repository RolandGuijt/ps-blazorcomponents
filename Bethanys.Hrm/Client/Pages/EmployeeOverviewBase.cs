using Bethanys.Hrm.Client.ApiServices;
using Bethanys.Hrm.Shared;
using Microsoft.AspNetCore.Components;

namespace Bethanys.Hrm.Client.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
        [Inject]
        public IEmployeeApiService EmployeeApiService { get; set; }

        public List<EmployeeModel> Employees { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeApiService.GetAllEmployees()).ToList();
        }
    }
}
