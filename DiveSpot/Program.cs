using DiveSpot;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddPolicy("Policy",
    policy =>
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyHeader())
);
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var connectionString = builder.Configuration.GetConnectionString("DBcontext");
builder.Services.AddDbContext<DBcontext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Policy");
app.UseAuthorization();

app.MapControllers();

app.Run();
