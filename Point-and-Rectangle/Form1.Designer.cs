namespace Point_and_Rectangle
{
    partial class FormPointAndRectangle
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this._x1 = new System.Windows.Forms.NumericUpDown();
            this._y1 = new System.Windows.Forms.NumericUpDown();
            this._x2 = new System.Windows.Forms.NumericUpDown();
            this._y2 = new System.Windows.Forms.NumericUpDown();
            this._x = new System.Windows.Forms.NumericUpDown();
            this._y = new System.Windows.Forms.NumericUpDown();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._x1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._y1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._x2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._y2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._y)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rectangle:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "x1 =";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "y1 =";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "x2 =";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "y2 =";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Point:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "x =";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(21, 243);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "y =";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(157, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(515, 347);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // _x1
            // 
            this._x1.DecimalPlaces = 2;
            this._x1.Location = new System.Drawing.Point(67, 38);
            this._x1.Name = "_x1";
            this._x1.Size = new System.Drawing.Size(68, 26);
            this._x1.TabIndex = 9;
            this._x1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this._x1.ValueChanged += new System.EventHandler(this._x1_ValueChanged);
            // 
            // _y1
            // 
            this._y1.DecimalPlaces = 2;
            this._y1.Location = new System.Drawing.Point(67, 70);
            this._y1.Name = "_y1";
            this._y1.Size = new System.Drawing.Size(68, 26);
            this._y1.TabIndex = 10;
            this._y1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this._y1.ValueChanged += new System.EventHandler(this._y1_ValueChanged);
            // 
            // _x2
            // 
            this._x2.Location = new System.Drawing.Point(67, 102);
            this._x2.Name = "_x2";
            this._x2.Size = new System.Drawing.Size(68, 26);
            this._x2.TabIndex = 11;
            this._x2.ValueChanged += new System.EventHandler(this._x2_ValueChanged);
            // 
            // _y2
            // 
            this._y2.Location = new System.Drawing.Point(67, 134);
            this._y2.Name = "_y2";
            this._y2.Size = new System.Drawing.Size(68, 26);
            this._y2.TabIndex = 12;
            this._y2.ValueChanged += new System.EventHandler(this._y2_ValueChanged);
            // 
            // _x
            // 
            this._x.Location = new System.Drawing.Point(67, 213);
            this._x.Name = "_x";
            this._x.Size = new System.Drawing.Size(68, 26);
            this._x.TabIndex = 13;
            this._x.ValueChanged += new System.EventHandler(this._x_ValueChanged);
            // 
            // _y
            // 
            this._y.Location = new System.Drawing.Point(67, 245);
            this._y.Name = "_y";
            this._y.Size = new System.Drawing.Size(68, 26);
            this._y.TabIndex = 14;
            this._y.ValueChanged += new System.EventHandler(this._y_ValueChanged);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(17, 287);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(118, 32);
            this.buttonDraw.TabIndex = 15;
            this.buttonDraw.Text = "Draw";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.PaleGreen;
            this.labelLocation.Location = new System.Drawing.Point(17, 322);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(118, 32);
            this.labelLocation.TabIndex = 16;
            this.labelLocation.Text = "label9";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPointAndRectangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 371);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this._y);
            this.Controls.Add(this._x);
            this.Controls.Add(this._y2);
            this.Controls.Add(this._x2);
            this.Controls.Add(this._y1);
            this.Controls.Add(this._x1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "FormPointAndRectangle";
            this.Text = "Point and Rectangle";
            this.Load += new System.EventHandler(this.FormPointAndRectangle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._x1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._y1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._x2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._y2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._y)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown _x1;
        private System.Windows.Forms.NumericUpDown _y1;
        private System.Windows.Forms.NumericUpDown _x2;
        private System.Windows.Forms.NumericUpDown _y2;
        private System.Windows.Forms.NumericUpDown _x;
        private System.Windows.Forms.NumericUpDown _y;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Label labelLocation;
    }
}

