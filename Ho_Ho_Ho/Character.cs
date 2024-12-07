using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ho_Ho_Ho
{
    internal class Character:IElement
    {
        private string name { get; set; }
        private Point location { get; set; }
        private Image image { get; set; }
        private Point? temp_location { get; set; } 
        private Point current_location => temp_location ?? location;
        private string type="Character";

        public string Name => name; 
        public Point Location => location; 
        public Image Image => image; 
        public Point CurrentLocation => current_location;
        public Point? TempLocation
        {
            get => temp_location;
            set => temp_location = value;
        }
        public string Type => type;

        public Character(string name, Point location, Image image)
        {
            this.name = name;
            this.location = location;
            this.image = image;
        }

        public string GetType()
        {
            return type;
        }
        public void Add(List<IElement> list)
        {
            list.Add(this);

        }
    }
}
