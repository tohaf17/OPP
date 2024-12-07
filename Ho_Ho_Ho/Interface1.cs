using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ho_Ho_Ho
{
    internal interface IElement
    {
        void Add(List<IElement> list);
        string GetType();
        Image Image { get; }
        Point CurrentLocation { get; }
        Point? TempLocation { get; set; }
    }
}
