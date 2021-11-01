using GraphQL.Server.Ui.Voyager;
using integrator.Contexts;
using integrator.GraphQL;
using integrator.Models;
using integrator.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace integrator
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
            var config = new ServerConfig();
            Configuration.Bind(config);

            var mongoContext = new MongoDbContext(config.MongoDb);
            
            services.AddSingleton<ITodoService>(new TodoService(mongoContext));
            services.AddSingleton<IBookService>(new BookService(mongoContext));

            
            services.AddSingleton<IMongoDbContext>(new MongoDbContext(config.MongoDb));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .AddProjections();
            
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            
            // requires using Microsoft.Extensions.Options
            //services.Configure<BookstoreDatabaseSettings>(
            //    Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            //services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
            //    sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            //

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "integrator", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "integrator v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapGraphQL(); 
                //endpoints.MapControllers(); 
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
        }
    }
}