using Ado.netpractice.Services;
using Ado.netpractice.Services.Table_Setup;
using Ado.netpractice.Services.User_Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceDbConnection,DbConnection>();
builder.Services.AddScoped<IUser_setup, User_Setup>();
builder.Services.AddScoped<ITableSetup, TableSetup>();

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
    pattern: "{controller=User_Setup}/{action=User_Login}/{Id?}");

app.Run();
