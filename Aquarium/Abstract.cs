using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquarium
{
    public  abstract class Abstract
    {
        protected string how_eat;
        protected Dictionary<Point, Point> fish_and_speed;

        public abstract void Move();
        public abstract void Cross(Dictionary<Point,Point> list);
    }
}
