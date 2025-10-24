using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Repository.Repositorios;
using ProyectoSia2025.Server.Client.Pages;
using ProyectoSia2025.Server.Components;
using ProyectoSia2025.Service.ServiciosHTTP;

var builder = WebApplication.CreateBuilder(args);
#region Configurar constructor de la aplicaci�n y sus servicios

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("El string de conexi�n no existe.");

builder.Services.AddDbContext<AppDbContext>(options =>
                      options.UseSqlServer(connectionString));


//builder.Services.AddScoped<IRepositorio<Empresas>, Repositorio<Empresas>>(); (desactivado para inyecci�n gen�rica)

builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddServerSideBlazor()
            .AddCircuitOptions(options => { options.DetailedErrors = true; });

#endregion

var app = builder.Build();
#region Construccion la aplicacion y �rea de middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.MapControllers();   
#endregion

app.Run();
