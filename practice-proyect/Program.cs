using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;
using practice_proyect.Inyection;
using practice_proyect.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONFIG CONECCTION AND INYECTION
builder.Services.AddServices(builder.Configuration);


//RUN
var app = builder.Build();

//APLICATE MIGRATIONS AUt
/*using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PgConectionContext>();
    context.Database.Migrate();
}*/


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
