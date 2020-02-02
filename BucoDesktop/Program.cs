using Buco.Data;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Buco.Models;

namespace BucoDesktop
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var config = new ConfigurationBuilder()
                .SetBasePath("E:\\documents\\fnjer\\OO\\seminar\\Buco\\Buco\\Buco")
                .AddJsonFile("appsettings.json")
                .Build();
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Application.Run(new HomeForm(dbContext));
            }
        }
    }
}
