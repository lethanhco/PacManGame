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
    public partial class GScreen : Form
    {
        public GScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {
  
            Form1 gameWindow = new Form1();
            
            gameWindow.Show();
            this.Hide();
            
              
        }

        private void LoadHelp(object sender, EventArgs e)
        {
            HelpScreen helpWindow = new HelpScreen();

            helpWindow.Show();
        }

        private void xistScrn(object sender, FormClosingEventArgs e)
        {
            GScreen closeScrn = new GScreen();

            closeScrn.Close();

        }


    }
}
