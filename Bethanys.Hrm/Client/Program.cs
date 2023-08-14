using Bethanys.Components;
using Bethanys.Hrm.Client;
using Bethanys.Hrm.Client.ApiServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
});
builder.Services.AddScoped<IEmployeeApiService, EmployeeApiService>();
builder.Services.AddScoped<IBenefitApiService, BenefitApiService>();

await builder.Build().RunAsync();
