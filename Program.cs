using Microsoft.EntityFrameworkCore;
using PcManager.Data;
using PcManager.Repositories;
using PcManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPcRepository, PcRepository>();
builder.Services.AddScoped<IPcService, PcService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
