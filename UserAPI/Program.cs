
using Microsoft.EntityFrameworkCore;
using UserAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy( corPolicy =>
    {
        corPolicy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();

    });
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=sql.bsite.net\\MSSQL2016; Database=classroom_db; User Id=classroom_db; Password=asd123");
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors(cors =>
//{
//    cors.AllowAnyOrigin();
//    cors.AllowAnyMethod();
//    cors.AllowAnyHeader();
//});

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
