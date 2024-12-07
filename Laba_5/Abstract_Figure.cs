using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    internal abstract class Abstract_Figure
    {
        protected double x_center;
        protected double y_center;

        public abstract void DrawBlack();
        public abstract void HideDrawingBackGround();


        public async Task MoveRight()
        {
            for (int i = 0; i < 150; i++)
            {
                HideDrawingBackGround(); 
                x_center++;            
                DrawBlack();           
                await Task.Delay(10); 
            }
        }
    }
}
