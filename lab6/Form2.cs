using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form2 : Form
    {
        private Form1 form1;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int czasOdmierzania;
        private void Timer_Tick(object sender, EventArgs e)
        {
            czasOdmierzania--;

            label2.Text = czasOdmierzania.ToString() + " s";

            if (czasOdmierzania <= 0)
            {
                timer.Stop();

                label1.Text = "PRZEGRAŁEŚ :( czas się skończył";
            }
        }

        private PictureBox[] pictureboxes;
        private List<PictureBox> in_game = new List<PictureBox>();
        private List<PictureBox> nothing = new List<PictureBox>();
        private List<PictureBox> dydelfs = new List<PictureBox>();
        private List<PictureBox> crocodiles = new List<PictureBox>();

        private int found_dydelfs;
        private bool end_game;
        private void PictureBox_Click_Nothing(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            LoadImage(empty, picturebox);
        }
        private void PictureBox_Click_Dydelf(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            LoadImage(dydelf, picturebox);
            found_dydelfs++;
            if(found_dydelfs == form1.dydelfy && !end_game)
            {
                end_game = true;
                label1.Text = "WYGRAŁEŚ!!!";
                timer.Stop();
                foreach (PictureBox picture in nothing)
                {
                    PictureBox_Click_Nothing(picture, EventArgs.Empty);
                }
                foreach(PictureBox picture in crocodiles)
                {
                    PictureBox_Click_Crocodile(picture, EventArgs.Empty);
                }
            }
        }
        private void PictureBox_Click_Crocodile(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            LoadImage(crocodile, picturebox);
            if (!end_game)
            {
                end_game = true;
                label1.Text = "PRZEGRAŁEŚ :(";
                timer.Stop();
                foreach (PictureBox picture in nothing)
                {
                    PictureBox_Click_Nothing(picture, EventArgs.Empty);
                }
                foreach (PictureBox picture in dydelfs)
                {
                    PictureBox_Click_Dydelf(picture, EventArgs.Empty);
                }
            }

        }

        public Form2(Form1 form1)
        {
            InitializeComponent();

            czasOdmierzania = form1.czas;
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick; 

            timer.Start();

            this.form1 = form1;
            pictureboxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24, pictureBox25, pictureBox26, pictureBox27, pictureBox28, pictureBox29, pictureBox30, pictureBox31, pictureBox32, pictureBox33, pictureBox34, pictureBox35, pictureBox36, pictureBox37, pictureBox38, pictureBox39, pictureBox40, pictureBox41, pictureBox42, pictureBox43, pictureBox44, pictureBox45, pictureBox46, pictureBox47, pictureBox48, pictureBox49, pictureBox50, pictureBox51, pictureBox52, pictureBox53, pictureBox54, pictureBox55, pictureBox56, pictureBox57, pictureBox58, pictureBox59, pictureBox60, pictureBox61, pictureBox62, pictureBox63, pictureBox64, pictureBox65, pictureBox66, pictureBox67, pictureBox68, pictureBox69, pictureBox70, pictureBox71, pictureBox72, pictureBox73, pictureBox74, pictureBox75, pictureBox76, pictureBox77, pictureBox78, pictureBox79, pictureBox80, pictureBox81, pictureBox82, pictureBox83, pictureBox84, pictureBox85, pictureBox86, pictureBox87, pictureBox88, pictureBox89, pictureBox90, pictureBox91, pictureBox92, pictureBox93, pictureBox94, pictureBox95, pictureBox96, pictureBox97, pictureBox98, pictureBox99, pictureBox100 };

            for (int i = 0; i < form1.Y * 10; i = i + 10)
            {
                for (int j = 0; j < form1.X; j++)
                {
                    LoadImage(bin, pictureboxes[i + j]);
                    in_game.Add(pictureboxes[i + j]);
                }
            }
            nothing = in_game;
            for (int i = 0; i < form1.dydelfy; i++)
            {
                Random rand = new Random();
                int random = rand.Next(0, in_game.Count);
                dydelfs.Add(in_game[random]);
                in_game.RemoveAt(random);
            }
            for (int i = 0; i < form1.krokodyle; i++)
            {
                Random rand = new Random();
                int random = rand.Next(0, in_game.Count);
                crocodiles.Add(in_game[random]);
                in_game.RemoveAt(random);
            }

            found_dydelfs = 0;
            end_game = false;

            foreach (PictureBox pictureBox in nothing)
            {
                pictureBox.Click += new EventHandler(PictureBox_Click_Nothing);
            }
            foreach (PictureBox pictureBox in dydelfs)
            {
                pictureBox.Click += new EventHandler(PictureBox_Click_Dydelf);
            }
            foreach (PictureBox pictureBox in crocodiles)
            {
                pictureBox.Click += new EventHandler(PictureBox_Click_Crocodile);
            }
        }

        public static void LoadImage(string imagePath, PictureBox pictureBox)
        {
            try
            {
                var image = System.Drawing.Image.FromFile(imagePath);

                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                pictureBox.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania obrazu: " + ex.Message);
            }
        }

        string bin = "C:\\Users\\Pedzi\\OneDrive\\Pulpit\\śmietnik.jpg";
        string dydelf = "C:\\Users\\Pedzi\\OneDrive\\Pulpit\\opos.jpg";
        string crocodile = "C:\\Users\\Pedzi\\OneDrive\\Pulpit\\krokodyl.jpg";
        string empty = "C:\\Users\\Pedzi\\OneDrive\\Pulpit\\pusty.png";

    }
}
