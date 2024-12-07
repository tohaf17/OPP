namespace Garland
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
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            garland.OptionQuickly(g, j);
            j++;
            g.Dispose();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            Graphics f = this.CreateGraphics();
            f.Clear(Color.White);
            garland.OptionSlowly(f, j);
            j++;
            f.Dispose();
        }
    }
}
