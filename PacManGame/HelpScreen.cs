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
    public partial class HelpScreen : Form
    {
        private Label label1;

        public HelpScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 273);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sử dụng các phím mũi tên để di chuyển.\r\nChạm vào tường hoặc con ma sẽ game over :" +
    "))\r\nNhấn Enter để reset màn.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // HelpScreen
            // 
            this.ClientSize = new System.Drawing.Size(473, 302);
            this.Controls.Add(this.label1);
            this.Name = "HelpScreen";
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
