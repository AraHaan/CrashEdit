using System;
using System.Windows.Forms;

namespace CrashEdit
{
    internal static class Program
    {
        [STAThread]
        internal static void Main(string[] args)
        {
            try
            {
                Crash.UI.Properties.Resources.Culture = new System.Globalization.CultureInfo(ConfigEditor.Languages[Properties.Settings.Default.Language]);
            }
            catch (System.Collections.Generic.KeyNotFoundException) {
                Properties.Settings.Default.Reset();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (OldMainForm mainform = new OldMainForm())
            using (ErrorReporter errorform = new ErrorReporter(mainform))
            {
                FileUtil.Owner = mainform;
                Application.Run(mainform);
            }
        }
    }
}
