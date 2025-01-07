using Ado.netpractice.Services;
using Ado.netpractice.Services.Table_Setup;
using Ado.netpractice.Services.User_Setup;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceDbConnection,DbConnection>();
builder.Services.AddScoped<IUser_setup, User_Setup>();
builder.Services.AddScoped<ITableSetup, TableSetup>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = "/User_Setup/User_Login";
        options.AccessDeniedPath = "/User_Setup/AccessDenied";

    });
builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("Username","susan acharya","vinay sonar"));
});
builder.Services.AddSession();

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
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User_Setup}/{action=User_Login}/{Id?}");

app.Run();
