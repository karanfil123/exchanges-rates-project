var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors",
            c =>
            {
                c.WithOrigins(
                     "https://localhost:5000",//data apiye istek yap�p veritaban�n� olu�turmak i�in
                     "https://localhost:5001",
                     "https://localhost:5002",
                     
                              "http://localhost:2000",//data apiye istek yap�p veritaban�n� olu�turmak i�in
                              "http://localhost:2001",
                              "http://localhost:2002")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCors("MyCors");

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
