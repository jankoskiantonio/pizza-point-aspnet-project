using PizzaPointProject;
using PizzaPointProject.Data;

var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(wb => wb.UseStartup<Startup>())
    .Build();

if (args.Contains("/seed"))
{
    using (var scope = host.Services.CreateScope())
    {
        DbInitializer.Initialize(scope.ServiceProvider.GetService<ApplicationDbContext>(), scope.ServiceProvider);
    }
    Environment.Exit(0);
}

await host.RunAsync();


