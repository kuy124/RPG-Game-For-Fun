using System;
using System.Windows.Forms;

namespace Gametesting
{
    public partial class Form1 : Form
    {
        int a = 1;
        // Stats
        // Health
        double Health = 100;
        double HealthMax = 100;
        // Mana
        double Mana = 0;
        double ManaMax = 0;
        // Stamina
        double Stamina = 100;
        double StaminaMax = 100;
        // Damage
        double damage = 10;
        // Money
        double Money = 99;
        // Equipment
        double Sword = 1;
        double Armor = 1;
        string Swordd = "Wooden Sword";
        string Armorr = "Nothing";
        // Equipment Prices
        double SwordPrice = 1000;
        double ArmorPrice = 1000;
        // Name
        string name = "";
        int nameentered = 0;
        //Time Left
        double hours = 1000;
        // enemies
        // Bandits
        int loot = 5;
        int Banditlive = 1;
        double Bandits = 150;
        double BanditsMax = 150;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flpStore.Visible = false;
            lblDebug.Visible = false;
            Next();
            UI();
            MessageBox.Show("You have 1000 hours left to live! Make as much money as you can");
        }

        private void UI()
        {
            // Essential
            lblName.Text = "Name : " + name;
            lblHealth.Text = "Health : " + Health + "/" + HealthMax;
            lblMana.Text = "Mana : " + Mana + "/" + ManaMax;
            lblStamina.Text = "Stamina : " + Stamina + "/" + StaminaMax;
            lblCurrency1.Text = "Money : " + Money;

            //Time Left
            lblHoursLeft.Text = "Hours left to live : " + hours.ToString() + " Hours";

            // Equipment Prices
            lblSSword.Text = "Better Sword";
            btnBuySword.Text = "Buy For " + SwordPrice;
            lblSArmor.Text = "Better Armor";
            btnBuyArmor.Text = "Buy For " + ArmorPrice;

            // Update Sword and Armor labels based on their levels
            if (Sword == 1)
            {
                Swordd = "Wooden Sword";
            }
            if (Sword == 2)
            {
                Swordd = "Iron Sword";
            }
            if (Sword == 3)
            {
                Swordd = "Steel Sword";
            }
            if (Sword == 4)
            {
                Swordd = "Sharp Steel Sword";
            }

            if (Armor == 1)
            {
                Armorr = "Nothing";
                HealthMax = 100;
            }
            if (Armor == 2)
            {
                Armorr = "Leather";
                HealthMax = 200;
            }
            if (Armor == 3)
            {
                Armorr = "Chainmail";
                HealthMax = 300;
            }
            if(Armor == 4)
            {
                Armorr = "Iron";
                HealthMax = 450;
            }

            // Equipment
            lblSword.Text = "Sword : " + Swordd;
            lblArmor.Text = "Armor : " + Armorr;

            // IFS
            if (Health <= 0)
            {
                MessageBox.Show("You died! Your networth is " + Money.ToString());
                Application.Exit();
            }
            if (Stamina > StaminaMax)
            {
                Stamina = StaminaMax;
                UI();
            }
            if (Health > HealthMax)
            {
                Health = HealthMax;
                UI();
            }
            if (Mana > ManaMax)
            {
                Mana = ManaMax;
                UI();
            }

            // Bandit
            if (Bandits <= 0)
            {
                Banditlive = 0;
            }
        }

