using BurberDinner.Application;
using BurberDinner.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    // Register services
    builder.Services
        .AddApplication()
        .AddInfrastructure();
    builder.Services.AddControllers();
}



var app = builder.Build();

{
    // Configure the HTTP request pipeline
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


