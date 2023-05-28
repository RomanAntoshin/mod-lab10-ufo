using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace lab10
{
    public partial class Form1 : Form
    {
        static int x0 = 100;
        static int y0 = 100;
        static int xk = 1200;
        static int yk = 700;
        static double x1 = x0, y1 = y0;
        //double alfa = Math.Atan((double)(yk - y0)/(double)(xk - x0));
        double alfa = MyAtan((double)(yk - y0) / (double)(xk - x0), 4);
        //double alfa = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = e.Graphics;
            g.ScaleTransform(0.5f, 0.5f);
            g.FillEllipse(brush, new Rectangle(x0-10, y0-10, 20, 20));
            g.FillEllipse(brush, new Rectangle(xk-10, yk-10, 20, 20));
            //g.FillEllipse(new SolidBrush(Color.Red), xk, yk, 25,25)
            g.DrawEllipse(new Pen(Color.Red, 2), xk-30, yk-30, 60, 60);
            g.DrawEllipse(new Pen(Color.Green, 2), xk - 50, yk - 50, 100, 100);
            g.DrawEllipse(new Pen(Color.Blue, 2), xk - 75, yk - 75, 150, 150);
            g.DrawEllipse(new Pen(Color.Aquamarine, 2), xk - 100, yk - 100, 200, 200);
            //double buf = 5 * MyCos(alfa, 1);
            //x1 += (5 * Math.Cos(alfa));
            x1 -= (5 * MyCos(alfa, 4));
            //y1 -= (5 * Math.Sin(alfa));
            y1-= (5 * MySin(alfa, 4));
            g.FillEllipse(new SolidBrush(Color.BlueViolet), (int)(x1 - 5), (int)(y1 - 5), 10, 10);
            if ((int)(x1 - 5) > xk)
                timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        public static double MyAtan(double x, int n)
        {
            double y=0;
            /*if (x <= -1 && x >= 1)
            {
                y = 0;
            }*/
            /*if(x>1)
            {
                y = Math.PI/2;
            }*/
            /*if(x<-1)
            {
                y = -Math.PI / 2;
            }*/
            for(int i=1; i<=n; i++)
            {
                y = y + Math.Pow(-1, i-1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            }
            return y;
        }
        public static double MySin(double x, int n)
        {
            double y = 0;
            for(int i=1; i<=n; i++)
            {
                y = y + Math.Pow(-1, i) * Math.Pow(x, 2 * i - 1) / Factr(2 * i - 1);
            }
            return y;
        }
        public static double MyCos(double x, int n)
        {
            double y = 0;
            for (int i = 1; i <= n; i++)
            {
                y = y + Math.Pow(-1, i) * Math.Pow(x, 2 * i - 2) / Factr(2 * i - 2);
            }
            return y;
        }
        public static int Factr(int k)
        {
            int y = 1;
            if (k == 0 || k == 1)
                return y;
            else
                for (int i = 2; i <= k; i++)
                    y = y * i;
            return y;
        }
    }
}
