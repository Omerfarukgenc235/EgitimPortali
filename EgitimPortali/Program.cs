using EgitimPortali.Context;
using EgitimPortali.Repository.Anasayfa;
using EgitimPortali.Repository.Ders;
using EgitimPortali.Repository.DersIcerik;
using EgitimPortali.Repository.Hakkýmýzda;
using EgitimPortali.Repository.Kategori;
using EgitimPortali.Repository.Konu;
using EgitimPortali.Repository.Kullanici;
using EgitimPortali.Repository.KullaniciRol;
using EgitimPortali.Repository.Reklam;
using EgitimPortali.Repository.Rol;
using EgitimPortali.Repository.Soru;
using EgitimPortali.Repository.SoruCevap;
using EgitimPortali.Repository.Yorum;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IKategorilerRepository, KategorilerRepository>();
builder.Services.AddScoped<IDerslerRepository, DerslerRepository>();
builder.Services.AddScoped<IDersIcerikRepository, DersIcerikRepository>();
builder.Services.AddScoped<IKonularRepository, KonularRepository>();
builder.Services.AddScoped<IAnasayfaRepository, AnasayfaRepository>();
builder.Services.AddScoped<IHakkimizdaRepository, HakkimizdaRepository>();
builder.Services.AddScoped<IReklamRepository, ReklamRepository>();
builder.Services.AddScoped<IYorumRepository, YorumRepository>();
builder.Services.AddScoped<ISoruRepository, SoruRepository>();
builder.Services.AddScoped<ISoruCevapRepository, SoruCevapRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IKullaniciRepository, KullaniciRepository>();
builder.Services.AddScoped<IKullaniciRolRepository, KullaniciRolRepository>();
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