        private void Next()
        {
            lblDebug.Text = a.ToString();
            if (nameentered == 1)
            {
                if (a == 1)
                {
                    lblAdv.Text = "You are on the side of the street. What are you going to do?";
                    btnLeft.Text = "Sleep";
                    btnMiddle.Text = "Go to the shop";
                    btnRight.Text = "Travel around";
                    flpStore.Visible = false;
                }
                else if (a == 2)
                {
                    lblAdv.Text = "You look around the village to find some work to do.";
                    btnLeft.Text = "Search for dropped coins";
                    btnMiddle.Text = "Go back to the village";
                    btnRight.Text = "Go outside of the village";
                    flpStore.Visible = false;
                }
                else if (a == 3)
                {
                    lblAdv.Text = "You go outside from the village and see a couple of bandits";
                    btnLeft.Text = "Work with them";
                    btnMiddle.Text = "Go back";
                    btnRight.Text = "Fight them with your " + Swordd;
                    if (Banditlive == 0)
                    {
                        lblAdv.Text = "You go outside of the village and see a couple of dead bandits you've killed earlier";
                        btnLeft.Text = "Loot the bodies";
                        btnMiddle.Text = "Go back";
                        btnRight.Text = "Go to the forest";
                    }
                }
                else if (a == 4)
                {
                    lblAdv.Text = "You are in the middle of a lush forest";
                    btnLeft.Text = "Go hunting";
                    btnMiddle.Text = "Go back";
                    btnRight.Text = "Go further";
                }
                else if (a == 99)
                {
                    lblAdv.Text = "You are inside the shop!";
                    btnLeft.Text = "";
                    btnMiddle.Text = "Leave the shop";
                    btnRight.Text = "";
                    flpStore.Visible = true;
                }
                else
                {
                    flpStore.Visible = false;
                }
            }
            else
            {
                lblAdv.Text = "Please enter your name first!";
                btnLeft.Text = "Please";
                btnMiddle.Text = "Please";
                btnRight.Text = "Please";
            }
        }


