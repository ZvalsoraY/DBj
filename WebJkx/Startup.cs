using DAL;
using Interfaces;
using System.Data.SqlClient;
namespace WebJkx
{
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
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appConfig.json");
            var configuration = configurationBuilder.Build();

            var connectionBuilder = new SqlConnectionStringBuilder
            {
                DataSource = configuration["Connection:DataSource"],
                InitialCatalog = configuration["Connection:InnitialCatalog"],
                IntegratedSecurity = true
            };

            var connectionString = connectionBuilder.ToString();
            services.AddSingleton<ICounterDAO>(x => new CounterDAO(connectionString));
            services.AddSingleton<IRateDAO>(x => new RateDAO(connectionString));
            services.AddSingleton<IReadingDAO>(x => new ReadingDAO(connectionString));
            services.AddSingleton<IServiceDAO>(x => new ServiceDAO(connectionString));

            

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
