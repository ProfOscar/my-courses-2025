using MyCourses.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

Course testCourse = new Course(1, 
    "Test Course", 
    "Test di funzionamento dei riferimenti incrociati tra progetti",
    "");

app.MapGet("/", () => "Corso di test: " + testCourse);

app.Run();
