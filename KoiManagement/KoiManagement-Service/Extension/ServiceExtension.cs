using KoiManagement_Business;
using KoiManagement_Repository.IRepository;
using KoiManagement_Repository.Repository;
using KoiManagement_Service.IService;
using KoiManagement_Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoiManagement_Service.Extension
{
	public static class ServiceExtension
	{
		public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<Prn221Context>(options => options.UseSqlServer(configuration.GetConnectionString("KoiManagementConnection")));
		}

		public static void ConfigureManager(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IServiceManager, ServiceManager>();
		}

		public static void ConfigureAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(ServiceExtension).Assembly);
		}
	}
}
