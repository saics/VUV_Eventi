using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PIS.DAL.DataModel;
using Microsoft.EntityFrameworkCore;
using PIS.Service;
using PIS.Service.Common;
using PIS.Repository;
using PIS.Repository.Common;
using System;

namespace PIS.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PIS_DbContext2>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("PIS.DAL")));

            services.AddScoped<IKorisniciRepository, KorisniciRepository>();
            services.AddScoped<IKorisniciService, KorisniciService>();

            services.AddScoped<IEventiRepository, EventiRepository>();
            services.AddScoped<IEventiService, EventiService>();

            services.AddScoped<IAKtivnostiRepository, AktivnostiRepository>();
            services.AddScoped<IAKtivnostiService, AktivnostiService>();

            services.AddScoped<IKorisniciAktivnostiRepository, KorisniciAktivnostiRepository>();
            services.AddScoped<IKorisniciAktivnostiService, KorisniciAktivnostiService>();

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<IUlogeRepository, UlogeRepository>();
            services.AddScoped<IUlogeService, UlogeService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VUVEventi API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VUVEventi API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
