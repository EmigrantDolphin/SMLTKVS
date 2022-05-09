using Authentication.Application;
using Authentication.Application.Options;
using Authentication.Application.Queries;
using Authentication.Application.Queries.Interfaces;
using Authentication.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(AuthenticationMediatR));
builder.Services.AddDbContext<AuthenticationContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetValue<string>("ConnectionStrings:Authentication")
        ));
builder.Services.AddScoped<IAuthenticationContext, AuthenticationContext>();

builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("JwtTokenOptions"));
builder.Services.AddSingleton<JwtTokenConfiguration>();
builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("JwtTokenOptions").Get<JwtTokenOptions>());

builder.Services.AddScoped<IGetUsers, GetUsers>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();