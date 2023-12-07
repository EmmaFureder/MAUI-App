using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace NORTHWIND
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            // reading json config files
            // https://montemagno.com/dotnet-maui-appsettings-json-configuration/

            // Ein *Assembly* ist nur ein anderer Begriff in .NET für *Anwendung*!
            var a = Assembly.GetExecutingAssembly();

            var folderPath = Path.GetDirectoryName(a.Location);

            var configname = $@"{folderPath}\appSettings.json";

            // JSON: <J>ava<S>cript <O>bject <N>otation Files
            // nutzen die JavaScript Syntax für die Deklaration von Objekten
            // Objekt: "{" Eigenschaft... "}"
            // Eigenschaft: "Name": "Wert" | Objekt
            // Arrays: "[" Objekt... "]"
            using var stream = File.OpenRead(configname);

            // Um die Methode "AddJsonStream" verwenden zu können,
            // müssen wir die *Library*: "Microsoft.Extensions.Configuration.Json" einbinden
            // in .NET heißen Libraries *NUGETS*

            // Bei der NuGet-Version auf die verwendete .NET Version des Projektes achten:
            // d.h. NuGet-Version 8.0.0 *KANN NICHT* für .NET Version 7.0.0 verwendet werden!
            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Configuration.AddConfiguration(config);

            return builder.Build();
        }
    }
}