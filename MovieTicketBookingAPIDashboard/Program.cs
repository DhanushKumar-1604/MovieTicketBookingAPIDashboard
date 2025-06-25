using APIDashboard.Application.Interfaces;
using APIDashboard.Application.Services;
using APIDashboard.Infrastructure.DapperHelper;
using APIDashboard.Infrastructure.Repository.MoviesManage.Implementations;
using APIDashboard.Infrastructure.Repository.MoviesManage.Interfaces;
using MovieTicketBookingAPIDashboard.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IMoviesManageService,MoviesManageService>();
builder.Services.AddScoped<IMoviesManageQuery,MoviesManageQuery>();
builder.Services.AddScoped<IMoviesManageCommand, MoviesManageCommand>();
builder.Services.AddScoped<IDapperHelper, DapperHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
