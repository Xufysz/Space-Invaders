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

        private Graphics spaceInvanders;

        private Canon playerIcon;

        private List<Alien> aliens;

        private List<Bullet> bullets;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.initGame();
        }

        private void initGame()
        {
            this.playerIcon = new Canon(25, 15, (this.picCanvas.Width / 2), (this.picCanvas.Height - 25));
            this.aliens = new List<Alien>();
            this.bullets = new List<Bullet>();

            // Create multiple array lists that represent the waves of aliens that come towards the player:

            int currentY = 0;
            for (int i = 0; i < 8; i++) //Y
            {
                int offsetX = this.picCanvas.Width / 12;
                for (int j = 0; j < 8; j++) //X
                {
                    this.aliens.Add(new Alien(25, 50, offsetX += 100, currentY));
                }
                currentY += 50;
            }

            // Set up timer to control game:
            Timer timer = new Timer() { Interval = 10 };
            timer.Tick += timer_Tick;
            timer.Start();

            //List<Alien> row1 = new List<Alien>();

            //for (int i = 0; i < 8; i++)
            //{
            //    row1.Add(new Alien(25, 50, offsetX, 0));
            //    offsetX += 100;
            //}

            //this.aliens.Add(row1);

            //offsetX = this.picCanvas.Width / 12;

            //List<Alien> row2 = new List<Alien>();

            //for (int i = 0; i < 8; i++)
            //{
            //    row2.Add(new Alien(25, 50, offsetX, 50));
            //    offsetX += 100;
            //}

            //Aliens.Add(row2);

            //offsetX = this.picCanvas.Width / 12;

            //List<Alien> row3 = new List<Alien>();

            //for (int i = 0; i < 8; i++)
            //{
            //    row3.Add(new Alien(25, 50, offsetX, 100));
            //    offsetX += 100;
            //}

            //Aliens.Add(row3);

            //offsetX = this.picCanvas.Width / 12;

            //List<Alien> row4 = new List<Alien>();

            //for (int i = 0; i < 8; i++)
            //{
            //    row4.Add(new Alien(25, 50, offsetX, 150));
            //    offsetX += 100;
            //}

            //Aliens.Add(row4);
        }

        // Method used to organize the X and Y location of the aliens:

        private void setFormation(Alien row)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            draw();
        }

        private void draw()
        {
            // Set up canvas:
            using (this.spaceInvanders = this.picCanvas.CreateGraphics())
            {
                spaceInvanders.Clear(Color.Black);

                // Draw player icon (canon):
                spaceInvanders.FillRectangle(Brushes.White, playerIcon.getPosX(), playerIcon.getPosY(), playerIcon.getWidth(), playerIcon.getHeight());

                for (int i = 0; i < this.aliens.Count; i++)
                {
                    Alien alien = this.aliens[i];
                    this.spaceInvanders.FillRectangle(Brushes.Green, Convert.ToSingle(alien.getPosX()), Convert.ToSingle(alien.getPosY()), alien.getWidth(), alien.getHeight());
                    alien.move();
                }

                for (int i = 0; i < this.bullets.Count; i++)
                {
                    // Draw bullets:
                    spaceInvanders.FillRectangle(Brushes.White, this.bullets[i].getPosX(), this.bullets[i].getPosY(), this.bullets[i].getWidth(), this.bullets[i].getHeight());

                    // Enable bullet behaviours:
                    this.bullets[i].move();
                }

                //for (int i = 0; i < Aliens[0].Count; i++)
                //{
                //    spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[0][i].getPosX()), Convert.ToSingle(Aliens[0][i].getPosY()), Aliens[0][i].getWidth(), Aliens[0][i].getHeight());

                //    // Enable behaviours:

                //    Aliens[0][i].move();

                //    if (Aliens[0][i].reachBottom(this.picCanvas.Height))
                //    {

                //    }
                //}

                //for (int i = 0; i < Aliens[1].Count; i++)
                //{
                //    spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[1][i].getPosX()), Convert.ToSingle(Aliens[1][i].getPosY()), Aliens[1][i].getWidth(), Aliens[1][i].getHeight());

                //    // Enable behaviours:

                //    Aliens[1][i].move();

                //    if (Aliens[1][i].reachBottom(this.picCanvas.Height))
                //    {

                //    }
                //}

                //for (int i = 0; i < Aliens[2].Count; i++)
                //{
                //    spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[2][i].getPosX()), Convert.ToSingle(Aliens[2][i].getPosY()), Aliens[2][i].getWidth(), Aliens[2][i].getHeight());

                //    // Enable behaviours:

                //    Aliens[2][i].move();

                //    if (Aliens[2][i].reachBottom(this.picCanvas.Height))
                //    {

                //    }
                //}

                //for (int i = 0; i < Aliens[3].Count; i++)
                //{
                //    spaceInvanders.FillRectangle(alienBrush, Convert.ToSingle(Aliens[3][i].getPosX()), Convert.ToSingle(Aliens[3][i].getPosY()), Aliens[3][i].getWidth(), Aliens[3][i].getHeight());

                //    // Enable behaviours:

                //    Aliens[3][i].move();

                //    if (Aliens[3][i].reachBottom(this.picCanvas.Height))
                //    {

                //    }
                //}
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
                this.bullets.Add(new Bullet(20, 3, playerIcon.getPosX() + 5, playerIcon.getPosY(), playerIcon.getDamageDealt()));
            }
        }
    }
}
