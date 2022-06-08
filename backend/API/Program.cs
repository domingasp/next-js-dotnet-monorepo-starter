using API.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using API.Behaviors;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

var app = builder.Build();

ConfigureApplication(app);

app.Run();

static void RegisterServices(WebApplicationBuilder builder)
{
    var services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<APIContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

    services.AddMediatR(typeof(Program));
    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    services.AddControllers()
        .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());
}

static void ConfigureApplication(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();
}