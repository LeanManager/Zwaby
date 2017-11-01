using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ZwabyWebServices.Models;
using Stripe;
using Microsoft.Extensions.Configuration;

namespace ZwabyWebServices
{
    /* In order to inject the database context into the controller, we need to register it 
       with the dependency injection container. Register the database context with the service 
       container using the built-in support for dependency injection.
     */

	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// Specifies an in-memory database is injected into the service container.
            services.AddMvc();

            var connection = @"Server=zwabydb.database.windows.net;Database=zwabydb;User Id=zwabydb;Password=Zwabyazure00;";

            services.AddDbContext<RegistrationContext>(options => options.UseSqlServer(connection));

            //services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
        }
    }
}
