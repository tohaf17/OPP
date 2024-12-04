namespace Garland_1
{
    public partial class Form1 : Form
    {
        int j = 0;
        int k = 0;
        Garland garland;
        public Form1()
        {
            InitializeComponent();
            garland = new Garland();
            this.DoubleBuffered = true;
            this.MouseDown += Form1_MouseDown;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int index = garland.GetCircleIndex(e.X, e.Y);

            if (index != -1)
            {
                if (garland.IsOff(index)) 
                {
                    garland.On(index);
                }
                else 
                {
                    garland.Off(index);
                }

                this.Invalidate(); 
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Interval = 50;
            timer1.Start();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void slow_button_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
            timer1.Interval = 400;
        }

        private void centered_button_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Interval = 90;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            j++;
            this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            k++;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (timer1.Enabled)
            {
                garland.OptionQuickly(e.Graphics, j);
            }
            else if (timer2.Enabled)
            {
                garland.OptionSlowly(e.Graphics, k);
            }
        }
    }
}
