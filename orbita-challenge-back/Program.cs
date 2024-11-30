using Data;
using Microsoft.EntityFrameworkCore;
using orbita_challenge_back.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Local Services
builder.Services.AddScoped<IStudentService, StudentService>();

// Add services to the container.
builder.Services.AddControllers();

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddDbContext<StudentContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable the CORS policy
app.UseCors("AllowSpecificOrigins");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.Urls.Add("http://*:8080");

app.Urls.Add("http://*:8081");


app.Run();