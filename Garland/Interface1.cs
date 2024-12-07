using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garland
{
        internal interface IOption<T> where T : IOption<T>
        {
            T OptionQuickly(Graphics g, int i);
            T OptionSlowly(Graphics g, int i);
        }

    
}
