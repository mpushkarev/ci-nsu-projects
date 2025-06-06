/******************************************************************************\
*                                                                              *
*  Author:     Mikhail Pushkarev (CI NSU)                                      *
*  Created:    Approx. February – June 2025                                    *
*                                                                              *
*  Description:                                                                *
*    Basic demonstration of dependency injection in a WinForms                 *
*    application, featuring a simple user authentication and                   *
*    registration system. The core logic is separated into service             *
*    interfaces and multiple implementations (including fake,                  *
*    list, and real authentication managers).                                  *
*    As one of my early projects using these patterns, some aspects            *
*    may be simplistic or suitable for further improvement.                    *
*                                                                              *
\******************************************************************************/

using DependencyInjectionIntro.Data;
using DependencyInjectionIntro.Interfaces;
using DependencyInjectionIntro.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionIntro {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ServiceCollection services = new ServiceCollection();

            services.AddTransient<MainForm>();
            services.AddTransient<LoginDialog>();
            services.AddTransient<RegisterDialog>();

            services.AddScoped<IAuthManager, RealAuthManager>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=app.db")
            );

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            MainForm mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }
}