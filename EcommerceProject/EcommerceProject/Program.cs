using EcommerceProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using EcommerceProject.Infrastructure.Domain;
using NetProject.Infrastructure.Domain;
using EcommerceProject.Application;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                    Enter 'Bearer' [space] and then your token in the text input below..
                    \r\n\rExample: 'Bearer 123abcerty'",
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

string issuser = configuration.GetValue<string>("Tokens:Issuer");
string signingKey = configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication( option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
     .AddJwtBearer(options =>
     {
         options.RequireHttpsMetadata = false;
         options.SaveToken = true;
         options.TokenValidationParameters = new TokenValidationParameters()
         {
             ValidateIssuer = true,
             ValidIssuer = issuser,
             ValidateAudience = true,
             ValidAudience = issuser,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ClockSkew = TimeSpan.Zero,
             IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
         };
    });

builder.Services.AddHealthChecks();
builder.Services.AddApplication();
builder.Services.AddDatabase(configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();
