namespace Centrala
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBeograd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewNoviSad = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewNis = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeograd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNoviSad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beograd";
            // 
            // dataGridViewBeograd
            // 
            this.dataGridViewBeograd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBeograd.Location = new System.Drawing.Point(14, 45);
            this.dataGridViewBeograd.Name = "dataGridViewBeograd";
            this.dataGridViewBeograd.RowHeadersWidth = 51;
            this.dataGridViewBeograd.RowTemplate.Height = 29;
            this.dataGridViewBeograd.Size = new System.Drawing.Size(418, 254);
            this.dataGridViewBeograd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(460, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Novi Sad";
            // 
            // dataGridViewNoviSad
            // 
            this.dataGridViewNoviSad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNoviSad.Location = new System.Drawing.Point(462, 45);
            this.dataGridViewNoviSad.Name = "dataGridViewNoviSad";
            this.dataGridViewNoviSad.RowHeadersWidth = 51;
            this.dataGridViewNoviSad.RowTemplate.Height = 29;
            this.dataGridViewNoviSad.Size = new System.Drawing.Size(418, 254);
            this.dataGridViewNoviSad.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(910, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nis";
            // 
            // dataGridViewNis
            // 
            this.dataGridViewNis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNis.Location = new System.Drawing.Point(912, 45);
            this.dataGridViewNis.Name = "dataGridViewNis";
            this.dataGridViewNis.RowHeadersWidth = 51;
            this.dataGridViewNis.RowTemplate.Height = 29;
            this.dataGridViewNis.Size = new System.Drawing.Size(418, 254);
            this.dataGridViewNis.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "Pregled Svih Org. Jedinica";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 407);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewNis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewNoviSad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewBeograd);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBeograd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNoviSad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewBeograd;
        private Label label2;
        private DataGridView dataGridViewNoviSad;
        private Label label3;
        private DataGridView dataGridViewNis;
        private Button button1;
    }
}