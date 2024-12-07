using System;
using System.Drawing.Drawing2D;

namespace Ho_Ho_Ho
{
    public partial class Form1 : Form
    {
        //Snowflake
        private int step = 1;
        private List<Snowflake> snowflakes = new List<Snowflake>();
        private Random random = new Random();

        //Drag and drop images
        private List<IElement> items = new List<IElement>();
        private List<IElement> staticItems = new List<IElement>();


        private Rectangle bag_area;
        private IElement draggedItem = null;
        private Point dragOffset;


        private Image bag_image = Image.FromFile("D:\\Нова папка (2)\\bag.png");
        //Images_character
        private static Image santa_image = Image.FromFile("D:\\Нова папка (2)\\santa.png");
        private static Image deer_image = Image.FromFile("D:\\Нова папка (2)\\deer.png");
        private static Image elf_image = Image.FromFile("D:\\Нова папка (2)\\elf.png");
        private static Image gingerbread_image = Image.FromFile("D:\\Нова папка (2)\\gingerbread.png");
        private static Image snowman_image = Image.FromFile("D:\\Нова папка (2)\\snowman.png");
        //Images_things
        private static Image candies_image = Image.FromFile("D:\\Нова папка (2)\\candies.png");
        private static Image candle_image = Image.FromFile("D:\\Нова папка (2)\\candle.png");
        private static Image christmas_tree_image = Image.FromFile("D:\\Нова папка (2)\\christmas_tree.png");
        private static Image gift_image = Image.FromFile("D:\\Нова папка (2)\\gift.png");
        private static Image sled_image = Image.FromFile("D:\\Нова папка (2)\\sled.png");

        //Count for objects
        private Dictionary<Image, int> dictionary_characters = new Dictionary<Image, int>()
        {
            { santa_image,0 },
            { deer_image,0 },
            { elf_image,0 },
            { gingerbread_image,0 },
            { snowman_image,0 },
        };
        private Dictionary<Image, int> dictionary_things = new Dictionary<Image, int>()
        {
            { candies_image,0 },
            { candle_image,0 },
            { christmas_tree_image,0 },
            { gift_image,0 },
            { sled_image,0 },
        };


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            this.BackColor = Color.Transparent;
            this.BackgroundImage = Image.FromFile(@"D:\winter-landscape-4532412_640.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            GenerateSnowflakes();
            timer1.Interval = 50;


            bag_area = new Rectangle(200, 300, 150, 150);
            items.Add(new Character("Santa", new Point(50, 50), santa_image));
            items.Add(new Character("Snowman", new Point(250, 50), snowman_image));
            items.Add(new Character("Deer", new Point(450, 50), deer_image));
            items.Add(new Character("Elf", new Point(650, 50), elf_image));
            items.Add(new Character("Gingerbread", new Point(850, 50), gingerbread_image));

            items.Add(new Thing("Candies", new Point(50, 550), candies_image));
            items.Add(new Thing("Candle", new Point(250, 550), candle_image));
            items.Add(new Thing("Christmas Tree", new Point(450, 550), christmas_tree_image));
            items.Add(new Thing("Gift", new Point(650, 550), gift_image));
            items.Add(new Thing("Sled", new Point(850, 550), sled_image));



            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var item in staticItems.Concat(items))
            {
                g.DrawImage(item.Image, item.CurrentLocation.X, item.CurrentLocation.Y, 150, 150);
            }
            staticItems.Clear();
            g.DrawImage(bag_image, bag_area.X, bag_area.Y, bag_area.Width, bag_area.Height);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            draggedItem = items.FirstOrDefault(item => new Rectangle(item.CurrentLocation, new Size(150, 150)).Contains(e.Location));

            if (draggedItem != null)
            {
                dragOffset = new Point(e.X - draggedItem.CurrentLocation.X, e.Y - draggedItem.CurrentLocation.Y);
                this.Cursor = Cursors.Hand;
            }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedItem != null)
            {
                draggedItem.TempLocation = new Point(e.X - dragOffset.X, e.Y - dragOffset.Y);
                this.Invalidate();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (draggedItem != null)
            {
                bool updated = false;

                if (bag_area.Contains(e.Location))
                {
                    if (!staticItems.Contains(draggedItem))
                    {
                        if (draggedItem is Character character)
                        {
                            staticItems.Add(character);
                            var characterImage = character.Image;
                            if (dictionary_characters.ContainsKey(characterImage))
                            {
                                dictionary_characters[characterImage]++;
                                updated = true;
                            }
                            else
                            {
                                dictionary_characters.Add(characterImage, 1);
                                updated = true;
                            }
                        }
                        else if (draggedItem is Thing thing)
                        {
                            staticItems.Add(thing);
                            var thingImage = thing.Image;
                            if (dictionary_things.ContainsKey(thingImage))
                            {
                                dictionary_things[thingImage]++;
                                updated = true;
                            }
                            else
                            {
                                dictionary_things.Add(thingImage, 1);
                                updated = true;
                            }
                        }
                    }
                }
                else
                {
                    if (draggedItem != null && !items.Contains(draggedItem))
                    {
                        items.Add(draggedItem);
                    }
                }

                this.Invalidate();
                

                draggedItem.TempLocation = null;
                this.Cursor = Cursors.Default;
                draggedItem = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.UpdatePosition(this.ClientSize.Height, this.ClientSize.Width);
            }

            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            foreach (var snowflake in snowflakes)
            {
                snowflake.DrawSnowflake(g, step);
            }

            step += 5;
        }
        private void GenerateSnowflakes()
        {
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(0, this.ClientSize.Width);
                int y = random.Next(-200, this.ClientSize.Height);
                int size = random.Next(5, 30);
                int speed = random.Next(2, 8);
                snowflakes.Add(new Snowflake(x, y, size, speed));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bag_Form bag_Form = new Bag_Form(dictionary_characters,dictionary_things);
            bag_Form.ShowDialog();
            timer1.Stop();
        }
    }
}
