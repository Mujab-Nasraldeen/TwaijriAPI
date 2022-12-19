using Microsoft.Extensions.Options;
using TwaijriAPI.Bal.Services;
using TwaijriAPI.Dal;

namespace TwaijriAPI.Pal.Startup;
public static class DependencyInjectionSetup
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        #region Dependancy Injections
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IInvoiceService, InvoiceService>();
        services.AddTransient<ICustomerService, CustomerService>();
        #endregion

        #region MVC Installer
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        #endregion

        #region CORS Configuration
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });
        });
        #endregion

        return services;
    }
}
