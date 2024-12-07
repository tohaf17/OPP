using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garland
{
    internal class Garland : IOption<Garland>
    {
        public Garland OptionQuickly(Graphics g, int j)
            {
                SolidBrush[] colors = new SolidBrush[3] { new SolidBrush(Color.Blue), new SolidBrush(Color.Red), new SolidBrush(Color.Green) };
                int x_start_first = -60;
                int high_low_coordinate = 80;
                bool high_low = true;
                for (int i = 0; i < 50; i++)
                {
                    high_low_coordinate = (high_low) ? 10 : 80;
                    g.FillEllipse(colors[(i + j) % 3], x_start_first += 70, high_low_coordinate, 100, 100);
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

            for (int i = 0; i < 50; i++)
            {
                high_low_coordinate = (high_low) ? 10 : 80;
                int x_center = x_start_first += 70; 
                int y_center = high_low_coordinate + 50; 

                for (int radius = 0; radius <= 50; radius += 5) 
                {
                    g.FillEllipse(colors[(i + j) % 3], x_center - radius, y_center - radius, radius * 2, radius * 2);
                    
                }

                high_low = !high_low;
            }

            return this;
        }
    }

    
}
