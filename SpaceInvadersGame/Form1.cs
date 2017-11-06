using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvadersGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.KeyDown += this.Form1_KeyDown;
        }

        Canon playerIcon = new Canon(25, 15, 450, 595);

        Alien alien = new Alien(30, 30, 0, 0);

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();

            timer.Interval = 10;

            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            draw();
        }

        private void draw()
        {
            // Set up canvas:

            Graphics spaceInvanders;

            spaceInvanders = this.picCanvas.CreateGraphics();

            spaceInvanders.Clear(Color.Black);

            // Draw player icon (canon):

            SolidBrush playerBrush = new SolidBrush(Color.White);

            spaceInvanders.FillRectangle(playerBrush, playerIcon.getPosX(), playerIcon.getPosY(), playerIcon.getWidth(), playerIcon.getHeight());

            // Draw aliens:

            SolidBrush alienBrush = new SolidBrush(Color.Green);

            spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(alien.getPosX()), Convert.ToSingle(alien.getPosY()), alien.getWidth(), alien.getHeight());

            // Allow aliens to move:

            alien.move();
        }

        // Method used to handle the movement of the canon:
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) // Move left
            {
                playerIcon.move(1, 0, this.picCanvas.Width);
            }
            else if (e.KeyCode == Keys.Right) // Move right
            {
                playerIcon.move(2, 0, this.picCanvas.Width);
            }
            else if (e.KeyCode == Keys.Up) // Fire weapon
            {
                
            }
        }
    }
}
