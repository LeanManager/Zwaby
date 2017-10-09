using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ZwabyWebServices.Models;
using Stripe;

namespace ZwabyWebServices
{
    /* In order to inject the database context into the controller, we need to register it 
       with the dependency injection container.Register the database context with the service 
       container using the built-in support for dependency injection.
     */

	public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// Specifies an in-memory database is injected into the service container.
			services.AddDbContext<StripeContext>(opt => opt.UseInMemoryDatabase("StripeCharges"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            StripeConfiguration.SetApiKey("sk_test_t0PxK1ifMhrPBI8LXM8zk6eD");
        }
    }
}
