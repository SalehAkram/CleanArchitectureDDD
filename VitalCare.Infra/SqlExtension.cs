using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCare.Infra
{
    public static class SqlExtension
    {
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("Sql:ConnectionString").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                return;
            }
            var password = configuration.GetSection("Sql:Password").Value;
            connectionString = !string.IsNullOrEmpty(password) ? connectionString.Replace("{your_password}", password) : connectionString;
            services.AddDbContext<VitalCareDbContext>((_, options) => options.UseSqlServer(connectionString));
        }
    }
}
