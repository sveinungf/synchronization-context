using System.Threading.Tasks;
using System.Windows;

namespace Wpf.NetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TestLabel.Content = "SynchronizationContext: " +
                (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                " TaskScheduler: " + TaskScheduler.Current;
        }
    }
}
