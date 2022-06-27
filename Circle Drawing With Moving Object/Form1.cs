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
        PolarCircle MyCircle = new PolarCircle(0, 0, 100);
      
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
            Rectangle = MyCircle.GetNextPoint(AngleBall);
            AngleBall += 15;
            DoubeBuffer(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            MyCircle.xce = e.X;
            MyCircle.yce = e.Y;
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
            MyCircle.DrawCircle(g,1,0);
            g.FillRectangle(Brushes.Yellow, Rectangle.X-5  , Rectangle.Y-5, 20, 20);
            
  
        }

        
      
    }
      
}

