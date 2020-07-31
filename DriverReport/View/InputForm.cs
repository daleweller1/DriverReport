using DriverReport.Controller;
using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace DriverReport.View
{
    public class InputForm : OpenFileDialogForm
    {
        private Button selectFileButton;
        private OpenFileDialog openFileDialog;
        private TextBox outputBox;

        private InputController inputController;
        private OutputController outputController;

        public InputForm()
        {
            inputController = new InputController();
            outputController = new OutputController();

            openFileDialog = new OpenFileDialog();
            selectFileButton = new Button
            {
                Size = new Size(100, 20),
                Location = new Point(15, 15),
                Text = "Select .txt file"
            };
            selectFileButton.Click += new EventHandler(SelectButton_Click);
            outputBox = new TextBox
            {
                Size = new Size(300, 300),
                Location = new Point(15, 40),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ClientSize = new Size(330, 360);
            Controls.Add(selectFileButton);
            Controls.Add(outputBox);
        }

        private void SetText(string text)
        {
            outputBox.Text = text;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var report = inputController.GenerateReportFromFile(openFileDialog);
                    string output = outputController.GenerateReportOutput(report);
                    SetText(output);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
