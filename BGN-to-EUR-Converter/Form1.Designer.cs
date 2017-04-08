namespace BGN_to_EUR_Converter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lOutput = new System.Windows.Forms.Label();
            this.inBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.inBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Convert";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(331, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "BGN to EUR";
            // 
            // lOutput
            // 
            this.lOutput.BackColor = System.Drawing.Color.Lime;
            this.lOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lOutput.Location = new System.Drawing.Point(55, 58);
            this.lOutput.Name = "lOutput";
            this.lOutput.Size = new System.Drawing.Size(398, 48);
            this.lOutput.TabIndex = 3;
            this.lOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inBox
            // 
            this.inBox.DecimalPlaces = 2;
            this.inBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inBox.Location = new System.Drawing.Point(153, 14);
            this.inBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.inBox.Name = "inBox";
            this.inBox.Size = new System.Drawing.Size(172, 38);
            this.inBox.TabIndex = 4;
            this.inBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inBox.ValueChanged += new System.EventHandler(this.textBox_TextChanged);
            this.inBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.inBox_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 148);
            this.Controls.Add(this.inBox);
            this.Controls.Add(this.lOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lOutput;
        private System.Windows.Forms.NumericUpDown inBox;
    }
}

