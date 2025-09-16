namespace UI
{
    partial class MainForm
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
            manager = new Button();
            Cashier = new Button();
            SuspendLayout();
            // 
            // manager
            // 
            manager.BackColor = SystemColors.ControlDark;
            manager.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            manager.Location = new Point(814, 233);
            manager.Name = "manager";
            manager.RightToLeft = RightToLeft.Yes;
            manager.Size = new Size(566, 208);
            manager.TabIndex = 0;
            manager.Text = "מנהל";
            manager.UseVisualStyleBackColor = false;
            manager.Click += button1_Click;
            // 
            // Cashier
            // 
            Cashier.BackColor = SystemColors.ControlDark;
            Cashier.Font = new Font("Microsoft Sans Serif", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            Cashier.Location = new Point(814, 486);
            Cashier.Name = "Cashier";
            Cashier.RightToLeft = RightToLeft.Yes;
            Cashier.Size = new Size(566, 208);
            Cashier.TabIndex = 1;
            Cashier.Text = "קופאי";
            Cashier.UseVisualStyleBackColor = false;
            Cashier.Click += Cashier_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1532, 846);
            Controls.Add(Cashier);
            Controls.Add(manager);
            Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "MainForm";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Button manager;
        private Button Cashier;
    }
}