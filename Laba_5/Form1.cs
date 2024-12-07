using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Laba_5
{
    public partial class Form1 : Form
    {
        private Abstract_Figure currentFigure;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Circle circle = new Circle(30, 30, 30);
            await DrawNewFigureAsync(circle);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Square square = new Square(140, 140, 30);
            await DrawNewFigureAsync(square);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Rhomb rhomb = new Rhomb(90, 60,250, 250);
            await DrawNewFigureAsync(rhomb);
        }
        private async Task DrawNewFigureAsync(Abstract_Figure newFigure)
        {
            currentFigure?.HideDrawingBackGround();
            currentFigure = newFigure;

            await currentFigure.MoveRight();
        }
    }
}
