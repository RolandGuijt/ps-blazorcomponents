using Bethanys.Hrm.Shared;
using System.Net.Http.Json;

namespace Bethanys.Hrm.Client.ApiServices
{
    public class BenefitApiService : IBenefitApiService
    {
        private readonly HttpClient _httpClient;

        public BenefitApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BenefitEmployeeModel>> GetForEmployee(EmployeeModel employee)
        {
            var result = await _httpClient.GetAsync($"/benefit/{employee.EmployeeId}");
            var benefits = await result.Content.ReadFromJsonAsync<List<BenefitEmployeeModel>>();
            if (benefits == null)
                return new List<BenefitEmployeeModel>();
            return benefits;
        }

        public async Task UpdateForEmployee(EmployeeModel employee, IEnumerable<BenefitEmployeeModel> benefits)
        {
            await _httpClient.PostAsJsonAsync($"benefit/{employee.EmployeeId}", benefits);
        }
    }
}
