using Microsoft.EntityFrameworkCore;
using PruebaPromart.API.Profiles;
using PruebaPromart.DataAccess;
using PruebaPromart.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(options => options.AddProfile<AutoMapperProfiles>());
builder.Services.AddDependencies();

// Add services to the container.
builder.Services.AddDbContext<PruebaPromartDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString
    ("PruebaPromartConnection")));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
