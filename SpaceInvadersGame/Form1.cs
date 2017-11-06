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

        Graphics spaceInvanders;

        Canon playerIcon;

        List<List<Alien>> Aliens = new List<List<Alien>>();

        List<Bullet> Bullets = new List<Bullet>();

        private void Form1_Load(object sender, EventArgs e)
        {
            playerIcon = new Canon(25, 15, (this.picCanvas.Width / 2), (this.picCanvas.Height - 25));

           // Create multiple array lists that represent the waves of aliens that come towards the player:

            List<Alien> row1 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row1.Add(new Alien(25, 50, (this.picCanvas.Width / 2), 0));
            }

            Aliens.Add(row1);

            List<Alien> row2 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row2.Add(new Alien(25, 50, (this.picCanvas.Width / 2), 50));
            }

            Aliens.Add(row2);

            List<Alien> row3 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row3.Add(new Alien(25, 50, (this.picCanvas.Width / 2), 100));
            }

            Aliens.Add(row3);

            List<Alien> row4 = new List<Alien>();

            for (int i = 0; i < 8; i++)
            {
                row4.Add(new Alien(25, 50, (this.picCanvas.Width / 2), 150));
            }

            Aliens.Add(row4);

            // Set up timer to control game:

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

            spaceInvanders = this.picCanvas.CreateGraphics();

            spaceInvanders.Clear(Color.Black);

            // Draw player icon (canon):

            SolidBrush playerBrush = new SolidBrush(Color.White);

            spaceInvanders.FillRectangle(playerBrush, playerIcon.getPosX(), playerIcon.getPosY(), playerIcon.getWidth(), playerIcon.getHeight());

            // Draw aliens in cube formation:

            SolidBrush alienBrush = new SolidBrush(Color.Green);

            for (int i = 0; i < Aliens[0].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[0][i].getPosX()), Convert.ToSingle(Aliens[0][i].getPosY()), Aliens[0][i].getWidth(), Aliens[0][i].getHeight());
            }

            for (int i = 0; i < Aliens[1].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[1][i].getPosX()), Convert.ToSingle(Aliens[1][i].getPosY()), Aliens[1][i].getWidth(), Aliens[1][i].getHeight());
            }

            for (int i = 0; i < Aliens[2].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[2][i].getPosX()), Convert.ToSingle(Aliens[2][i].getPosY()), Aliens[2][i].getWidth(), Aliens[2][i].getHeight());
            }

            for (int i = 0; i < Aliens[3].Count; i++)
            {
                spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[3][i].getPosX()), Convert.ToSingle(Aliens[3][i].getPosY()), Aliens[3][i].getWidth(), Aliens[3][i].getHeight());
            }

            // Draw bullets:

            SolidBrush bulletBrush = new SolidBrush(Color.White);

            for (int i = 0; i < Bullets.Count; i++)
            {
                // Draw bullets:

                spaceInvanders.FillRectangle(bulletBrush, Bullets[i].getPosX(), Bullets[i].getPosY(), Bullets[i].getWidth(), Bullets[i].getHeight());

                // Enable bullet behaviours:

                Bullets[i].move();
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
                Bullets.Add(new Bullet(20, 3, playerIcon.getPosX() + 5, playerIcon.getPosY(), playerIcon.getDamageDealt()));
            }
        }
    }
}
