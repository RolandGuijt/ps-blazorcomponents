using Bethanys.Hrm.Shared;
using Microsoft.AspNetCore.Components;

namespace Bethanys.Hrm.Client.Components
{
    public partial class EmployeeEdit
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public EmployeeModel Employee { get; set; } = new EmployeeModel();
        private string Message = string.Empty;
        private string StatusClass = string.Empty;

        private Task HandleValidSubmit()
        {
            //Persist to API
            return Task.CompletedTask;
        }

        private void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        private void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
