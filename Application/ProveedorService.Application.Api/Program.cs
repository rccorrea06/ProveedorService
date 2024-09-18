using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using ProveedorService.Domain.Core.Abstract;
using ProveedorService.Domain.Core.Business;
using ProveedorService.Domain.Core.IBusiness;
using ProveedorService.Infrastructure.MongoDb;
using ProveedorService.Infrastructure.MongoDb.DataAcces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();





var mongoDataBase = new MongoClient(builder.Configuration.GetConnectionString("MongoConnection"))
    .GetDatabase(builder.Configuration.GetSection("DataBaseName").Value);

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseMongoDB(mongoDataBase.Client, mongoDataBase.DatabaseNamespace.DatabaseName);
});

builder.Services.AddTransient<IProveedorService, ProveedorAccesData>();

builder.Services.AddTransient<IProveedorBusiness, ProveedorBusiness>();
builder.Services.AddTransient<IAutenticacionBusines, AutenticacionBusines>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "API Prueba Tecnica",
            Description = "Api para la gestión de proveedores",
            Contact = new OpenApiContact
            {
                Name = "Roberto Correa R",
                Email = "rccorrea06@gmail.com",
            },
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    });

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ClockSkew = TimeSpan.Zero
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

//app.UseAuthentication();

app.Run();
