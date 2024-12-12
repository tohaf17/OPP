using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Bubble
    {

        private int centerX;
        private int centerY;
        private int size;
        private int speed;
        private Random random = new Random();

        public int CenterX => centerX;
        public int CenterY => centerY;

        public Bubble(int x, int y, int size, int speed)
        {
            this.centerX = x;
            this.centerY = y;
            this.size = size;
            this.speed = speed;
        }

        public void DrawBubble(Graphics g, int step)
        {
            Pen pen = new Pen(Color.Blue, 2);
            
            g.DrawEllipse(pen, centerX, CenterY , size, size);
        }


        public void UpdatePosition(int screen_height, int screen_width)
        {
            centerY -= speed;
            if (centerY < 0)
            {
                centerY = random.Next(screen_height, screen_height + 50);
                centerX = random.Next(0, screen_width);
            }
        }

    }
}
