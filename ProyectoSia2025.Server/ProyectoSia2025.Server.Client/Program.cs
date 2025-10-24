using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProyectoSia2025.Service.ServicesHTTP;
using ProyectoSia2025.Service.ServiciosHTTP;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IHttpService, HttpService>();

await builder.Build().RunAsync();
