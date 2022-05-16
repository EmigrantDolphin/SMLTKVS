using Authentication.Application;
using Authentication.Application.Options;
using Authentication.Application.Queries;
using Authentication.Application.Queries.Interfaces;
using Authentication.Persistence;
using Infrastructure.HttpClientFactories;
using Laboratory.Application;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(AuthenticationMediatR), typeof(LaboratoryMediatR));
builder.Services.AddDbContext<AuthenticationContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetValue<string>("ConnectionStrings:Authentication")
        ));
builder.Services.AddScoped<IAuthenticationContext, AuthenticationContext>();

builder.Services.AddDbContext<LaboratoryContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetValue<string>("ConnectionStrings:Laboratory")
        ));
builder.Services.AddScoped<ILaboratoryContext, LaboratoryContext>();

builder.Services.Configure<JwtTokenOptions>(builder.Configuration.GetSection("JwtTokenOptions"));
builder.Services.AddSingleton<JwtTokenConfiguration>();
builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("JwtTokenOptions").Get<JwtTokenOptions>());

builder.Services.AddScoped<IGetUsers, GetUsers>();
builder.Services.AddHttpClient<ILatexCompilerService, LatexCompilerService>();

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