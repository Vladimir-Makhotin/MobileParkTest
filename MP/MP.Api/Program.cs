
using MP.Api.Configurations;
using MP.Api.Context;
using MP.Api.Domain;
using MP.Api.Mappers;
using MP.Api.Middleware;
using MP.Api.Repository;
using System.Reflection;

namespace MP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<MPApiConfiguration>(builder.Configuration.GetSection(nameof(MPApiConfiguration)));
            var connectionString = builder.Configuration.GetSection($"{nameof(MPApiConfiguration)}:{nameof(MPApiConfiguration.DefaultConnection)}").Value ?? throw new ArgumentNullException();
            builder.Services.AddContext(connectionString);
            builder.Services.AddRepositories();
            builder.Services.AddBaseMappers();
            builder.Services.AddServices();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MP.Api.xml", Version = "v1" });
                c.CustomSchemaIds(type => type.FullName);

                c.DescribeAllParametersInCamelCase();

                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                    .Union(new List<AssemblyName> { currentAssembly.GetName() })
                    .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                    .Where(File.Exists).ToList();
                xmlDocs.ForEach(xml =>
                {
                    c.IncludeXmlComments(xml);
                });
                /*c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter a token",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        },
                        new string[]{ }
                    }
                });*/
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseMiddlewares();

            app.MapControllers();

            app.Run();
        }
    }
}
