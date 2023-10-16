using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MusicStore.DB.DataAccess;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Access");

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(options => { });
builder.Services.AddEntityFrameworkJet();
builder.Services.AddDbContext<MusicStoreDbContext>(options =>
    options.UseJetOleDb(connectionString));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(Program).GetTypeInfo().Assembly));
builder.Services.AddAutoMapper(
    typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.Run();