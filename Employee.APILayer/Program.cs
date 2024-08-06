using Employee.ServiceLayer.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder().SetBasePath(System.Environment.CurrentDirectory).AddJsonFile("appsettings.json").Build();
string env = config.GetSection("Env").Value;
var configuration = new ConfigurationBuilder().SetBasePath(System.Environment.CurrentDirectory)
    .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true).Build();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDIService(builder.Configuration);

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
