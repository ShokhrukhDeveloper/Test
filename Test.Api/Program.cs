using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Test.Api.Brokers;
using Test.Api.Data;
using Test.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option=>{
        option.TokenValidationParameters=new TokenValidationParameters{
            ValidateAudience=true,
            ValidateIssuer=true,
            ValidateLifetime=true,
            ValidateIssuerSigningKey=true,
            ValidIssuer=builder.Configuration["Jwt:Issuer"],
            ValidAudience=builder.Configuration["Jwt:Audience"],
            ClockSkew=TimeSpan.Zero,
            IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        }; 
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<IJWTService,JWTService>();
builder.Services.AddScoped<IStorageBroker,StorageBroker>();
builder.Services.AddScoped<ITestService,TestService>();
builder.Services.AddScoped<IExaminerService,ExaminerService>();
builder.Services.AddScoped<ICredentialService,CredentialService>();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlite(connectionString));

var app = builder.Build();
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();