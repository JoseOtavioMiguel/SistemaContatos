using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao conteiner
builder.Services.AddControllersWithViews();

// Configura a inje��o de dep�ncia do BancoContext
builder.Services.AddDbContext<BancoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
    
});

// Register the repository with the DI container
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();


var app = builder.Build();

// Configura o pipeline de solicita��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


