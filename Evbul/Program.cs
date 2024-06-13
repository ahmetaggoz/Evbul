using Evbul.Data.Abstract;
using Evbul.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddScoped<IYorumRepository, EfYorumRepository>();
builder.Services.AddScoped<IKullaniciRepository, EfKullaniciRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name:"ev_detay",
    pattern: "evler/detay/{url}",
    defaults: new {controller = "Evler", action = "Detay"}
);
app.MapControllerRoute(
    name:"ev_by_ozellik",
    pattern: "evler/ozellik/{ozellik}",
    defaults: new {controller = "Evler", action = "Index"}
);

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
