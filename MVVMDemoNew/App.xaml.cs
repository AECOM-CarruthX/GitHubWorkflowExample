using MVVMDemoNew.Containers;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MVVMDemoNew.Cart;
using MVVMDemoNew.Catalog;
using MVVMDemoNew.Core;
using MVVMDemoNew.Services;
using System;

namespace MVVMDemoNew
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IShoppingItemsRepository, ShoppingItemsRepository>();
            services.AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
            services.AddTransient<ICatalogViewModel, CatalogViewModel>();
            services.AddTransient<ICartViewModel, CartViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<IMainWindowViewModel>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
