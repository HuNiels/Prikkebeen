using Acupunctuur.Business;
using Acupunctuur.data;
using Acupunctuur.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Acupunctuur {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            // Registering a class for dependency injection
            services.AddScoped<BuUser>();
            services.AddScoped(typeof(BuUser));

            services.AddScoped<BuReservations>();
            services.AddScoped(typeof(BuReservations));

            services.AddScoped<BuPage>();
            services.AddScoped(typeof(BuPage));

            services.AddScoped<BuEmails>();
            services.AddScoped(typeof(BuEmails));

            services.AddScoped<SessionManager>();
            services.AddScoped(typeof(SessionManager));

            services.AddScoped<IRepository<Page>, Repository<Page>>();
            services.AddScoped(typeof(Repository<Page>));

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped(typeof(Repository<User>));

            services.AddScoped<IRepository<Reservation>, Repository<Reservation>>();
            services.AddScoped(typeof(Repository<Reservation>));

            services.AddScoped<IRepository<Timeslot>, Repository<Timeslot>>();
            services.AddScoped(typeof(Repository<Timeslot>));

            services.AddScoped<IRepository<TimeslotLink>, Repository<TimeslotLink>>();
            services.AddScoped(typeof(Repository<TimeslotLink>));

            services.AddScoped<IRepository<BlockedPeriod>, Repository<BlockedPeriod>>();
            services.AddScoped(typeof(Repository<BlockedPeriod>));

            services.AddScoped<IRepository<Cancellation>, Repository<Cancellation>>();
            services.AddScoped(typeof(Repository<Cancellation>));

            services.AddScoped<TimeManager>();
            services.AddScoped(typeof(TimeManager));

            services.AddScoped<EmailManager>();
            services.AddScoped(typeof(EmailManager));


            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.Cookie.Name = ".PrikkebeenAcupunctuur.Session";
                // Default session timeout is 20 min
                // options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            services.AddDbContext<AcupunctuurContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DevConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Must be called after UseRouting() and before UseEndpoints()
            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Page}/{action=Main}/{id?}");
            });
        }
    }
}
