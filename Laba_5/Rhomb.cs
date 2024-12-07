using System;
using System.Drawing;

namespace Laba_5
{
    internal class Rhomb : Abstract_Figure
    {
        private double diag1; 
        private double diag2; 
        public Rhomb(double diag1, double diag2, double x_center, double y_center)
        {
            this.diag1 = diag1;
            this.diag2 = diag2;
            this.x_center = x_center;
            this.y_center = y_center;
        }

        private Point[] GetCurrPoints()
        {
           
            return new Point[]
            {
                new Point((int)x_center, (int)(y_center - diag2 / 2)), 
                new Point((int)(x_center + diag1 / 2), (int)y_center), 
                new Point((int)x_center, (int)(y_center + diag2 / 2)), 
                new Point((int)(x_center - diag1 / 2), (int)y_center), 
            };
        }

        public override void DrawBlack()
        {
            Graphics g = Form1.ActiveForm.CreateGraphics();
            g.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public override void HideDrawingBackGround()
        {
            Graphics g = Form1.ActiveForm.CreateGraphics();
            g.DrawPolygon(new Pen(Form1.ActiveForm.BackColor), GetCurrPoints());
        }
    }
}
