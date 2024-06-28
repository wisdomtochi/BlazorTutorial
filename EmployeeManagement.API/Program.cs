using EmployeeManagement.API.Data.Context;
using EmployeeManagement.API.DataAccess.Implementation;
using EmployeeManagement.API.DataAccess.Interface;
using EmployeeManagement.API.Services.Implementation;
using EmployeeManagement.API.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region CONFIGURE LOGGING
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

logger.Information("Starting App.");
#endregion

#region REGISTER SERVICES
string dbConnection = builder.Configuration.GetConnectionString("EmployeeDbConnection");
builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection), sqlopt =>
    {
        sqlopt.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), null);
        sqlopt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });
});

builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

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
