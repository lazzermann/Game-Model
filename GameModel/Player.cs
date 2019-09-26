using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    class Player
    {
        private int Health { get; set; }
        private String Name { get; set; }

        public Player(String Name, int Health) {
            this.Name = Name;
            this.Health = Health;
        }

        public void Heal(int HealPoints) {
            this.Health += HealPoints;
        }

        public void getDamage(int DamagePoints) {
            this.Health -= DamagePoints;
        }

        public int getHealth() {
            return this.Health;
        }

        public String getName() {
            return this.Name;
        }

        public int Punch() {
            Random damagePoints = new Random();
            return Convert.ToInt32(damagePoints.Next(18, 25));
        }

        public int forcePunch() {
            Random damagePoints = new Random();
            return Convert.ToInt32(damagePoints.Next(10, 35));
        }
    
    }
}
