using Microsoft.Extensions.Configuration;
using NORTHWIND.DataAccess;
using NORTHWIND.ViewModels;
using NORTHWIND.Services;
using System.Reflection;
using System.Runtime.Loader;

namespace NORTHWIND
{
    public partial class App : Application
    {
        public App(IConfiguration config)
        {
            InitializeComponent();

            // "AppShell" bestimmt, welche View (zur Zeit "MainPageView")
            // angezeigt werden soll!
            // Die AppShell ermöglicht, das wechseln von Views und die Navigation
            // zwischen den Views!

            MainPage = new AppShell();

            var settings = config.GetSection("Settings").GetChildren();

            var component = settings.First(setting => setting.Key == "ComponentFile").Value;
            var repository = settings.First(setting => setting.Key == nameof(Settings.RepositoryType)).Value;

            var assembly = Assembly.GetExecutingAssembly();
            var currentDirectory = Path.GetDirectoryName(assembly.Location);

            var componentAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath($@"{currentDirectory}\{component}");
            var repositoryType = componentAssembly.GetType($"NORTHWIND.DataAccess.{repository}");

            ICustomersRepository customersRepository = (ICustomersRepository)Activator.CreateInstance(repositoryType);

            var viewModel = new MainPageViewModel(customersRepository);

            MainPage.BindingContext = viewModel;
        }
    }
}