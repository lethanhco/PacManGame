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
        int score, playerSpeed, redGhostSpeed, blueGhostSpeed, yellowGhostX, yellowGhostY;

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
            }
        }


        private void mainGameTime(object sender, EventArgs e)
        {
            labelScore.Text = "Diem " + score;

            if (goleft == true)
            {
                pacman.Left -= playerSpeed;
                pacman.Image = Properties.Resources.ghost_red1;
            }
            if (goright == true)
            {
                pacman.Left += playerSpeed;
                pacman.Image = Properties.Resources.ghost_blue;
            }
            if (godown == true)
            {
                pacman.Top += playerSpeed;
                pacman.Image = Properties.Resources.ghost_green;
            }
            if (goup == true)
            {
                pacman.Top -= playerSpeed;
                pacman.Image = Properties.Resources.ghost_yellow;
            }


            if (pacman.Left < -10)
            {
                pacman.Left = 910;
            }
            if (pacman.Left > 910)
            {
                pacman.Left = -10;
            }


            if (pacman.Top < -10)
            {
                pacman.Top = 610;
            }
            if (pacman.Top > 610)
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
                   if((string)x.Tag == "wall")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("ban da cham tuong");
                        }
                    }
                    if ((string)x.Tag == "ghot")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("ban da thua");
                        }
                    }

                }
            }
            redGhost.Top += redGhostSpeed;

            if (redGhost.Bounds.IntersectsWith(wall2.Bounds) || redGhost.Bounds.IntersectsWith(wall4.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }
            if (score == 5)
            {
                gameOver("ban da chien thang");
            }


        }

        private void resetGame()
        {
            labelScore.Text = "Diem: 0";
            score = 0;

            playerSpeed = 8;

            redGhostSpeed = 5;
            blueGhostSpeed = 5;
            yellowGhostX = 5;
            yellowGhostY = 5;

            isGameOver = false;

            pacman.Left = 12;
            pacman.Top = 200;

            redGhost.Left = 418;
            redGhost.Top = 250;

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
            labelScore.Text ="Diem" + score + Environment.NewLine + message;
        }
    }
}
