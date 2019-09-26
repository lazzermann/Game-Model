using System;

namespace GameModel
{
    class Player
    {
        //Action constants to avoid the appearance of magic numbers
        const int punchAction = 1;
        const int forcePunchAction = 2;
        const int healAction = 3;

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

        //Taking damage from an another player
        public void getDamage(int DamagePoints) {
            this.CurrentHealth -= DamagePoints;
        }

        //Health getter
        public int getHealth() {
            return this.CurrentHealth;
        }

        //Name getter
        public String getName() {
            return this.Name;
        }

        //Attack with middle damage range
        public int Punch() {
            Random damagePoints = new Random();

            //Minimum and maximum damage in percents from this attack
            max = (Convert.ToDouble(maxHealth) / 100) * 25;
            min = (Convert.ToDouble(maxHealth) / 100) * 20;

            return damagePoints.Next((int)min, (int)max);
        }

        //Attack with high damage range
        public int forcePunch() {
            Random damagePoints = new Random();

            //Minimum and maximum damage in percents from this attack
            max = (Convert.ToDouble(maxHealth) / 100) * 35;
            min = (Convert.ToDouble(maxHealth) / 100) * 10;

            return damagePoints.Next((int)min, (int)max);
        }

        //Healing
        public void Heal()
        {
            Random healPoints = new Random();

            //Minimum and maximum percent of heal from healing
            max = (Convert.ToDouble(maxHealth) / 100) * 25;
            min = (Convert.ToDouble(maxHealth) / 100) * 20;

            this.CurrentHealth += healPoints.Next((int)min, (int)max);
            if (CurrentHealth > maxHealth)
                CurrentHealth = maxHealth;
        }

        bool isCriticalHealthState() {
            double res = ((Convert.ToDouble(maxHealth) / 100) *30);
            if (res >= CurrentHealth)   
                return true; //If percent of current health low than 30

            return false;
        }

        public int chooseAction() {

            //Random the following action
            Random actionRandomizer = new Random();
            int actionRandomizerBuffer = actionRandomizer.Next(1, 11);

            //Increase chance of healing on 50%
            if (isCriticalHealthState()) {
                if (actionRandomizerBuffer >= 3 && actionRandomizerBuffer < 5) { return punchAction; }//Return action - Punch
                if (actionRandomizerBuffer >= 5) { return healAction; }//Return action - Heal
                return forcePunchAction; //Return action - Force punch
            }

            if (actionRandomizerBuffer <= 4) { return punchAction; }//Return action - Punch
            if (actionRandomizerBuffer > 4 && actionRandomizerBuffer <= 7) { return forcePunchAction; }//Return action - Force punch
            return healAction; //Return action - Heal
        }
    }
}
