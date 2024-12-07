using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal class Square:Abstract_Figure
    {
        private double size;
        public Square(double centerX, double centerY, double size)
        {
            x_center = centerX;
            y_center = centerY;
            this.size = size;
        }


        private Point[] GetCurrPoints()
        {
            return new Point[] {
                new Point((int)(x_center - size),  (int)(y_center - size)),
                new Point((int)(x_center- size),  (int)(y_center + size)),
                new Point((int)(x_center +size),  (int)(y_center + size)),
                new Point((int)(x_center + size),  (int)(y_center - size)),
            };
        }

        public override void DrawBlack()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public override void HideDrawingBackGround()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(new Pen(Form1.ActiveForm.BackColor), GetCurrPoints());
        }

    }
}
