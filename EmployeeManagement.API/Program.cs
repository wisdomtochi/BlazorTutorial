using EmployeeManagement.API.Data.Context;
using EmployeeManagement.API.DataAccess.Implementation;
using EmployeeManagement.API.DataAccess.Interface;
using EmployeeManagement.API.Services.Implementation;
using EmployeeManagement.API.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
