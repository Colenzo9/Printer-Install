using System;
using System.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Printer_Install
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select a Printer";
            Size = new Size(300, 600);
            Font = new Font("Arial", FontHeight = 11, FontStyle.Bold);

            var buttonLeft = new Button();
            buttonLeft.Location = new Point(30, 523);
            buttonLeft.Text = "Accept";
            buttonLeft.Size = new Size(75, 25);
            buttonLeft.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            buttonLeft.DialogResult = DialogResult.OK;
            Controls.Add(buttonLeft);

            var buttonRight = new Button();
            buttonRight.Location = new Point(175, 523);
            buttonRight.Text = "Cancel";
            buttonRight.Size = new Size(75, 25);
            buttonRight.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            buttonRight.DialogResult = DialogResult.Cancel;
            Controls.Add(buttonRight);

            var listBox = new ListBox();
            listBox.Name = "Shetberd";
            listBox.Size = new Size(285, 520);
            Controls.Add(listBox);

            var server = new PrintServer(@"\\Print1");
            var queues = server.GetPrintQueues(new[] 
            {
                EnumeratedPrintQueueTypes.Shared
            });

            foreach (var printer in queues)
            {
                listBox.Items.Add(printer.FullName.Replace(@"\\Print1\", ""));
            }

            var result = ShowDialog();

            if (result == buttonLeft.DialogResult)
            {
                Close();
            }

            if (result == buttonRight.DialogResult)
            {
                Close();
            }
        }
    }
}
