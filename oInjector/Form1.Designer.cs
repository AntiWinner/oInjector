
namespace oInjector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.injectButton = new System.Windows.Forms.Button();
            this.processCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.Purple;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(291, 75);
            this.header.TabIndex = 0;
            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // injectButton
            // 
            this.injectButton.BackColor = System.Drawing.Color.White;
            this.injectButton.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.injectButton.FlatAppearance.BorderSize = 2;
            this.injectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkMagenta;
            this.injectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.injectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.injectButton.ForeColor = System.Drawing.Color.Black;
            this.injectButton.Location = new System.Drawing.Point(13, 292);
            this.injectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.injectButton.Name = "injectButton";
            this.injectButton.Size = new System.Drawing.Size(265, 46);
            this.injectButton.TabIndex = 1;
            this.injectButton.Text = "Inject";
            this.injectButton.UseVisualStyleBackColor = false;
            this.injectButton.Click += new System.EventHandler(this.injectButton_Click);
            this.injectButton.MouseEnter += new System.EventHandler(this.injectButton_MouseEnter);
            this.injectButton.MouseLeave += new System.EventHandler(this.injectButton_MouseLeave);
            // 
            // processCombo
            // 
            this.processCombo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.processCombo.FormattingEnabled = true;
            this.processCombo.Location = new System.Drawing.Point(13, 107);
            this.processCombo.Name = "processCombo";
            this.processCombo.Size = new System.Drawing.Size(265, 21);
            this.processCombo.TabIndex = 2;
            this.processCombo.DropDown += new System.EventHandler(this.processCombo_DropDown);
            this.processCombo.SelectedIndexChanged += new System.EventHandler(this.processCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(10, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Process:";
            // 
            // fileButton
            // 
            this.fileButton.BackColor = System.Drawing.Color.White;
            this.fileButton.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.fileButton.FlatAppearance.BorderSize = 2;
            this.fileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkMagenta;
            this.fileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileButton.ForeColor = System.Drawing.Color.Black;
            this.fileButton.Location = new System.Drawing.Point(13, 143);
            this.fileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(265, 131);
            this.fileButton.TabIndex = 4;
            this.fileButton.Text = "Choose a file\r\n(Drag And Drop Or Click)";
            this.fileButton.UseVisualStyleBackColor = false;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            this.fileButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileButton_DragDrop);
            this.fileButton.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileButton_DragEnter);
            this.fileButton.MouseEnter += new System.EventHandler(this.fileButton_MouseEnter);
            this.fileButton.MouseLeave += new System.EventHandler(this.fileButton_MouseLeave);
            // 
            // fileDialog
            // 
            this.fileDialog.Title = "oInjector - Choose an image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(291, 350);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processCombo);
            this.Controls.Add(this.injectButton);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Button injectButton;
        private System.Windows.Forms.ComboBox processCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.OpenFileDialog fileDialog;
    }
}

