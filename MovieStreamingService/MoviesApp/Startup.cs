using Microsoft.EntityFrameworkCore;
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.DictionaryKeyPolicy = null;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure your app here
        
        

    }
}
