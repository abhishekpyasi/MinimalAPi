using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using MinimalApiCQRS.Abstractions;

namespace MinimalApiCQRS.Extensions
{
    public static class MinimalApiExtensions
    {

        public static void RegisterServices(this WebApplicationBuilder builder)

        {


            var cs = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<SocialDbContext>(option => option.UseSqlServer(cs));

            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(typeof(CreatePost).Assembly);
            });


        }

        public  static void RegisterEndpointDefinition (this WebApplication app)

        {

            var endpointDefiinitions = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition))
                && !t.IsAbstract && !t.IsInterface)
                .Select(t=> Activator.CreateInstance(t)).Cast<IEndpointDefinition>();

            foreach(var endpointDefiinition in endpointDefiinitions)
            {
                endpointDefiinition.RegisterEndpoints(app);
            }

        }
    }
}
