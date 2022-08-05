using Challenge.IoC;
using ChallengeNubimetricsWeb;
using Controllers;
using Microsoft.OpenApi.Models;
using Presenters.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
//TODO hay que revisar porque no funcionan la configuraciones generales para json
builder.Services.AddControllers(Filter.Register).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var Configuration = builder.Configuration;

builder.Services.AddHostedService<HostedService>();

builder.Services.AddChallengeServices(Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Nubimetrics Challenge",
        Description = "Aplicación desafío propuesto por Nubimetrics",
        TermsOfService = new Uri("https://www.nubimetrics.com/"),
        Contact = new OpenApiContact
        {
            Name = "Nubimetrics",
            Url = new Uri("https://www.nubimetrics.com/")
        },
        License = new OpenApiLicense
        {
            Name = "Licencia",
            Url = new Uri("https://www.nubimetrics.com/")
        }
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
    Type t = typeof(UserController);
    var name = t.Assembly.GetName().Name;
    var xmlFilename = $"{name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
