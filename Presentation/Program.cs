using Data.Context;
using Business.Services;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// builder.Services.AddControllers()
       //.AddJsonOptions(x =>
       //{
       // x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
       //});

services.AddDbContext<DataContext>(options => 
options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C-Projects\\LOCALDB\\LOCALDB\\Data\\MSSQLLocalDB.mdf;Integrated Security=True"));

services.AddScoped<IUserService, UserService>();
services.AddScoped<IProjectService, ProjectService>();
services.AddScoped<IStatusTypesService, StatusTypesService>();


var provider = services.BuildServiceProvider();
var context = provider.GetRequiredService<DataContext>();


Console.WriteLine("Migration Complete");

