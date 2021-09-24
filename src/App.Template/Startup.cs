using App.Template.Infra.Repository;
using Microsoft.OpenApi.Models;
using App.Template.Domain.UseCases.User;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using App.Template.Domain.Contracts.Repository;
using App.Template.Domain.Contracts.UseCase.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Template.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Example
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
            services.AddControllers();

            services.AddScoped<IFindAllUserUseCase, FindAllUserUseCase>();
            services.AddScoped<IFindByIdUserUseCase, FindByIdUserUseCase>();
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("ApiExample"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api.Example", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.Example v1"));
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
