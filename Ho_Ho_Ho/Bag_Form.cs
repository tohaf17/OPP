using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ho_Ho_Ho
{
    public partial class Bag_Form : Form
    {
        public Dictionary<Image,int> bag_elements = new Dictionary<Image,int>();
        public Bag_Form(Dictionary<Image,int> first,Dictionary<Image,int> second)
        {
            foreach(var image in first.Concat(second))
            {
                if (image.Value != 0)
                {
                    bag_elements[image.Key] = image.Value;
                }
            }
            InitializeComponent();
            LoadImages();
        }

        private void LoadImages()
        {
                Panel imagePanel = new Panel
                {
                    AutoScroll = true,   
                    Dock = DockStyle.Fill 
                };

                int x = 10;
                int y = 10;

                foreach (var image in bag_elements)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = image.Key, 
                        Size = new Size(100, 100),
                        Location = new Point(x, y),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    pictureBox.Click += (sender, args) => OnImageClick(image.Value.ToString()); 

                    imagePanel.Controls.Add(pictureBox);

                    y += 110;
                }

                this.Controls.Add(imagePanel);
            

        }

        private void OnImageClick(string imagePath)
        {
            MessageBox.Show($"Image clicked: {imagePath}");
        }
    }
}
