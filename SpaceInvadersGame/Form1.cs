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

        Canon playerIcon;

        List<Alien> Aliens = new List<Alien>();

        private void Form1_Load(object sender, EventArgs e)
        {
            playerIcon = new Canon(25, 15, (this.picCanvas.Width / 2), (this.picCanvas.Height - 25));

            for (int i = 0; i < 2; i++)
            {
                Aliens.Add(new Alien(25, 25, (this.picCanvas.Width / 2), 0));
            }

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

            for (int i = 0; i < Aliens.Count; i++)
            {
                // Draw aliens:

                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[i].getPosX()), Convert.ToSingle(Aliens[i].getPosY()), Aliens[i].getWidth(), Aliens[i].getHeight());

                // Enable alien behaviours:

                Aliens[i].move();
            }
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
