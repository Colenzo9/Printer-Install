using System.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System;
using System.Drawing.Printing;

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

            var OK = new Button();
            OK.Location = new Point(30, 523);
            OK.Text = "OK";
            OK.Size = new Size(75, 25);
            OK.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            OK.DialogResult = DialogResult.OK;
            Controls.Add(OK);
            OK.Click += OK_Click;

            var cancel = new Button();
            cancel.Location = new Point(175, 523);
            cancel.Text = "Cancel";
            cancel.Size = new Size(75, 25);
            cancel.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            cancel.DialogResult = DialogResult.Cancel;
            Controls.Add(cancel);
            cancel.Click += Cancel_Click;

            var listBox = new ListBox();
            listBox.Size = new Size(285, 520);
            Controls.Add(listBox);
            
            var server = new PrintServer(@"\\Print1");
            var queues = server.GetPrintQueues(new[]
            {
                EnumeratedPrintQueueTypes.PublishedInDirectoryServices
            });

            foreach (var printer in queues)
            {
                listBox.Items.Add(printer.FullName.Replace(@"\\Print1\", ""));
            }

            void Cancel_Click(object sender, EventArgs e)
            {
                Close();
            }

            void OK_Click(object sender, EventArgs e)
            {
                var printserv = new LocalPrintServer();
                printserv.ConnectToPrintQueue(@"\\print1\ad-it");
                Close();
            }
        }
    }
}