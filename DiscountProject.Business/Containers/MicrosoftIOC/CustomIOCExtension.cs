using DiscountProject.Business.Concrete;
using DiscountProject.Business.Interfaces;
using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using DiscountProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using DiscountProject.DataAccess.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountProject.Business.Containers.MicrosoftIOC
{
    public static class CustomIOCExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("db1"), conf =>
                {
                    conf.MigrationsAssembly("DiscountProject.WebApi");
                });
            });

            #region Dependency For Service-Manager
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            #endregion

            #region Dependency For Dal-Repository
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped<IInvoiceDal, EfInvoiceRepository>();
            #endregion

            #region Dependecy For Validations
            //services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInDtoValidator>();
            #endregion
        }
    }
}
