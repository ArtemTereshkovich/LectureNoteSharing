using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Material_Sharing.Models;
using Material_Sharing.DAL.Entities;
using Material_Sharing.DAL.Data;
using Material_Sharing.BLL.Interfaces;
using Material_Sharing.BLL.Services;
using AutoMapper;
using Material_Sharing.BLL.AutoMapperProfiles;
using Material_Sharing.DAL.Interfaces;
using Material_Sharing.DAL.Repositories;
using Material_Sharing.Hubs;

namespace Material_Sharing
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
            services.AddDbContext<ApplicationDataBaseContext>(options =>            
                options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;", b => b.MigrationsAssembly("Material_Sharing.DAL"))
            );
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail =true;
            })
                .AddEntityFrameworkStores<ApplicationDataBaseContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication();

            // Add application services.           
            services.AddScoped<IEmailSenderService,EmailSenderService>();
            services.AddScoped<ILectureNoteService,LectureNoteService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ISpecialtyNumberService, SpecialtyNumberService>();
            services.AddScoped<ITagService,TagService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICommentService,CommentService>();
            services.AddScoped<ILectureNoteRatingService,LectureNoteRatingService>();

            services.AddAutoMapper(typeof(BLLProfile));
            services.AddMvc();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=LectureNote}/{action=Index}");
            });

            app.UseSignalR(options => {
                options.MapHub<CommentHub>("/comments/live");
            });
        }
    }
}
