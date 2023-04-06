using Bethanys.Hrm.Shared;
using System.Net.Http.Json;

namespace Bethanys.Hrm.Client.ApiServices;
public class EmployeeApiService : IEmployeeApiService
{
    private readonly HttpClient _httpClient;

    public EmployeeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<EmployeeModel>> GetAllEmployees()
    {
        var result = await _httpClient.GetAsync($"employee");
        var employees = await result.Content.ReadFromJsonAsync<IEnumerable<EmployeeModel>>();
        if (employees == null)
            return new List<EmployeeModel>();
        return employees;
    }
}

