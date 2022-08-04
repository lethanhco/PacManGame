using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    public partial class Form1 : Form
    {


        bool goup, godown, goleft, goright, isGameOver;
        int score, playerSpeed, redGhostSpeed, blueGhostSpeed, yellowGhostSpeed, pinkGhostSpeed;

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {

        }

        private void YellowGhost_Click(object sender, EventArgs e)
        {

        }


        private void showGScreen(object sender, FormClosedEventArgs e)
        {
            GScreen showMenu = new GScreen();
            showMenu.Show();
        }

        //private void loadGScreen(object sender, FormClosedEventArgs e)
        //{
        // GScreen mainMenu = new GScreen();

        //mainMenu.Show();


        //}

        private void labelScore_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();

            resetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
                lableWin.Text = "";
            }
        }


        private void mainGameTime(object sender, EventArgs e)
        {
            labelScore.Text = "Diem " + score;

            if (goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.pacman5; // pacman qua phai     //Import ảnh trước khi chọn Resources
            }
            if (goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.pacman5; // pacman qua trái  // lỗi 
            }
            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.pacman5;   //pacman xuống dưới
            }
            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.pacman5;   //pacman lên trên
            }


            if (pacman.Left < -10)
            {
                pacman.Left = 830;
            }
            if (pacman.Left > 830)
            {
                pacman.Left = -10;
            }


            if (pacman.Top < -10)
            {
                pacman.Top = 600;
            }
            if (pacman.Top > 600)
            {
                pacman.Top = -10;
            }


            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                   if ((string)x.Tag == "coin" && x.Visible == true)
                   {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                   }
                    if ((string)x.Tag == "Food" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 5;
                            x.Visible = false;
                        }
                    }
                    if ((string)x.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Game Over");
                        }
                    }
                    if ((string)x.Tag == "ghot")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("Game Over");
                        }
                    }

                }
            }
            redGhost.Left += redGhostSpeed;
            buleGhost.Left += blueGhostSpeed;
            YellowGhost.Top += yellowGhostSpeed;
            PinkGhost.Top += pinkGhostSpeed;

            if (redGhost.Bounds.IntersectsWith(wall5.Bounds) || redGhost.Bounds.IntersectsWith(wall6.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }
            if (buleGhost.Bounds.IntersectsWith(wall7.Bounds) || buleGhost.Bounds.IntersectsWith(wall8.Bounds))
            {
                blueGhostSpeed = -blueGhostSpeed;
            }
            if (YellowGhost.Bounds.IntersectsWith(wall9.Bounds) || YellowGhost.Bounds.IntersectsWith(wall10.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }
            if (PinkGhost.Bounds.IntersectsWith(wall11.Bounds) || PinkGhost.Bounds.IntersectsWith(wall12.Bounds))
            {
                pinkGhostSpeed = -pinkGhostSpeed;
            }
            if (score == 50)
            {
                gameOver("OK. Bạn là nhất...:)))");
            }


        }

        private void resetGame()
        {
            labelScore.Text = "Diem: 0";
            score = 0;

            playerSpeed = 5;

            redGhostSpeed = 2;
            blueGhostSpeed = 2;
            yellowGhostSpeed = 2;
            pinkGhostSpeed = 2;

            isGameOver = false;

            pacman.Left = 238;
            pacman.Top = 210;

            redGhost.Left = 600;
            redGhost.Top = 200;

            buleGhost.Left = 200;
            buleGhost.Top = 300;

            YellowGhost.Left = 100;
            YellowGhost.Top = 20;

            PinkGhost.Left = 700;
            PinkGhost.Top = 400;

            TimeGame.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

        }

        private void gameOver(string message)
        {
            isGameOver = true;

            TimeGame.Stop();
            lableWin.Text = message;
        }
    }
}
