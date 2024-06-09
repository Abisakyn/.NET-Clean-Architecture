using BurberDinner.Api.Filters;
using BurberDinner.Application;
using BurberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Register services
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    // Uncomment the following line if you want to add error handling filter globally
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline
    // Uncomment the following line if you want to use custom middleware for error handling
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/errors"); // Ensure this matches your controller route
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
