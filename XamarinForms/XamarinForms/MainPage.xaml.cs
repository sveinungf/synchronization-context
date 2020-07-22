using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TestLabel.Text = "SynchronizationContext: " +
                             (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                             " TaskScheduler: " + TaskScheduler.Current;
        }
    }
}
