using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class WebAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        public Mock<IMyService> MyServiceMock { get; private set; } = null!;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                .ConfigureTestServices(services =>
                {

                    // Remove the existing registration
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IMyService));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Create and register the mock
                    MyServiceMock = new Mock<IMyService>();
                    services.AddTransient(_ => MyServiceMock.Object);

                });

        }


    }
}
