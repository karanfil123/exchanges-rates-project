using DataApi.Context;
using DataApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors",
            c =>
            {
                c.WithOrigins(
                     "https://localhost:5000",//data apiye istek yapýp veritabanýný oluþturmak için
                     "https://localhost:5001",
                     "https://localhost:5002",

                              "http://localhost:2000",//data apiye istek yapýp veritabanýný oluþturmak için
                              "http://localhost:2001",
                              "http://localhost:2002")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
});
builder.Services.AddScoped<CurrencyService>();
builder.Services.AddDbContext<AppDbContext>(optins =>
{
    optins.UseNpgsql(builder.Configuration.GetConnectionString("PsqlConnection"));
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
var scopedServices = scope.ServiceProvider;
var dbContext = scopedServices.GetRequiredService<AppDbContext>();
dbContext.Database.Migrate();


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
