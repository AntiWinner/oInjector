using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;

namespace oInjector
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        List<Process> processList = new List<Process>();
        string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {
    
            var brush = new LinearGradientBrush(header.ClientRectangle, Color.Fuchsia, Color.Purple, 0f);
            e.Graphics.FillRectangle(brush, header.ClientRectangle);
            var sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            e.Graphics.DrawString(" oInjector", new Font("Calibri", 19f, FontStyle.Bold), Brushes.White, header.ClientRectangle, sf);
       
        }

        private void injectButton_MouseEnter(object sender, EventArgs e)
        {
            injectButton.ForeColor = Color.White;
        }

        private void injectButton_MouseLeave(object sender, EventArgs e)
        {
            injectButton.ForeColor = Color.Black;
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void fileButton_MouseEnter(object sender, EventArgs e)
        {
            fileButton.ForeColor = Color.White;
        }

        private void fileButton_MouseLeave(object sender, EventArgs e)
        {
            fileButton.ForeColor = Color.Black;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
            filePath = fileDialog.FileName;
            fileButton.Text = $"({Path.GetFileName(filePath)})";
        }

        private void processCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileButton.AllowDrop = true;
        }

        private void injectButton_Click(object sender, EventArgs e)
        {
            var process = processList[processCombo.SelectedIndex];
            if (!process.Responding)
            {
                MessageBox.Show("Invalid process");
                return;
            }
            var handle = Orion.Memory.OpenProcess($"{process.ProcessName}.exe");
            var status = Orion.Memory.InjectFromFile(handle, filePath);
            Orion.Memory.CloseHandle(handle);
            MessageBox.Show($"Injection status: {status}", "oInjector");
        }

        private void fileButton_DragDrop(object sender, DragEventArgs e)
        {
            filePath = ((string[])e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault();
            fileButton.Text = $"({Path.GetFileName(filePath)})";
        }

        private void fileButton_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
                e.Effect = DragDropEffects.Copy;
        }

        private void processCombo_DropDown(object sender, EventArgs e)
        {
            processList.Clear();
            processCombo.Items.Clear();
            var list = Process.GetProcesses();
            foreach (var proc in list)
            {
                processCombo.Items.Add($"{proc.ProcessName} - {proc.Id}");
                processList.Add(proc);
            }
        }
    }
}