        private void btnLeft_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            if (nameentered == 1)
            {
                if (a == 1)
                {
                    if (Stamina < StaminaMax)
                    {
                        if (Money >= 25)
                        {
                            int randomslep = random.Next(1, 10);
                            if (randomslep > 1)
                            {
                                lblAdv.Text = "You Slept for " + randomslep.ToString() + " Hours for 25 Money";
                            }
                            else if (randomslep == 1)
                            {
                                lblAdv.Text = "You Slept for " + randomslep.ToString() + " Hour for 25 Money";
                            }
                            Money -= 25;
                            Stamina += 25;
                            Health += 10;
                            hours -= randomslep;
                            UI();
                        }
                        else
                        {
                            lblAdv.Text = "You don't have enough money! Come back when you have atleast 25 money!";
                        }
                    }
                    else
                    {
                        lblAdv.Text = "You are not tired!";
                    }
                }
                else if (a == 2)
                {
                    if (Stamina > 0)
                    {
                        int search = random.Next(0, 100);
                        int time = random.Next(2, 5);
                        lblAdv.Text = "You look for some dropped coins and found " + search.ToString() + " amount of money for " + time.ToString() + " Hours";
                        Money += search;
                        Stamina -= 25;
                        hours -= time;
                        UI();
                    }
                    else
                    {
                        lblAdv.Text = "You don't have enough energy! Go back to the village and sleep!";
                    }
                }
                else if (a == 3)
                {
                    int mug = random.Next(100, 1001);
                    int chance = random.Next(1, 10);
                    if (Stamina >= 25)
                    {
                        if (Banditlive == 1)
                        {
                            if (chance == 1)
                            {
                                Money += mug;
                                lblAdv.Text = "They trust you and let you mug someone. You get away with " + mug.ToString() + " amount of money";
                                Stamina -= 25;
                                UI();
                            }
                            else if (chance == 2)
                            {
                                Money -= mug;
                                lblAdv.Text = "They don't trust you and you get mugged instead. You lost " + mug.ToString() + " amount of money";
                                Stamina -= 25;
                                UI();
                            }
                            else
                            {
                                lblAdv.Text = "They tell you to piss off";
                                Stamina -= 25;
                                UI();
                            }
                        }
                        else if (Banditlive == 0)
                        {
                            if (loot > 0)
                            {
                                Money += mug;
                                lblAdv.Text = "You loot " + mug.ToString() + " amount of money from the bodies";
                                loot--;
                                Stamina -= 25;
                                UI();
                            }
                            else
                            {
                                lblAdv.Text = "There's no more loot!";
                            }
                        }
                    }
                    else
                    {
                        lblAdv.Text = "You don't have enough energy!";
                    }
                }
                else if (a == 4)
                {
                    int chance = random.Next(1, 11);
                    if (Sword >= 2)
                    {
                        if (Stamina > 0)
                        {
                            if (chance <= 5)
                            {
                                int animal = random.Next(1, 3);
                                int deer = random.Next(100, 500);
                                int wolf = random.Next(200, 1000);
                                int staminaup = random.Next(1, 101);
                                if (animal == 1)
                                {

                                    lblAdv.Text = "You successfully hunted a deer and sell the leather and meat. You got " + deer.ToString() + " amount of money based on the quality of the deer";
                                    Money += deer;
                                    Stamina -= 25;
                                    if (staminaup <= 25)
                                    {
                                        lblAdv.Text = "You successfully hunted a deer and sell the leather and meat. You got " + deer.ToString() + " amount of money based on the quality of the deer and your stamina went up by 25!";
                                        StaminaMax += 25;
                                    }
                                    UI();
                                }
                                else if (animal == 2)
                                {
                                    lblAdv.Text = "You successfully hunted a wolf and sell the fur and meat. You got " + wolf.ToString() + " amount of money based on the quality of the wolf";
                                    Money += wolf;
                                    Stamina -= 25;
                                    if (staminaup <= 25)
                                    {
                                        lblAdv.Text = "You successfully hunted a wolf and sell the leather and meat. You got " + deer.ToString() + " amount of money based on the quality of the wolf and your stamina went up by 25!";
                                        StaminaMax += 25;
                                    }
                                    UI();
                                }
                            }
                            else
                            {
                                lblAdv.Text = "You don't encounter any animals. Unlucky";
                                Stamina -= 25;
                                UI();
                            }
                        }
                        else
                        {
                            lblAdv.Text = "You don't have enough energy to hunt!";
                        }
                    }
                    else
                    {
                        lblAdv.Text = "You need an iron sword or better!";
                    }

                }
            }
            else
            {
                txtName.Focus();
            }
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
            if (nameentered == 1)
            {
                if (a == 1)
                {
                    a = 99;
                    Next();
                }
                else if (a == 2)
                {
                    a = 1;
                    Next();
                }
                else if (a == 3)
                {
                    a = 2;
                    Next();
                }
                else if (a == 4)
                {
                    a = 3;
                    Next();
                }
                else if (a == 99)
                {
                    a = 1;
                    Next();
                }
            }
            else
            {
                txtName.Focus();
            }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            Random bndtdmg = new Random();
            if (nameentered == 1)
            {
                if (a == 1)
                {
                    a++;
                    Next();
                }
                else if (a == 2)
                {
                    a++;
                    Next();
                }
                else if (a == 3)
                {
                    if (Banditlive == 1)
                    {
                        if (Stamina > 0)
                        {
                            int banditdamage = bndtdmg.Next(10, 25);
                            Bandits -= damage;
                            Health -= banditdamage;
                            Stamina -= 10;
                            lblAdv.Text = "The bandit has " + Bandits.ToString() + " out of " + BanditsMax.ToString() + " health points. While you are doing " + damage.ToString() + " damage to them, They did " + banditdamage.ToString() + " damage to you";
                            UI();
                            if (Bandits <= 0)
                            {
                                Next();
                                lblAdv.Text = "You have killed the bandits";
                            }
                        }
                        else
                        {
                            lblAdv.Text = "You don't have enough stamina! Run back to the village now!";
                        }
                    }
                    else if (Banditlive == 0)
                    {
                        a++;
                        Next();
                    }
                }
            }
            else
            {
                txtName.Focus();
            }
        }

        private void btnSetname_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                name = txtName.Text;
                txtName.Visible = false;
                btnSetname.Visible = false;
                nameentered = 1;
                Next();
                UI();
            }
            else
            {
                MessageBox.Show("Please enter your name!");
            }
        }

        private void btnBuySword_Click(object sender, EventArgs e)
        {
            if (Money >= SwordPrice)
            {
                Money -= SwordPrice;
                Sword++;
                damage += 50;
                UI();
                lblAdv.Text = "You bought a " + Swordd;
            }
            else
            {
                lblAdv.Text = "You don't have enough money.";
            }
        }

        private void btnBuyArmor_Click(object sender, EventArgs e)
        {
            if (Money >= ArmorPrice)
            {
                Money -= ArmorPrice;
                Armor++;
                HealthMax += 100;
                Health += 100;
                UI();
                lblAdv.Text = "You bought a " + Armorr + " Armor";
            }
            else
            {
                lblAdv.Text = "You don't have enough money.";
            }
        }
    }
}
