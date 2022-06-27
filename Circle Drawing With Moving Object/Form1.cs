using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coding_Graphics
{

 
    public partial class Form1 : Form
    {
        Bitmap off;
        int xcent = 0;
        int ycent = 0;
        PointF Rectangle = new PointF(0, 0);
        float AngleBall = 0;
      
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            Timer t = new Timer();
            t.Start();
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Rectangle = GetNextPoint(xcent, ycent, 100, AngleBall);
            AngleBall += 15;
            DoubeBuffer(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            xcent = e.X;
            ycent = e.Y;
            DoubeBuffer(this.CreateGraphics());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubeBuffer(e.Graphics);
        }
        void DoubeBuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
            
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            DrawCircle(xcent, ycent, 100, g);
            g.FillRectangle(Brushes.Yellow, Rectangle.X-5  , Rectangle.Y-5, 20, 20);
            
  
        }

        void DrawCircle(int xce, int yce, int r, Graphics g)
        {
            float angle = 0;
            while (angle < 360)
            {
                float thetaRadian = (float)(angle * Math.PI / 180);
                float x = (float)(r * Math.Cos(thetaRadian)) + xce;
                float y = (float)(r * Math.Sin(thetaRadian)) + yce;
                g.FillEllipse(Brushes.Red, x, y, 5, 5);
                angle++;
            }

           
        }
        PointF GetNextPoint(int xcent, int ycent, int r, float angle)
        {
            float thetaRadian = (float)(angle * Math.PI / 180);
            float x = (float)(r * Math.Cos(thetaRadian)) + xcent;
            float y = (float)(r * Math.Sin(thetaRadian)) + ycent;

            PointF pnn = new PointF(x,y);
            return pnn;
        }
    }
      
}

