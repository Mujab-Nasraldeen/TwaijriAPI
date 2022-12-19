using Microsoft.EntityFrameworkCore;
using TwaijriAPI.Dal;
using TwaijriAPI.Pal.Startup;

var builder = WebApplication.CreateBuilder(args);

#region Initiate Connection With DB
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
#endregion

builder.Services.RegisterServices();

var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
