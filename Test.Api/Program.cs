using Microsoft.EntityFrameworkCore;
using Test.Api.Data;
using Test.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlite(connectionString));
builder.Services.AddScoped<ITestService,TestService>();
builder.Services.AddScoped<IExaminerService,ExaminerService>();
builder.Services.AddScoped<ICredentialService,CredentialService>();
var app = builder.Build();
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();