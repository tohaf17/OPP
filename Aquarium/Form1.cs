using System;

namespace Aquarium
{
    public partial class Form1 : Form
    {
        private List<Bubble> bubbles=new List<Bubble>();
        private Random random = new Random();
        private int step = 0;
        private Herbivore herbivore;
        private Carnivorous carnivorous;

        public Form1()
        {
            InitializeComponent();

            timer1.Start();
            GenerateBubbles();
            this.BackColor = Color.CornflowerBlue;
            this.DoubleBuffered = true;
            herbivore = new Herbivore(this,random);
            carnivorous=new Carnivorous(this,random);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var bubble in bubbles)
            {
                bubble.UpdatePosition(this.ClientSize.Height, this.ClientSize.Width);
            }
            herbivore.Move();
            carnivorous.Move();
            carnivorous.Cross(herbivore.Fish_and_Speed);
            step += 5;
            this.Invalidate();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clear(this.BackColor);
            foreach (var bubble in bubbles)
            {
                bubble.DrawBubble(g, step);
            }
            herbivore.Draw(g);carnivorous.Draw(g);

        }
        private void GenerateBubbles()
        {
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(0, this.ClientSize.Width);
                int y = random.Next(0, this.ClientSize.Height);
                int size = random.Next(5, 30);
                int speed = random.Next(2, 8);
                bubbles.Add(new Bubble(x, y, size, speed));
            }
        }
    }
}
