using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Integrator.Infrastructure;
using Integrator.Infrastructure.ErrorHandling;
using Integrator.Infrastructure.Extensions;
using Integrator.Tests.TestHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NUnit.Framework;

namespace Integrator.Tests.InfrastructureTests
{
    public class ErrorHandlingTests
    {
        [Test]
        public void ErrorHandling_ToString_ShouldSerializeObject()
        {
            var errorDetails = new ErrorDetails
            {
                StatusCode = 200,
                Message = "This is an error message"
            };

            var serialized = errorDetails.ToString();
            const string expected = "{\"StatusCode\":200,\"Message\":\"This is an error message\"}";
            
            Assert.AreEqual(expected, serialized);

        }

        [Test]
        public async Task ExceptionHandler_OnError_ShouldSendInternalServerError()
        {
            var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.ConfigureServices();
                            services.ConfigureCors();
                            services.AddControllers();
                        })
                        .Configure(app =>
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integrator v1"));
                            app.UseCors(builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

                            app.ConfigureExceptionHandler();
                            app.UseRouting();
                            app.UseAuthorization();
                            app.UseEndpoints(endpoints =>
                            {
                                endpoints.MapControllers();
                            });
                        });
                })
                .StartAsync();

            var response = await host.GetTestClient()
                .GetAsync("/Test/ThrowsError");
            
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}