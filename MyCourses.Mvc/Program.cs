using MyCourses.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

Course testCourse = new Course(1, 
    "Test Course", 
    "Test di funzionamento dei riferimenti incrociati tra progetti",
    "");

// app.MapGet("/", () => "Corso di test: " + testCourse);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}"
);

app.Run();
