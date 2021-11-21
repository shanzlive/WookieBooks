using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WookieBooks.InfraStructure;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using WookieBooks.Domain.Interfaces;
using WookieBooks.Application.Commands.AddBook;
using WookieBooks.Application.Commands.UpdateBook;
using WookieBooks.Application.Commands.DeleteBook;
using WookieBooks.Application.Queries;
using WookieBooks.Api.Filters;
using FluentValidation;

namespace WookieBooks.Api
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
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(CustomexceptionFilterAttribute));
            });
            services.AddDbContext<BookContext>(opt =>
                        opt.UseInMemoryDatabase("BookList"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WookieBooks API", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddMediatR(typeof(GetBooksAllQuery).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(UpdateBookCommandValidator).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WookieBooks API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
