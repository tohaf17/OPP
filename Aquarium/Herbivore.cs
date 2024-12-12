using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Aquarium
{
    public class Herbivore : Abstract
    {
        private Random random;
        private Form form;

        public Herbivore(Form form, Random random)
        {
            this.random = random;
            this.form = form;
            how_eat = "Herbivore";
            fish_and_speed = new Dictionary<Point, Point>();
            GenerateDict();
        }
        public Dictionary<Point, Point> Fish_and_Speed => fish_and_speed;
        public void GenerateDict()
        {
            fish_and_speed.Clear();

            for (int i = 0; i < 50; i++)
            {
                Point start_point = new Point(
                    random.Next(0, form.ClientSize.Width),
                    random.Next(0, form.ClientSize.Height)
                );

                Point target_point = new Point(
                    random.Next(0, form.ClientSize.Width),
                    random.Next(0, form.ClientSize.Height)
                );

                fish_and_speed[start_point] = target_point;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var fish in fish_and_speed)
            {
                Point start_point = fish.Key;
                int side = 20;

                using (Brush bodyBrush = new SolidBrush(Color.Orange))
                {
                    g.FillEllipse(bodyBrush, start_point.X, start_point.Y, side, side);

                    Point[] tail =
                    {
                        new Point(start_point.X, start_point.Y + side / 2),
                        new Point(start_point.X - side / 2, start_point.Y),
                        new Point(start_point.X - side / 2, start_point.Y + side)
                    };
                    g.FillPolygon(bodyBrush, tail);

                    using (Brush eyeBrush = new SolidBrush(Color.Black))
                    {
                        g.FillEllipse(eyeBrush, start_point.X + side - side / 4, start_point.Y + side / 4, side / 8, side / 8);
                    }
                }
            }
        }
        public override void Move()
        {
            var updatedFish = new Dictionary<Point, Point>();

            foreach (var fish in fish_and_speed)
            {
                Point currentPosition = fish.Key;
                Point targetPosition = fish.Value;
                if (currentPosition.X == targetPosition.X && currentPosition.Y == targetPosition.Y)
                {
                    targetPosition = new Point(
                        random.Next(0, form.ClientSize.Width),
                        random.Next(0, form.ClientSize.Height)
                    );
                }
                else
                {
                    int deltaX = targetPosition.X - currentPosition.X;
                    int deltaY = targetPosition.Y - currentPosition.Y;

                    int stepX = Math.Sign(deltaX) * Math.Min(5, Math.Abs(deltaX));
                    int stepY = Math.Sign(deltaY) * Math.Min(5, Math.Abs(deltaY));

                    currentPosition.X += stepX;
                    currentPosition.Y += stepY;
                }

                updatedFish[currentPosition] = targetPosition;
            }

            fish_and_speed = updatedFish;
        }
        public override void Cross(Dictionary<Point, Point> list)
        {
            throw new NotImplementedException();    
        }
    }
}
