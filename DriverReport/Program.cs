using DriverReport.Controller;
using DriverReport.View;
using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;

namespace DriverReport
{
    public class OpenFileDialogForm : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new InputForm());
        }
    }
}
