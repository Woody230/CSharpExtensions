using System.Reflection;
using System.Text.Json.Serialization;
using Woody230.BindableEnum.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var name = Assembly.GetExecutingAssembly().GetName().Name;
    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{name}.xml");
    options.IncludeXmlComments(xmlPath);
});

builder.Services.ConfigureOptions<BindableEnumSwaggerGenOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// The program.
/// </summary>
public partial class Program 
{
    // Needed so test project can access the program.
}