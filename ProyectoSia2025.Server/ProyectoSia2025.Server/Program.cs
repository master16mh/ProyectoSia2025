using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.Server.Client.Pages;
using ProyectoSia2025.Server.Components;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("El string de conexión no existe.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ProyectoSia2025.Server.Client._Imports).Assembly);

app.Run();
