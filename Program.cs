using GameServer.Database;
using GameServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(
       options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddSingleton<ISortingService, SortingService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ISearchService, SearchService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.Database.EnsureCreated(); // Applies the seeded data
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();


app.Run();
