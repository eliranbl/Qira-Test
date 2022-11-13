using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Qira.Domain.Invoices;
using Qira.EF;
using Qira.EF.Repositories;
using System.Reflection;

namespace Qira.WebApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlConnection(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<QiraDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));
    }

    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddScoped<IInvoicesRepository, InvoicesRepository>();
        service.AddScoped<IInvoicesService, InvoicesService>();
    }

    public static void ConfigureSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Qira API",
                Description = "Eliran Ben lulu test",
            });

            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        service.AddApiVersioning(o =>
        {
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.DefaultApiVersion = new ApiVersion(1, 0);
        });

        service.AddVersionedApiExplorer(o =>
        {
            o.GroupNameFormat = "'v'VVV";
            o.SubstituteApiVersionInUrl = true;
        });
    }
}