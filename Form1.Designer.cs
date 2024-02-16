namespace SpeechToText
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            StartBtn = new Button();
            StopBtn = new Button();
            dataGridView1 = new DataGridView();
            txtProductName = new DataGridViewTextBoxColumn();
            txtQuantity = new DataGridViewTextBoxColumn();
            txtPrice = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 55);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(292, 125);
            textBox1.TabIndex = 0;
            // 
            // StartBtn
            // 
            StartBtn.BackColor = SystemColors.MenuHighlight;
            StartBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StartBtn.ForeColor = SystemColors.ButtonHighlight;
            StartBtn.Location = new Point(71, 207);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(126, 36);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.BackColor = Color.Crimson;
            StopBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StopBtn.ForeColor = SystemColors.ButtonHighlight;
            StopBtn.Location = new Point(225, 207);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(117, 36);
            StopBtn.TabIndex = 2;
            StopBtn.Text = "Stop";
            StopBtn.UseVisualStyleBackColor = false;
            StopBtn.Click += StopBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { txtProductName, txtQuantity, txtPrice });
            dataGridView1.Location = new Point(403, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(370, 402);
            dataGridView1.TabIndex = 3;
            // 
            // txtProductName
            // 
            txtProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            txtProductName.HeaderText = "Product Name";
            txtProductName.Name = "txtProductName";
            // 
            // txtQuantity
            // 
            txtQuantity.HeaderText = "Quantity";
            txtQuantity.Name = "txtQuantity";
            // 
            // txtPrice
            // 
            txtPrice.HeaderText = "Price";
            txtPrice.Name = "txtPrice";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(StopBtn);
            Controls.Add(StartBtn);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button StartBtn;
        private Button StopBtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn txtProductName;
        private DataGridViewTextBoxColumn txtQuantity;
        private DataGridViewTextBoxColumn txtPrice;
    }
}
