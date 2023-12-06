using Laboratorium_3.Models;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Identity;
using Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("Labolatorium_3ContextConnection") ?? throw new InvalidOperationException("Connection string 'Labolatorium_3ContextConnection' not found."); z jest brains

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IContactService, MemoryContactService>();
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
builder.Services.AddSingleton<IBookService, MemoryBookService>();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient<IBookService, EFBookService>();
//builder.Services.AddTransient<IContactService, EFContactService>(); nwm czy potrzeba to
builder.Services.AddRazorPages(); //last lab
builder.Services.AddSession(); //last lab



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection(); //nwm czy dobtze dodalem jak nie dzia³a  cos to przez to
app.UseStaticFiles();

app.UseRouting();      ///////last lab
app.UseMiddleware<LastVisitCookie>();
app.UseAuthentication();;
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

///////////

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
