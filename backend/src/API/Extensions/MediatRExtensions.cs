using API.Behaviours;
using FluentValidation;
using Infrastructure.Exceptions;
using System.Reflection;

namespace API.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
            => services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.Load("Application"));
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            })
            .AddValidatorsFromAssembly(Assembly.Load("Application"))
            .AddExceptionHandler<CustomExceptionHandler>();
    }
}
