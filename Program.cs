var builder = WebApplication.CreateBuilder(args);

// Add controllers and XML formatters
builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

var app = builder.Build();

// Enable controllers
app.MapControllers();

app.Run();