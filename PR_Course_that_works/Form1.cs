using System;
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
            List<Hash> b = new List<Hash>();
            List<Hash> c = new List<Hash>();
            HashPoints a = new HashPoints(c);
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
                    b.Add(new Hash(T[j], ph));
                    c.Add(new Hash(T[j], LKK[j]));
                }

                j++;
            }
            a = new HashPoints(b);
            a.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            foreach (Hash p in c)
            {
                a.Points.AddXY(p.key, p.value);
            }
            chart1.Series.Add(a);
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
            List<Hash> d = new List<Hash>();
            List<Hash> c = new List<Hash>();
            HashPoints a = new HashPoints(c);
            int j = 0;
            double ph = 0;
            
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
                        if (T[j] > 0 && T[j] < 10000 && LKK[j] > 0 && LKK[j] < 10000)
                        {
                            d.Add(new Hash(T[j], ph)); 
                            c.Add(new Hash(T[j], LKK[j]));
                        }
                    }
                    catch
                    {
                        int f = 0;
                    }
                }                
                j++;
            }
            a = new HashPoints(d);
            a.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            foreach (Hash p in c)
            {
                a.Points.AddXY(p.key, p.value);
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
            if (res.Series != null)
            {
                try
                {
                    double ph = -9999.99;
                    //foreach (Hash item in TimeTable)
                    HashPoints a = (HashPoints)res.Series;
                    foreach (Hash item in a.TimeTable)
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
                System.Windows.Forms.DataVisualization.Charting.Series effective = new System.Windows.Forms.DataVisualization.Charting.Series();
                effective.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                effective.Name = "Effective";
                effective.LegendText = "Effective";
                effective.Color = Color.FromArgb(0, 200, 200);
                rostki(41.6096, 74.3114, -4.4328, 0.0000182, 2.02619, 17.501, 21.5838, -1.407, 0.00000918, 2.41374, 130);
                foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint c in chart1.Series[0].Points)
                {
                    if (IsParetoEffective(chart1.Series[0], c.XValue, c.YValues[0]))
                    {
                        effective.Points.AddXY(c.XValue, c.YValues[0]);
                    }
                }
                chart1.Series.Add(effective);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                System.Windows.Forms.DataVisualization.Charting.Series effective = new System.Windows.Forms.DataVisualization.Charting.Series();
                effective.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                effective.Name = "Effective";
                effective.LegendText = "Effective";
                effective.Color = Color.FromArgb(0, 200, 200);
                rostki(15.7373, 86.5843, -5.2542, 0.0000168, 2.0781, 14.0756, 33.9264, -2.5879, 0.0000118, 2.3288, 32);
                foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint c in chart1.Series[0].Points)
                {
                    if (IsParetoEffective(chart1.Series[0], c.XValue, c.YValues[0]))
                    {
                        effective.Points.AddXY(c.XValue, c.YValues[0]);
                    }
                }
                chart1.Series.Add(effective);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                System.Windows.Forms.DataVisualization.Charting.Series effective = new System.Windows.Forms.DataVisualization.Charting.Series();
                effective.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                effective.Name = "Effective";
                effective.LegendText = "Effective";
                effective.Color = Color.FromArgb(0, 200, 200);
                rostki(28.2615, 111.931, -7.3166, 0.0000266, 1.96125, 13.8432, 37.8703, -2.5819, 0.0000394, 2.02327, 90);
                foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint c in chart1.Series[0].Points)
                {
                    if (IsParetoEffective(chart1.Series[0], c.XValue, c.YValues[0]))
                    {
                        effective.Points.AddXY(c.XValue, c.YValues[0]);
                    }
                }
                chart1.Series.Add(effective);
                Form1.ActiveForm.Refresh();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                System.Windows.Forms.DataVisualization.Charting.Series effective = new System.Windows.Forms.DataVisualization.Charting.Series();
                effective.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                effective.Name = "Effective";
                effective.LegendText = "Effective";
                effective.Color = Color.FromArgb(0, 200, 200);
                rostki(49.3646, 58.4976, -4.1285, 0.00000902, 2.30974, 13.5127, 27.5435, -1.8062, 0.0000676, 1.94722, 120);
                foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint c in chart1.Series[0].Points)
                {
                    if (IsParetoEffective(chart1.Series[0], c.XValue, c.YValues[0]))
                    {
                        effective.Points.AddXY(c.XValue, c.YValues[0]);
                    }
                }
                chart1.Series.Add(effective);
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
                System.Windows.Forms.DataVisualization.Charting.Series effective = new System.Windows.Forms.DataVisualization.Charting.Series();
                effective.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                effective.Name = "Effective";
                effective.LegendText = "Effective";
                effective.Color = Color.FromArgb(0, 200, 200);
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
                foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint c in chart1.Series[0].Points)
                {
                    if (IsParetoEffective(chart1.Series[0], c.XValue, c.YValues[0]))
                    {
                        effective.Points.AddXY(c.XValue, c.YValues[0]);
                    }
                }
                chart1.Series.Add(effective);
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

        public bool IsParetoEffective(System.Windows.Forms.DataVisualization.Charting.Series a, double X, double Y)
        {
            bool res = false;
            //System.Windows.Forms.DataVisualization.Charting.DataPoint higherLeft = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
            //System.Windows.Forms.DataVisualization.Charting.DataPoint lowerLeft = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
            bool higher = false;
            bool lower = false;

            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint p in a.Points)
            { 
                if (p.XValue!=X && p.YValues[0] !=Y)
                {
                    if (p.XValue<X && p.YValues[0]>Y)
                    {
                        //higherLeft = new System.Windows.Forms.DataVisualization.Charting.DataPoint(p.XValue, p.YValues[0]);
                        higher = true;
                    }
                    else if(p.XValue<X && p.YValues[0] < Y)
                    {
                        //lowerLeft = new System.Windows.Forms.DataVisualization.Charting.DataPoint(p.XValue, p.YValues[0]);
                        lower = true;
                    }
                    /*else if (p.XValue < X && p.YValues[0] < Y)
                    {

                    }*/
                }
            }
            if (!higher && !lower) res = true;
            else if (lower && !higher) res = false;
            else if (!lower && higher) res = true;
            return res;
        }
    }
}
