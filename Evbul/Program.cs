using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<EvbulContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IEvRepository, EfEvRepository>();
builder.Services.AddScoped<IOzellikRepository, EfOzellikRepository>();

var app = builder.Build();

app.UseStaticFiles();


SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute();


app.Run();
