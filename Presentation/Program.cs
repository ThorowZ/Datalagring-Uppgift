using Data.Context;
using Business.Services;
using Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C-Projects\\LOCALDB\\LOCALDB\\Data\\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

var provider = services.BuildServiceProvider();
var context = provider.GetRequiredService<DataContext>();
services.AddScoped<IUserService, UserService>();

context.Database.Migrate();
Console.WriteLine("Migration Complete");

