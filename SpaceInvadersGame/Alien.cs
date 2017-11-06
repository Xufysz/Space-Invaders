using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersGame
{
    public class Alien
    {
        private int height;
        private int width;

        private double positionX;
        private double positionY;

        private int damageDealt = 25;
        private int health = 100;

        // Constructor:

        public Alien(int h, int w, double posX, double posY)
        {
            this.height = h;
            this.width = w;

            this.positionX = posX;
            this.positionY = posY;
        }

        // Getter methods:

        public int getHeight()
        {
            return this.height;
        }

        public int getWidth()
        {
            return this.width;
        }

        public double getPosX()
        {
            return this.positionX;
        }

        public double getPosY()
        {
            return this.positionY;
        }

        public int getDamageDealth()
        {
            return this.damageDealt;
        }

        public int getHealth()
        {
            return this.health;
        }

        // Behavioural methods:

        public void move()
        {
            this.positionY += 0.75;
        }

        public void shoot()
        {

        }

        public void dead()
        {

        }

        public void reachBottom(int bottomOfScreen)
        {

        }
    }
}
