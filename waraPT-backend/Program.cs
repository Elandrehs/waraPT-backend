using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using waraPT_Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// ───────────── Controllers ─────────────
builder.Services.AddControllers();

// ───────────── CORS (para que la app Kotlin pueda consumir la API) ─────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ───────────── Database (MySQL) ─────────────
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<WaraDbContext>(options =>
    options.UseMySQL(connectionString));

// ───────────── Swagger / OpenAPI ─────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Wara Worker Management API",
        Version = "v1",
        Description = "Technical test - REST API for worker management",
        Contact = new OpenApiContact
        {
            Name = "Victor Cruz Ibarra",
            Email = "andrestheb@gmail.com"
        }
    });
});

var app = builder.Build();

// ───────────── HTTP pipeline ─────────────
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();