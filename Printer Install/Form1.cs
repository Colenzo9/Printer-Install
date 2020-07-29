using System.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System;

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

            var acceptButton = new Button();
            acceptButton.Location = new Point(30, 523);
            acceptButton.Text = "Accept";
            acceptButton.Size = new Size(75, 25);
            acceptButton.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            acceptButton.DialogResult = DialogResult.OK;
            Controls.Add(acceptButton);

            var cancelButton = new Button();
            cancelButton.Location = new Point(175, 523);
            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(75, 25);
            cancelButton.Font = new Font("Arial", FontHeight = 9, FontStyle.Regular);
            cancelButton.DialogResult = DialogResult.Cancel;
            Controls.Add(cancelButton);

            var listBox = new ListBox();
            listBox.Name = "Shetberd";
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
            
            var result = ShowDialog();
            //ManagementClass Win32_Printer = new ManagementClass("Win32_Printer");
            //ManagementBaseObject inputParam = Win32_Printer.GetMethodParameters("AddPrinterConnection");
            //inputParam.SetPropertyValue("Name", listBox.SelectedItem);

            if (result == acceptButton.DialogResult)
            {
                Close();
                //_ = Win32_Printer.InvokeMethod("AddPrinterConnection", inputParam, null);
            }
            
            if (result == cancelButton.DialogResult)
            {
                Close();
            }
        }
    }
}