using ASP_NET_Practice_4.Figures.Middleware;
using ASP_NET_Practice_4.Figures.Services.Abstract;
using ASP_NET_Practice_4.Figures.Services.Implementation;
using ASP_NET_Practice_4.Middleware;
using ASP_NET_Practice_4.Services.Abstract;
using ASP_NET_Practice_4.Services.Implementation;


/////////////////////////////////////////////
///ANIMALS
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IAnimal, Cat>();
builder.Services.AddTransient<IAnimal, Crab>();
builder.Services.AddTransient<IAnimal, Horse>();

builder.Services.AddTransient<AnimalService>();

//builder.Services.AddTransient<IAnimalSender, HtmlAnimalSender>();
builder.Services.AddTransient<IAnimalSender, JSONAnimalSender>();

//builder.Services.AddTransient<IAnimalsSender, HtmlAnimalsSender>();
//builder.Services.AddTransient<IAnimalsSender, JSONAnimalsSender>();




/////////////////////////////////////////////////
// Geometric figures
builder.Services.AddTransient<IFigure, Triangle>();
builder.Services.AddTransient<IFigure, Rectangle>();
builder.Services.AddTransient<IFigure, Pentagon>();

builder.Services.AddTransient<FiguresService>();

//builder.Services.AddTransient<IFiguresSender, HtmlFiguresSender>(); // Saving to HTML
//builder.Services.AddTransient<IFiguresSender, JsonFiguresSender>(); // Displaying as JSON file
builder.Services.AddTransient<IFiguresSender, SaveFigureXML>(); // Saving figure to file



var app = builder.Build();

//app.UseMiddleware<AnimalMiddleware>();
app.UseMiddleware<AnimalMiddleware2>();
//app.UseMiddleware<AnimalsMiddleware3>();


/////////////////////////////////////////////////
/// Figures
app.UseMiddleware<FiguresMiddleware>();




app.Run(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Not found");
});


app.Run();
