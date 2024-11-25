using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Laba_3_Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.BlueViolet;

            Color buttonBackground = Color.MediumSlateBlue; 
            Color buttonTextColor = Color.White;           

            Color listBoxBackground = Color.SlateBlue;      
            Color listBoxTextColor = Color.White;          

            Color pictureBoxBorder = Color.DarkSlateBlue;

            button1.BackColor = buttonBackground;
            button1.ForeColor = buttonTextColor;

            listBox1.BackColor = listBoxBackground;
            listBox1.ForeColor = listBoxTextColor;
            listBox1.BorderStyle = BorderStyle.FixedSingle; 

            listBox2.BackColor = listBoxBackground;
            listBox2.ForeColor = listBoxTextColor;
            listBox2.BorderStyle = BorderStyle.FixedSingle;

            pictureBox1.BackColor = Color.Transparent; 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D; 

            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            button2.BackColor = buttonBackground;
            button2.ForeColor = buttonTextColor;
        }

        private List<string> filePaths = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Text = "Images";
            listBox1.Visible = true;
            this.Controls.Add(listBox1);
            listBox1.Items.Clear();
            listBox1.BeginUpdate();
            string[] files = Directory.GetFiles("C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3_Task_2\\Images");

            Regex regexExtForImage = new Regex("^.((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);


            foreach (var image in files)
            {
                if (regexExtForImage.IsMatch(Path.GetExtension(image)))
                {
                    
                    listBox1.Items.Add(Path.GetFileName(image));
                    filePaths.Add(image); 
                }
            }
            listBox1.EndUpdate();


        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button1.Location = new Point((this.ClientSize.Width - button1.Width) / 2, (this.ClientSize.Height - button1.Height) / 2);

            pictureBox1.Location = new Point(listBox1.Location.X, listBox1.Location.Y + listBox1.Height + 20); // Adjust the spacing as needed
            pictureBox1.Size = new Size(listBox1.Width, listBox1.Height);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                string selectedFilePath = filePaths[listBox1.SelectedIndex];
                pictureBox1.Load(selectedFilePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Text = "New images";
            listBox2.Visible = true;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть файл зі списку.");
                return;
            }

            string selectedFilePath = filePaths[listBox1.SelectedIndex];
            string targetDirectory = "C:\\Users\\ADMIN\\Documents\\GitHub\\OPP\\Laba_3_Task_2\\New_images";

            try
            {
                
                Bitmap bitmap = new Bitmap(selectedFilePath);
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);//choise??????
                string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
                string newFileName = fileName + ".gif";
                string filePathInDirectory = Path.Combine(targetDirectory, newFileName);
                bitmap.Save(filePathInDirectory, ImageFormat.Gif);
                listBox2.Items.Add(newFileName);
                pictureBox2.Visible = true;
                pictureBox2.Load(filePathInDirectory);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show($"Файл успішно збережено як {newFileName}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при обробці файлу: {ex.Message}");
            }


        }
    }
}