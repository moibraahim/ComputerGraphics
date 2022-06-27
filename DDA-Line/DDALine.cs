using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Coding_Graphics
{

    public class DDALine
    {
        public int xs;
        public  int ys;
        public int xe;
        public  int ye;
        public float cx;
        public float cy;
        public bool flagstop = false;
        public int speed = 15;

        public DDALine(int xst, int yst, int xen, int yen)
        {
            xs = xst;
            ys = yst;
            xe = xen;
            ye = yen;

             
        }
        
        //void DrawMyLine(Graphics g, int xs, int ys, int xe, int ye)
        //{
        //    float dx = xs - xe;
        //    float dy = ys - ye;
        //    float m = dy / dx;
        //    float cx = xs;
        //    float cy = ys;
        //    int speed = 1;
        //    while (true)
        //    {
        //        g.FillEllipse(Brushes.Red, cx, cy, 10, 10);
        //        if (Math.Abs(dx) > Math.Abs(dy))
        //        {
        //            if (xs < xe)
        //            {
        //                cx += speed;
        //                cy += m * speed;
        //                if (cx >= xe)
        //                {
        //                    break;
        //                }

        //            }
        //            else
        //            {
        //                cx--;
        //                cy -= m * speed;

        //                if (cx <= xe)
        //                {
        //                    break;
        //                }
        //            }



        //        }
        //        else
        //        {
        //            if (ys < ye)
        //            {
        //                cy += speed;
        //                cx += (1 / m) * speed;
        //                if (cy >= ye)
        //                {
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                cy -= speed;
        //                cx -= (1 / m) * speed;
        //                if (cy <= ye)
        //                {
        //                    break;
        //                }
        //            }

        //        }
        //    }

        //}
        public PointF GetNextPoint(float cx, float cy)
        {

            float dx = xs - xe;
            float dy = ys - ye;
            float m = dy / dx;

            


            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (xs < xe)
                {
                    cx += speed;
                    cy += m * speed;
                    if (cx >= xe)
                    {
                     
                        flagstop = true;


                    }

                }
                else
                {
                    cx -= speed;
                    cy -= m * speed;

                    if (cx <= xe)
                    {
                        flagstop = true;
                    }
                }
            }
            else
            {
                if (ys < ye)
                {
                    cy += speed;
                    cx += (1 / m) * speed;
                    if (cy >= ye)
                    {
                        flagstop = true;
                    }
                }
                else
                {
                    cy -= speed;
                    cx -= (1 / m) * speed;
                    if (cy <= ye)
                    {
                        flagstop = true;
                    }
                }

            }
            PointF pnn = new PointF(cx, cy);
            return pnn;
        }
    }
}
