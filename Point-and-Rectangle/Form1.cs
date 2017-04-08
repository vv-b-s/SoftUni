using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_and_Rectangle
{
    public partial class FormPointAndRectangle : Form
    {
        private const int x1 = 0, y1 = 1, x2 = 2, y2 = 3, x = 4, y = 5; // fixed numbers for the coordinates
        public FormPointAndRectangle()
        {
            InitializeComponent();
        }

        private void FormPointAndRectangle_Load(object sender, EventArgs e)
        {
            UpdownSizes(100000, -10000, 2);
            _x1.Value = 2;
            _y1.Value = -3;
            _x2.Value = 12;
            _y2.Value = 3;
            _x.Value = 8;
            _y.Value = -1;

            Draw();
        }
        private void UpdownSizes(int maximum, int minimum, int dmp)              // sets the size of the NumericUpDown
        {
            NumericUpDown[] nuud = { _x1, _y1, _x2, _y2, _x, _y };
            for (int i = 0; i < nuud.Length; i++)
            {
                nuud[i].Maximum = maximum;
                nuud[i].Minimum = minimum;
                nuud[i].DecimalPlaces = dmp;
            }
        }
        private decimal UpdownSizes(int nmud)
        {
            NumericUpDown[] nuud = { _x1, _y1, _x2, _y2, _x, _y };
            return nuud[nmud].Value;
        }

        #region Fields
        private void _x1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void _y1_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void _x2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void _y2_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void _x_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void _y_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }
        #endregion
        private void Draw()
        {
            // Get the rectangle and point coordinates from the form
            var coordinates = new decimal[6];
            for (int i = 0; i < coordinates.Length; i++)
                coordinates[i] = UpdownSizes(i);

            // Display the location of the point: Inside / Border / Outside
            DisplayPointLocation(coordinates[x1], coordinates[y1], coordinates[x2], coordinates[y2], coordinates[x], coordinates[y]);

            //Calculate the scale fator (ratio) for the fiagram holding the rectangle and point in order to fit well in the picture box
            Rectangle[] scaleFactor = CalculateScaleFactor(coordinates[x1], coordinates[y1], coordinates[x2], coordinates[y2], coordinates[x], coordinates[y]);

            //Draw the rectangle point
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (var g = Graphics.FromImage(pictureBox.Image))
            {
                //Draw diagram background (white area)
                g.Clear(Color.White);

                // Draw the rectangle (scalled to the picture box size)
                var pen = new Pen(Color.DarkGreen, 5);
                g.DrawRectangle(pen, scaleFactor[0]);

                // Draw the point (scalled to the picture box size)
                pen = new Pen(Color.Brown, 5);
                g.DrawEllipse(pen, scaleFactor[1]);
            }
        }

        private void DisplayPointLocation(params decimal[] loc)
        {
            var left = Math.Min(loc[x1], loc[x2]);
            var right = Math.Max(loc[x1], loc[x2]);
            var top = Math.Max(loc[y1], loc[y2]);
            var bottom = Math.Min(loc[y1], loc[y2]);

            if(loc[x]>left&&loc[x]<right&&loc[y]<top&&loc[y]>bottom)
            {
                labelLocation.Text = "Inside";
                labelLocation.BackColor = Color.LightGreen;
            }
            else if(loc[x]<left||loc[x]>right||loc[y]<bottom||loc[y]>top)
            {
                labelLocation.Text = "Outside";
                labelLocation.BackColor = Color.LightSalmon;
            }
            else
            {
                labelLocation.Text = "Border";
                labelLocation.BackColor = Color.Gold;
            }
        }

        private Rectangle[] CalculateScaleFactor(params decimal[] loc)
        {
            var minX = Min(loc[x1], loc[x2], x);
            var maxX = Max(loc[x1], loc[x2], x);
            var maxY = Max(loc[y1], loc[y2], y);
            var minY = Min(loc[y1], loc[y2], y);

            var diagramWidth = maxX - minX;
            var diagramHeight = maxY - minY;

            var ratio = 1.0m;
            var offset = 10;

            if (diagramWidth != 0 && diagramHeight != 0)
            {
                var ratioX = (pictureBox.Width - 2 * offset - 1) / diagramWidth;
                var ratioY = (pictureBox.Height - 2 * offset - 1) / diagramHeight;
                ratio = Math.Min(ratioX, ratioY);
            }

            Rectangle[] draw = new Rectangle[2];
            //Calculate the scaled rectangle coordinates
            var rectLeft = offset + (int)Math.Round((Math.Min(loc[x1], loc[x2]) - minX) * ratio);
            var rectBottom = offset + (int)Math.Round((Math.Max(loc[y1], loc[y2]) - maxY) * ratio);
            var rectWidth = (int)Math.Round(Math.Abs(loc[x2] - loc[x1]) * ratio);
            var rectHight = (int)Math.Round(Math.Abs(loc[y2] - loc[y1]) * ratio);
            draw[0] = new Rectangle(rectLeft, rectBottom, rectWidth, rectHight);

            // Calculate the scalled point coordinates
            var pointX = (int)Math.Round(offset + (loc[x] - minX) * ratio);
            var pointY = (int)Math.Round(offset + (loc[y] - minY) * ratio);
            draw[1] = new Rectangle(pointX - 2, pointY - 2, 5, 5);

            return draw;
        }

        private decimal Min(params decimal[] val) => Math.Min(val[0], Math.Min(val[1], val[2]));

        private decimal Max(params decimal[] val) => Math.Max(val[0], Math.Max(val[1], val[2]));
    }

}
