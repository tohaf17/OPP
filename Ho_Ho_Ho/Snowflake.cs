namespace Ho_Ho_Ho
{
    internal class Snowflake
    {
        private int centerX;
        private int centerY;
        private int size;
        private int speed; 
        private Random random = new Random();

        public int CenterX => centerX;
        public int CenterY => centerY;

        public Snowflake(int x, int y, int size, int speed)
        {
            this.centerX = x;
            this.centerY = y;
            this.size = size;
            this.speed = speed;
        }

        public void DrawSnowflake(Graphics g, int step)
        {
            Pen pen = new Pen(Color.Blue, 2);
            DrawBranch(g, pen, centerX, centerY, size, 3, step);
        }

        private void DrawBranch(Graphics g, Pen pen, int x, int y, int length, int levels, int step)
        {
            if (levels == 0) return;

            for (int i = 0; i < 6; i++)
            {
                double angle = Math.PI / 3 * i + step * Math.PI / 180.0;

                int xEnd = x + (int)(length * Math.Cos(angle));
                int yEnd = y + (int)(length * Math.Sin(angle));

                g.DrawLine(pen, x, y, xEnd, yEnd);
                DrawBranch(g, pen, xEnd, yEnd, length / 3, levels - 1, step);
            }
        }

        public void UpdatePosition(int screen_height,int screen_width)
        {
            centerY += speed;

            if (centerY > screen_height)
            {
                centerY = random.Next(-50, -10); 
                centerX = random.Next(0, screen_width); 
            }
        }
    }
}
