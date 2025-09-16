namespace UI
{
    partial class Manager
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
            Customers = new Button();
            Products = new Button();
            Sales = new Button();
            SuspendLayout();
            // 
            // Customers
            // 
            Customers.Location = new Point(462, 111);
            Customers.Name = "Customers";
            Customers.Size = new Size(272, 130);
            Customers.TabIndex = 0;
            Customers.Text = "לקוחות";
            Customers.UseVisualStyleBackColor = true;
            Customers.Click += Customers_Click;
            // 
            // Products
            // 
            Products.Location = new Point(148, 111);
            Products.Name = "Products";
            Products.Size = new Size(272, 130);
            Products.TabIndex = 1;
            Products.Text = "מוצרים";
            Products.UseVisualStyleBackColor = true;
            // 
            // Sales
            // 
            Sales.Location = new Point(462, 272);
            Sales.Name = "Sales";
            Sales.Size = new Size(272, 130);
            Sales.TabIndex = 2;
            Sales.Text = "מבצעים";
            Sales.UseVisualStyleBackColor = true;
            // 
            // Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Sales);
            Controls.Add(Products);
            Controls.Add(Customers);
            Name = "Manager";
            Text = "Manager";
            ResumeLayout(false);
        }

        #endregion

        private Button Customers;
        private Button Products;
        private Button Sales;
    }
}