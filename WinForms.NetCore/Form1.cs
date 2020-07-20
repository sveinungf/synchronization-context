using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.NetCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TestLabel.Text = "SynchronizationContext: " +
                (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
                " TaskScheduler: " + TaskScheduler.Current;
        }

    }
}
