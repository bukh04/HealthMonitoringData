using Application;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<MonitoringService>();
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SiteService>();
builder.Services.AddScoped<IncidentService>();
builder.Services.AddScoped<MonitoringService>();

builder.Services.AddHostedService<MonitoringWorker>();

var host = builder.Build();

host.Run();