using System;
using System.Windows.Forms;

namespace MetroFramework.Samples
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlsShowcaseForm());
        }
    }
}
