var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Remove HTTPS redirection so to run tests using HTTP instead of HTTPS
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
