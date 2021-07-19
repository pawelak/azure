using System.Collections.Generic;
using System.Linq;
using csCodeSampleApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using vsCodeSampleApi.Models;

namespace vsCodeSampleApi.Data
{
    public static class InitData
    {
        public static void Initialize(IApplicationBuilder app)
        {
           using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SampleContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any users
                if (context.TestUsers != null && context.TestUsers.Any())
                    return;   // DB has already been seeded

                var users = InitData.GetUsers().ToArray();
                context.TestUsers.AddRange(users);
                context.SaveChanges();

                // Look for any roles
                if (context.TestUsers != null && context.TestUsers.Any())
                    return;   // DB has already been seeded

                var roles = InitData.GetRoles().ToArray();
                context.TestRoles.AddRange(roles);
                context.SaveChanges();

            }

             
        }

        public static List<TestUser> GetUsers()
        {
            List<TestUser> users = new List<TestUser>() {
            new TestUser {Name="Zbyszek"},
            new TestUser {Name="Ola"},
            new TestUser {Name="Marta"},
            new TestUser {Name="Paweł"}
            };
            return users;
        }

 
        public static List<TestRole> GetRoles()
        {
            var roles = new List<TestRole>() {
            new TestRole {Name="Admin"},
            new TestRole {Name="User"}
            };
            return roles;
        }

    }
}