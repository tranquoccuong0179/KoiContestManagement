using Azure.Storage.Blobs;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Service.IService;
using KoiManagement_Service.Service;
using KoiManagement_Services.IService;
using KoiManagement_Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KoiManagement_Service.Extension
{
	public static class ServiceExtension
	{
		public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<KoiManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("KoiManagementConnection")));
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

		public static void ConfigureBlobService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(u => new BlobServiceClient(configuration.GetConnectionString("StorageAccount")));
			services.AddSingleton<IBlobService, BlobService>();
		}
	}
}
