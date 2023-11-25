using BusinnessApi.Context;
using BusinnessApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors",
            c =>
            {
                c.WithOrigins("https://localhost:5001", "http://localhost:5001", "https://localhost:5002", "http://localhost:5002")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
});

builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICurrencyService,CurrencyService>();
builder.Services.AddDbContext<AppBusinessDbContext>(optins =>
{
    optins.UseNpgsql(builder.Configuration.GetConnectionString("PsqlConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyCors");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
