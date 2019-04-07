using BowlingClasses.Core;
using BowlingClasses.UI.ViewModels;

namespace BowlingClasses.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(
                new ServiceCreationPartie(),
                new ServiceCalculScore());
        }
    }
}
