using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garland_1
{
    internal class Garland : IOption<Garland>
    {
        private bool[] states;
        public int count = 30;
        public Garland()
        {
            states = new bool[count];
            for (int i = 0; i < count; i++)
            {
                states[i] = true;
            }
        }
        public Garland OptionQuickly(Graphics g, int j)
        {
            SolidBrush[] colors = new SolidBrush[]
            {
            new SolidBrush(Color.Blue),
            new SolidBrush(Color.Red),
            new SolidBrush(Color.Green)
            };

            int x_start_first = -60;
            int high_low_coordinate = 80;
            bool high_low = true;

            for (int i = 0; i < count; i++)
            {
                high_low_coordinate = (high_low) ? 10 : 80;

                if (!states[i])
                {
                    g.DrawEllipse(Pens.Black, x_start_first += 70, high_low_coordinate, 100, 100);
                }
                else
                {
                    g.FillEllipse(colors[(i + j) % 3], x_start_first += 70, high_low_coordinate, 100, 100);
                }

                high_low = !high_low;
            }
            return this;
        }
        public Garland OptionSlowly(Graphics g, int j)
        {
            SolidBrush[] colors = new SolidBrush[3]
            {
                new SolidBrush(Color.Blue),
                new SolidBrush(Color.Red),
                new SolidBrush(Color.Green)
            };

            int x_start_first = -60;
            int high_low_coordinate = 80;
            bool high_low = true;

            for (int i = 0; i < count; i++)
            {
                high_low_coordinate = (high_low) ? 10 : 80;
                int x_center = x_start_first += 70;
                int y_center = high_low_coordinate + 50;
                int radius = 5 * ((j + i) % 10);
                if (!states[i])
                {
                    g.DrawEllipse(Pens.Black, x_center - radius, y_center - radius, radius * 2, radius * 2);
                }
                else
                {
                    g.FillEllipse(colors[(j + i) % 3], x_center - radius, y_center - radius, radius * 2, radius * 2);
                }
                

                high_low = !high_low;
            }

            return this;
        }
        public int GetCircleIndex(int x, int y)
        {
            int x_start_first = -60;
            bool high_low = true;

            for (int i = 0; i < count; i++)
            {
                int high_low_coordinate = (high_low) ? 10 : 80;
                int x_center = x_start_first += 70;
                int y_center = high_low_coordinate + 50;

                int dx = x - x_center;
                int dy = y - y_center;
                if (dx * dx + dy * dy <= 2500) 
                {
                    return i;
                }

                high_low = !high_low;
            }

            return -1;
        }
        public Garland Off(int index)
        {
            for (int i = index; i < states.Length; i++)
            {
                states[i] = false; 
            }
            return this;
        }

        public Garland On(int index)
        {
            for (int i = index; i < states.Length; i++)
            {
                states[i] = true;
            }
            return this;
        }
        public bool IsOff(int index)
        {
            return !states[index];
        }
    }

}
