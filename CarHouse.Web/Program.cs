using Microsoft.EntityFrameworkCore;
using CarHouse.DataAccess;
using CarHouse.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();
var connectionString = configuration.GetConnectionString("CarHouseDB");
builder.Services.AddDbContext<CarHouseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ISaleService, SaleService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeView}/{id?}");


app.Run();
