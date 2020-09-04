using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyRestfulSwaggerService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyRestfulSwaggerService.Extensions
{
    public static class ServicesExtension
    {
		public static IServiceCollection ConfigureLocalServices(this IServiceCollection services)
		{

			// configure DI for application services
			services.AddScoped<IUserService, UserService>();
			//#if !DEBUG
			//            ServiceBusConfig serviceBusConfig = configuration.Get<ServiceBusConfig>("ServiceBus:ServiceBusConfig");
			//            serviceBusConfig.SubscriptionName = "DailyUpdateConsumer";

			//            serviceBusConfig.SubscriptionName += "-debug";

			//            services.RegisterServiceBus(serviceBusConfig, typeof(AppConfigLoader));
			//#endif

			//services.AddDbContext<LoanbookContext>
			//(
			//	(serviceProvider, opt) =>
			//	{


			//		var dbConnectionString = hostContext.Configuration["Database:LoanbookContext"] + ";Application Name=DU;";


			//		opt.UseSqlServer(dbConnectionString,
			//			contextOptions =>
			//			{
			//				contextOptions.EnableRetryOnFailure(
			//					maxRetryCount: 5,
			//					maxRetryDelay: TimeSpan.FromSeconds(5),
			//					errorNumbersToAdd: new List<int>() { 19 }
			//				);
			//				contextOptions.CommandTimeout(120);
			//			});
			//	});





			return services;
		}
	}
}
