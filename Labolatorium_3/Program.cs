using Labolatorium_3.Models;
using Laboratorium_3.Models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IContactService, MemoryContactService>();
builder.Services.AddSingleton<IDateTimeProvider, CurrentDateTimeProvider>();
builder.Services.AddSingleton<IBookService, MemoryBookService>();
builder.Services.AddDbContext<Data.AppDbContext>();
builder.Services.AddTransient<IBookService, EFBookService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
