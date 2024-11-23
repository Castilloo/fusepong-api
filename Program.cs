
using FusepongAPI.Helpers;
using FusepongAPI.Models.Context;
using FusepongAPI.Repositories;
using FusepongAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var mysqlConnection = builder.Configuration.GetConnectionString("MysqlConnection");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });;

builder.Services.AddDbContext<FusepongContext>(options => 
    options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection))
);

builder.Services.AddTransient<IFusepongPMRepository, FusepongPMRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<JWTService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option => 
{
    option.AddPolicy("MyPolicy", opt => opt
        .WithOrigins("http://localhost:4200") 
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.Run();


