using AnalysisRegister.DataBase;
using Microsoft.EntityFrameworkCore;
using OBioTech.Services.Analysis;
using OBioTech.Services.Register;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RegisterDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=analysisDb;Port=5432;Username=admin;Password=123456"));

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IAnalysisMap, AnalysisMap>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
