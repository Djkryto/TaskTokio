using Microsoft.AspNetCore.Server.Kestrel.Core;
using Web_Server.Database.Context.Sql;
using Web_Server.Appliaction.Builder;
using Web_Server.Appliaction.Handler;
using Web_Server.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Web_Server.Handler.Service;
using Web_Server.Appliaction;
using Web_Server.Handler;

var builder = WebApplication.CreateBuilder(args);

var MyCostPolicy = "Policy";

builder.Services.AddControllersWithViews();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection), ServiceLifetime.Scoped);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCostPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<XMLStringBuilder>();
builder.Services.AddScoped<XMLHandler>();
builder.Services.AddScoped<HttpService>();
builder.Services.AddScoped<DataHandler>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(MyCostPolicy);

app.UseAuthorization();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
