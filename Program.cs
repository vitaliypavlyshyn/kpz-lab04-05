using Microsoft.EntityFrameworkCore;
using QQQQ;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<HistoricalEventDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("HistoricalEventDbContext")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Дозволити будь-яке походження
              .AllowAnyHeader() // Дозволити будь-які заголовки
              .AllowAnyMethod(); // Дозволити будь-які HTTP-методи
    });
});

builder.Services.AddControllers();
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
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
