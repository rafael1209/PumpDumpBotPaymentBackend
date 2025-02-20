using Microsoft.OpenApi.Models;
using PumpDumpBotPaymentBackend.Database;
using PumpDumpBotPaymentBackend.Interface;
using PumpDumpBotPaymentBackend.Repositories;
using PumpDumpBotPaymentBackend.Services;

namespace PumpDumpBotPaymentBackend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PumpDumpAlert Payment API", Version = "v1" });

            });

            services.AddHttpContextAccessor();

            services.AddSingleton<MongoDbContext>();

            services.AddScoped<ITokenValidator, TokenValidator>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/swagger");
                }
                else
                {
                    await next.Invoke();
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors(k =>
            {
                k.WithMethods("POST", "GET", "PATCH", "PUT");
                k.AllowAnyOrigin();
                k.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().AllowAnonymous();
                endpoints.MapSwagger();
                endpoints.MapControllers().AllowAnonymous();
            });
        }
    }
}
