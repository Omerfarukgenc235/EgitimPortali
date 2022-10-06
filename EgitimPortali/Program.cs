using EgitimPortali.Context;
using EgitimPortali.Repository.Ders;
using EgitimPortali.Repository.DersIcerik;
using EgitimPortali.Repository.Kategori;
using EgitimPortali.Repository.Konu;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKategorilerRepository, KategorilerRepository>();
builder.Services.AddScoped<IDerslerRepository, DerslerRepository>();
builder.Services.AddScoped<IDersIcerikRepository, DersIcerikRepository>();
builder.Services.AddScoped<IKonularRepository, KonularRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SqlServerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
