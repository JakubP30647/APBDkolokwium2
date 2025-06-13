


using APBDkolokwium2;
using APBDkolokwium2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);


builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IExhibitionService, ExhibitionService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseAuthorization();
app.MapControllers();
app.Run();