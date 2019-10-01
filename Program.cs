using System.Collections.Generic;
using DotNetReactAndGraphQL.Database;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetReactAndGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Authors.Add(
                    new Author
                    {
                        Id = 1,
                        Name = "First Author",
                        Books = new List<Book>()
                        {
                            new Book
                            {
                                Name = "First Book",
                                Published = true,
                                Genre = "Mystery"
                            },
                            new Book
                            {
                                Name = "Second Book",
                                Published = true,
                                Genre = "Crime"
                            }
                        }
                    }
                );

                context.SaveChanges();
            }
            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
