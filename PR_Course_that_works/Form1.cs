﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_Course_that_works
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isLeftButtonPressed = false;
        private Point mouseDown = Point.Empty;
        private List<Hash> TimeTable = new List<Hash>();

        public void rostki(double A0, double A1, double A2, double B1, double B2, double C0, double C1, double C2, double D1, double D2, int limj)
        {
            chart1.Series.Clear();
            TimeTable.Clear();
            double[] LK = new double[200];
            double[] LKK = new double[200];
            double[] T = new double[200];
            int j = 0;
            double ph = 0;
            System.Windows.Forms.DataVisualization.Charting.Series a = new System.Windows.Forms.DataVisualization.Charting.Series();
            a.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int iph = 0; iph < limj; iph++)
            {
                if (radioButton1.Checked) ph = 7.0 * iph / 120;
                else if (radioButton2.Checked) ph = 8 + 8.0 * iph / 130;
                else if (radioButton3.Checked) ph = 6 + 7.5 * iph / 32;
                else ph = 9 + 8.0 * iph / 140;
                if (1 - 120.0 / (A0 + A1 * ph + A2 * ph * ph) > 0)
                {
                    T[j] = Math.Pow(Math.Log(1 - 120.0 / (A0 + A1 * ph + A2 * ph * ph)) / -B1, 1.0 / B2);
                    LK[j] = (C0 + C1 * ph + C2 * ph * ph) * (1 - Math.Pow(Math.E, -D1 * Math.Pow(T[j], D2)));
                    LKK[j] = (C0 + C1 * ph + C2 * ph * ph) * (1 - Math.Pow(Math.E, (-D1 * Math.Pow(T[j], D2))));
                    TimeTable.Add(new Hash(T[j], ph));
                    //chart1.Series[0].Points.AddXY(T[j], LK[j]);
                    //chart1.Series[0].Points.AddXY(ph, T[j]);
                    a.Points.AddXY(T[j], LKK[j]);
                }
                //Console.WriteLine(T[j].ToString() + " " + LK[j].ToString());
                j++;
            }
            chart1.Series.Add(a);
            //chart1.ChartAreas[0].AxisX.Minimum = 0;
            /*chart1.ChartAreas[0].AxisX.Maximum = 10;*/
            //chart1.ChartAreas[0].AxisX.Interval = 10;
            //chart1.ChartAreas[0].AxisY.Minimum = 10;
            //chart1.ChartAreas[0].AxisY.Maximum = 10;*/
            //chart1.ChartAreas[0].AxisY.Interval = 20;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisX.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisX.InterlacedColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.InterlacedColor = Color.Beige;
            chart1.ChartAreas[0].BackColor = Color.FromArgb(80, 70, 100);
            chart1.Series[0].Color = Color.Wheat;
            chart1.Series[0].BorderWidth = 2;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;

            // let's zoom to [0,blockSize] (e.g. [0,100])
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F3}";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F2}";
            // disable zoom-reset button (only scrollbar's arrows are available)
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 10;
            chart1.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 10;
        }

        public void Testrostki(int i, int r, int g, int b, double A0, double A1, double A2, double B1, double B2, double C0, double C1, double C2, double D1, double D2, int limj)
        {
            //chart1.Series[0].Points.Clear();
            //chart1.ChartAreas[0].AxisX.Minimum = 0;
            /*chart1.ChartAreas[0].AxisX.Maximum = 10;*/
            //chart1.ChartAreas[0].AxisX.Interval = 10;
            //chart1.ChartAreas[0].AxisY.Minimum = 10;
            //chart1.ChartAreas[0].AxisY.Maximum = 10;*/
            //chart1.ChartAreas[0].AxisY.Interval = 20;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisX.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.LineColor = Color.Beige;
            chart1.ChartAreas[0].AxisX.InterlacedColor = Color.Beige;
            chart1.ChartAreas[0].AxisY.InterlacedColor = Color.Beige;
            chart1.ChartAreas[0].BackColor = Color.FromArgb(80, 70, 100);
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            double[] LK = new double[30000];
            double[] LKK = new double[30000];
            double[] T = new double[30000];
            int j = 0;
            double ph = 0;
            System.Windows.Forms.DataVisualization.Charting.Series a = new System.Windows.Forms.DataVisualization.Charting.Series();
            a.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            for (int iph = -10000; iph < 10000; iph++)
            {
                if (radioButton1.Checked) ph = 7.0 * iph / 120;
                else if (radioButton2.Checked) ph = 8 + 8.0 * iph / 130;
                else if (radioButton3.Checked) ph = 6 + 7.5 * iph / 32;
                else ph = 9 + 8.0 * iph / 140;
                if (1 - 120.0 / (A0 + A1 * ph + A2 * ph * ph) > 0)
                {
                    try
                    {
                        T[j] = Math.Pow(Math.Log(1 - 120.0 / (A0 + A1 * ph + A2 * ph * ph)) / -B1, 1.0 / B2);
                        LK[j] = (C0 + C1 * ph + C2 * ph * ph) * (1 - Math.Pow(Math.E, -D1 * Math.Pow(T[j], D2)));
                        LKK[j] = (C0 + C1 * ph + C2 * ph * ph) * (1 - Math.Pow(Math.E, (-D1 * Math.Pow(T[j], D2))));
                        //chart1.Series[0].Points.AddXY(T[j], LK[j]);
                        //chart1.Series[0].Points.AddXY(ph, T[j]);
                        if (T[j] > 0 && T[j] < 10000 && LKK[j] > 0 && LKK[j] < 10000)
                        {
                            TimeTable.Add(new Hash(T[j], ph));
                            a.Points.AddXY(T[j], LKK[j]);
                        }
                    }
                    catch
                    {
                        int f = 0;
                    }
                }
                //Console.WriteLine(T[j].ToString() + " " + LK[j].ToString());
                j++;
            }
            chart1.Series.Add(a);
            chart1.Series[i].Color = Color.FromArgb(r, g, b);
            chart1.Series[i].BorderWidth = 2;
            chart1.ChartAreas[0].CursorX.AutoScroll = true;

            // let's zoom to [0,blockSize] (e.g. [0,100])
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F3}";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F2}";
            // disable zoom-reset button (only scrollbar's arrows are available)
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 10;
            chart1.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chart1.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rostki(49.3646, 58.4976, -4.1285, 0.00000902, 2.30974, 13.5127, 27.5435, -1.8062, 0.0000676, 1.94722, 120);
        }

        private void chart1_Click(object sender, EventArgs e)
        {            
            /*Form1.ActiveForm.Refresh();
            Form1 f2 = new Form1();
            f2.Show();*/
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLeftButtonPressed)
            {
                var result = chart1.HitTest(e.X, e.Y);

                if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea)
                {
                    var oldXValue = result.ChartArea.AxisX.PixelPositionToValue(mouseDown.X);
                    var newXValue = result.ChartArea.AxisX.PixelPositionToValue(e.X);
                    var oldYValue = result.ChartArea.AxisX.PixelPositionToValue(mouseDown.Y);
                    var newYValue = result.ChartArea.AxisX.PixelPositionToValue(e.Y);

                    chart1.ChartAreas[0].AxisY.ScaleView.Position -= oldYValue - newYValue;
                    mouseDown.Y = e.Y;
                    chart1.ChartAreas[0].AxisX.ScaleView.Position += oldXValue - newXValue;
                    mouseDown.X = e.X;
                }
            }
            label1.Visible = true;
            label2.Visible = true;
            var res = chart1.HitTest(e.X, e.Y);
            /*label1.Text = (this.PointToClient(Cursor.Position).X-chart1.Location.X).ToString();
            label2.Text = (this.PointToClient(Cursor.Position).Y - chart1.Location.Y).ToString();*/
            if (res.Series != null)
            {
                try
                {
                    double ph = -9999.99;
                    foreach (Hash item in TimeTable)
                    {
                        if (item.key == res.Series.Points[res.PointIndex].XValue) ph = item.value;
                    }
                    label2.Text = "LKK: " + res.Series.Points[res.PointIndex].YValues[0].ToString();
                    label1.Text = "T: " + res.Series.Points[res.PointIndex].XValue.ToString();
                    if (ph != -9999.99) label1.Text += "    ph:" + ph.ToString();
                }
                catch
                {
                    label2.Text = "LKK: ";
                    label1.Text = "T: ";
                }
            }
            label1.Location = new Point(this.PointToClient(Cursor.Position).X, this.PointToClient(Cursor.Position).Y+10);
            label2.Location = new Point(this.PointToClient(Cursor.Position).X-25, this.PointToClient(Cursor.Position).Y + 25);
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                rostki(41.6096, 74.3114, -4.4328, 0.0000182, 2.02619, 17.501, 21.5838, -1.407, 0.00000918, 2.41374, 130);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                rostki(15.7373, 86.5843, -5.2542, 0.0000168, 2.0781, 14.0756, 33.9264, -2.5879, 0.0000118, 2.3288, 32);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                rostki(28.2615, 111.931, -7.3166, 0.0000266, 1.96125, 13.8432, 37.8703, -2.5819, 0.0000394, 2.02327, 90);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                rostki(49.3646, 58.4976, -4.1285, 0.00000902, 2.30974, 13.5127, 27.5435, -1.8062, 0.0000676, 1.94722, 120);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                chart1.Series.Clear();
                TimeTable.Clear();
                int red = 0;
                int green = 0;
                int blue = 0;
                double A0 = 15.7373;
                double A1 = 86.5843;
                double A2 = -5.2542;
                double B1 = 0.0000168;
                double B2 = 2.0781;
                double C0 = 14.0756;
                double C1 = 33.9264;
                double C2 = -2.5879;
                double D1 = 0.0000118;
                double D2 = 2.3288;
                int j = 0;
                for (int i = 0; i < 10; i++)
                {
                    Testrostki(j, red, green, blue, A0, A1, A2, B1, B2, C0, C1, C2, D1, D2, 32);
                    red += 20;
                    green += 20;
                    blue += 20;
                    A0 += 1;
                    A1 -= 1;
                    j++;
                }
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonPressed = false;
                mouseDown = Point.Empty;
            }
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isLeftButtonPressed = true;
                mouseDown = e.Location;

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int position = trackBar1.Value;
            double size = Math.Pow(Math.E, 6-(double)position/83.32);
            
            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(100, 100+size);
            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, size);
        }
    }
}