using System.Windows;
using BowlingClasses.Core;
using BowlingClasses.Core.Interfaces;
using BowlingClasses.UI.Views;
using Prism.Ioc;
using Prism.Unity;

namespace BowlingClasses.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Obtient l'écran de démarrage.
        /// </summary>
        /// <returns>Vue principale.</returns>
        protected override Window CreateShell() => 
            Container.Resolve<MainWindow>();

        /// <summary>
        /// Injecteur de services.
        /// </summary>
        /// <param name="containerRegistry">Container.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Injection des services.
            containerRegistry.Register<IServiceCalculScore, ServiceCalculScore>();
            containerRegistry.Register<IServiceCreationPartie, ServiceCreationPartie>();
        }
    }
}
