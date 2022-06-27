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
        PointF ball = new PointF(10, 10);
        int x1 = 10;
        int y1 = 10;
        int x2 = 230;
        int y2 = 250;
        int x3 = 0;
        int y3 = 0;
        
        int flagd = 1;
        int CountClick = 0;
        int FlagRepeatClick = 0;
        DDALine L1,L2,L3;
     
       

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

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (CountClick == 0)
            {
                x1 = e.X;
                y1 = e.Y;
                ball.X = x1;
                ball.Y = y1;
                FlagRepeatClick = 0;
            }
            else
            {
                if (CountClick == 1)
                {
                   
                    x2 = e.X;
                    y2 = e.Y;
                   
                }
                else
                {
                    x3 = e.X;
                    y3 = e.Y;
                    FlagRepeatClick = 1;
                    CountClick = -1;
                    L1 = new DDALine(x1, y1, x2, y2);
                    L2 = new DDALine(x2, y2, x3, y3);
                    L3 = new DDALine(x3, y3, x1, y1);

                }
            }
            CountClick++;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (FlagRepeatClick == 1)
            {
                if (flagd == 1)
                {
                    ball = L1.GetNextPoint(ball.X, ball.Y);
                    if (L1.flagstop == true)
                    {
                        flagd = 2;
                        ball.X = L2.xs;
                        ball.Y = L2.ys;
                    }
                  
                }
                else
                {
                    if (flagd == 2)
                    {
                        ball = L2.GetNextPoint(ball.X, ball.Y);
                        if (L2.flagstop == true)
                        {
                            flagd = 3;
                            ball.X = L3.xs;
                            ball.Y = L3.ys;
                        }
                    }
                    else
                    {
                        if (flagd == 3)
                        {
                            ball = L3.GetNextPoint(ball.X, ball.Y);
                            if (L3.flagstop == true)
                            {
                                flagd = 1;
                                ball.X = L1.xs;
                                ball.Y = L1.ys;
                                L1.flagstop = false;
                                L2.flagstop = false;
                                L3.flagstop = false;
                             
                            }
                        }


                    }
                }
            }
            
           
           
            DoubleBuffer(this.CreateGraphics());
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
           
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffer(e.Graphics);
        }

      
        void DoubleBuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            if (FlagRepeatClick == 1)
            {
                
                g.DrawLine(Pens.Red, x1, y1, x2, y2);
               
                g.DrawLine(Pens.Red, x2, y2, x3, y3);
                g.DrawLine(Pens.Red, x3, y3, x1, y1);
                g.FillEllipse(Brushes.Yellow, ball.X-15, ball.Y-15, 30, 30);
            }
            
           
        }

    }
      
}

