using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI.RazorExample.ViewModels;
using ReactiveUI.RazorExample.Views;

namespace ReactiveUI.RazorExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddRazorComponents();
            services.AddSingleton<GreetingViewModel>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<GreetingView>("app");
            });
        }
    }
}
