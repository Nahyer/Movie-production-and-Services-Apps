using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddHttpClient();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
        // Configure your app here
        
    }
}