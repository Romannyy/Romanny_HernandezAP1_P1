using Microsoft.EntityFrameworkCore;
using Romanny_HernandezAP1_P1.Components;
using Romanny_HernandezAP1_P1.DAL;
using Romanny_HernandezAP1_P1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtengo el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

// Agrego el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<EntradasHuacalesService>();
builder.Services.AddScoped<TipoHuacalesService>();
builder.Services.AddBlazorBootstrap();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
