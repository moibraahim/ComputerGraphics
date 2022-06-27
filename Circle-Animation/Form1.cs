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
        PolarCircle c1 = new PolarCircle(900, 500, 200);
        PolarCircle c2 = new PolarCircle(900, 500, 300);
        int gap = 20;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gap += 5;
            }
            else
            {
                if (e.KeyCode == Keys.Down)
                {
                    gap -= 5; 
                }
            }
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
            g.Clear(Color.White);
            c1.DrawCircle(g, gap, 0);
            c2.DrawCircle(g, gap, gap / 2);

            int anc2 = gap / 2;
            int anc1 = 0;
            int anc2b = 360 - (gap / 2);

            while (anc1 <= 360)
            {
                PointF pnc1 = c1.GetNextPoint(anc1);
                PointF pnc2 = c2.GetNextPoint(anc2);
                PointF pnc2b = c2.GetNextPoint(anc2b);
                g.DrawLine(Pens.Green, pnc1, pnc2);
                g.DrawLine(Pens.Green, pnc1, pnc2b);
                anc1 += gap;
                anc2 += gap;
                anc2b += gap;
                if (anc2b > 360)
                {
                    anc2b -= 360;
                }

            }

        }

    }


}

    



