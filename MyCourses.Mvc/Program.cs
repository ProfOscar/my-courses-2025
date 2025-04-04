using MyCourses.Models;
using MyCourses.Models.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICourseService, CourseService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

// app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
