using Bethanys.Hrm.Server.Repositories;
using Bethanys.Hrm.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSingleton<IBenefitRepository, BenefitRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapGet("employee", (IEmployeeRepository repo) => repo.GetAllEmployees());

app.MapGet("benefit/{employeeId}", (int employeeId,
    IEmployeeRepository empRepo, IBenefitRepository benefitRepository) =>
{
    var employee = empRepo.GetEmployeeById(employeeId);
    return benefitRepository.GetForEmployee(employee);
});

app.MapPost("benefit/{employeeId}", (int employeeId, List<BenefitEmployeeModel> benefits,
    IEmployeeRepository empRepo, IBenefitRepository benefitRepository) =>
{
    var employee = empRepo.GetEmployeeById(employeeId);
    benefitRepository.UpdateForEmployee(employee, benefits);
});

app.MapFallbackToFile("index.html");

app.Run();
