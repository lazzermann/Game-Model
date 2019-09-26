using System;

namespace GameModel
{
    class Player
    {
        private int CurrentHealth { get; set; }

        private int maxHealth { get; set; }
        private String Name { get; set; }

        private double max;
        private double min;

        public Player(String Name, int Health) {
            this.Name = Name;
            this.maxHealth = Health;
            this.CurrentHealth = Health;
        }

        public void Heal() {
            Random healPoints = new Random();
            max = (Convert.ToDouble(maxHealth) / 100) * 25;
            min = (Convert.ToDouble(maxHealth) / 100) * 20;

            this.CurrentHealth += healPoints.Next((int)min,(int)max);
            if (CurrentHealth > maxHealth)
                CurrentHealth = maxHealth;
        }

        public void getDamage(int DamagePoints) {
            this.CurrentHealth -= DamagePoints;
        }

        public int getHealth() {
            return this.CurrentHealth;
        }

        public String getName() {
            return this.Name;
        }

        public int Punch() {
            Random damagePoints = new Random();
            max = (Convert.ToDouble(maxHealth) / 100) * 25;
            min = (Convert.ToDouble(maxHealth) / 100) * 20;

            return damagePoints.Next((int)min, (int)max);
        }

        public int forcePunch() {
            Random damagePoints = new Random();
            max = (Convert.ToDouble(maxHealth) / 100) * 35;
            min = (Convert.ToDouble(maxHealth) / 100) * 10;

            return damagePoints.Next((int)min, (int)max);
        }

        bool isCriticalHealthState() {
            double res = ((Convert.ToDouble(maxHealth) / 100) *30);
            if (res >= CurrentHealth)
                return true;

            return false;
        }

        public int chooseAction() {

            Random actionRandomizer = new Random();
            int actionRandomizerBuffer = actionRandomizer.Next(1, 11);

            if (isCriticalHealthState()) {
                if (actionRandomizerBuffer >= 3 && actionRandomizerBuffer < 5) { return 1; }//Return action - Punch
                if (actionRandomizerBuffer >= 5) { return 3; }//Return action - Heal
                return 2; //Return action - Force punch
            }

            if (actionRandomizerBuffer <= 4) { return 1; }//Return action - Punch
            if (actionRandomizerBuffer > 4 && actionRandomizerBuffer <= 7) { return 2; }//Return action - Force punch
            return 3; //Return action - Heal
        }
    }
}
