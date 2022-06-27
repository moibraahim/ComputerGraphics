using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coding_Graphics
{
    public class PolarCircle
    {
        public int xce;
        public int yce;
        public int r;
        public PolarCircle(int x, int y, int rad)
        {
            xce = x;
            yce = y;
            r = rad;

        }
        public void DrawCircle(Graphics g , int gap , int sangle)
        {
            float angle = sangle;
            while (angle < 360)
            {
                float thetaRadian = (float)(angle * Math.PI / 180);
                float x = (float)(r * Math.Cos(thetaRadian)) + xce;
                float y = (float)(r * Math.Sin(thetaRadian)) + yce;
                g.FillEllipse(Brushes.Red, x, y, 5, 5);
                angle += gap;
            }


        }
        public PointF GetNextPoint(float angle)
        {
            float thetaRadian = (float)(angle * Math.PI / 180);
            float x = (float)(r * Math.Cos(thetaRadian)) + xce;
            float y = (float)(r * Math.Sin(thetaRadian)) + yce;

            PointF pnn = new PointF(x, y);
            return pnn;
        }
    }
}
