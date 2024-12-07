using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Circle:Abstract_Figure
    {
        private double radius;
        public Circle(double radius,double x_center,double y_center)
        {
            this.radius = radius;
            this.x_center = x_center;
            this.y_center = y_center;
        }
        private Point[] GetCurrPoints()
        {
            return new Point[] {
                new Point((int)(x_center - radius),  (int)(y_center - radius)),
                new Point((int)(x_center- radius),  (int)(y_center + radius)),
                new Point((int)(x_center +radius),  (int)(y_center + radius)),
                new Point((int)(x_center + radius),  (int)(y_center - radius)),
            };
        }
        public override void DrawBlack()
        {
            Graphics g = Form1.ActiveForm.CreateGraphics();
            g.DrawEllipse(Pens.Black, (float)(x_center - radius), (float)(y_center - radius), (float)(2 * radius), (float)(2 * radius));

        }
        public override void HideDrawingBackGround()
        {
            Graphics g = Form1.ActiveForm.CreateGraphics();
            g.DrawEllipse(new Pen(Form1.ActiveForm.BackColor), (float)(x_center - radius), (float)(y_center - radius), (float)(2 * radius), (float)(2 * radius));
        }
    }
    }

