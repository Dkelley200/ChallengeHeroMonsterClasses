using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClasses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Character Hero = new Character();

            Hero.Name = "SuperGuy";
            Hero.Health = 30;
            Hero.DamageMaximum = 15;
            Hero.AttackBonus = true;


            Character Monster = new Character();

            Monster.Name = "BadGuy";
            Monster.Health = 20;
            Monster.DamageMaximum = 10;
            Monster.AttackBonus = false;

            Dice dice = new Dice();

            // calculate attack bonus and health level
            if (Hero.AttackBonus)
                Monster.Defend(Hero.Attack(dice));
            // monster attack bonus == false
            // no bonus logic needed.show for instruction criteria only 
            // we need to add a value to the Attack Bonus
            

            if  (Monster.AttackBonus)
                Hero.Defend(Monster.Attack(dice));




            while (Hero.Health > 0 && Monster.Health > 0)
			{
            //hero attack
			
            Hero.Defend(Monster.Attack(dice));
           

            //monster attack

            Monster.Defend(Hero.Attack(dice));
           
            //print results for both
			   // resultlLabel.Text += string.Format(" Monster  {0} and Hero  {1}", Hero, Monster);

                printstatus(Hero);
                printstatus(Monster);
            }

           displayresults(Hero, Monster);
        }

        private void printstatus(Character character)
        {
            resultlLabel.Text += string.Format("<p>Name:{0},  Health: {1} , DamageMaximum: {2}, AttackBonus :{3} <p/>" ,
            character.Name, character.Health, character.DamageMaximum, character.AttackBonus);

        }

        private void displayresults(Character opponent1, Character opponent2)
        // must call as opponent 1 and opponent 2
        {
            if (opponent1.Health > 0 && opponent2.Health <= 0)
            {
                resultlLabel.Text += string.Format("<p>{0} defeated {1}<p/>", opponent1.Name, opponent2.Name);
            }
            else if (opponent1.Health < 0 && opponent2.Health > 0)
            {
                resultlLabel.Text += string.Format("<p>{0} defeated {1}<p/>", opponent2.Name, opponent1.Name);
            }
            else
            {
                resultlLabel.Text += string.Format("<p> Amazing Battle! {0} and {1} both died<p/>" ,opponent1.Name, opponent2.Name);
            }
        }




        public class Character
        {
            

            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public bool AttackBonus { get; set; }

            public int Attack(Dice dice)
            {
                //Random random = new Random();
                //int damage = random.Next(1, DamageMaximum);
                //return damage;

                dice.sides = this.DamageMaximum;
                return dice.Roll();

            }

            public void Defend(int damage)
            {
                Health -= damage;
            }
            
        }
        public class Dice
        {
            public int sides { get; set; }
            Random random = new Random();
            public int Roll()
            {
                return random.Next(sides);
            }
        }

    }

    
}
