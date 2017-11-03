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
            services.AddMvc();

            services.AddSingleton<IConfiguration>(Configuration);

            string databaseString = Configuration.GetSection("Data").GetSection("ConnectionString").Value;

            string connection = @databaseString;

            services.AddDbContext<RegistrationContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<BookingsContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<CancellationsContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
