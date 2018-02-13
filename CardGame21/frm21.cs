using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame21
{
    public partial class frm21 : Form
    {
        int intCard1, intCard2, intCard3, intCard4;
        int intDealer1, intDealer2, intDealer3, intDealer4;

        private void btnScore_Click(object sender, EventArgs e)
        {
            btnHit.Enabled = false;
            //Add more cards to dealer if needed
            if (intDealerScore < intPlayerScore)
            {
                do
                {
                    if (lblDealer3.Visible == false)
                    {
                        lblDealer3.Visible = true;
                        intDealerScore += intDealer3;
                    }
                    else
                    {
                        lblDealer4.Visible = true;
                        intDealerScore += intDealer4;
                    }
                } while (intDealerScore < 15);

            }
            lblDealerScore.Text = intDealerScore.ToString();
            if (intDealerScore > 21)
            {
                lblWinner.Text = "Dealer went bust! Player Wins!! Game Over!";
            }
            else
            {
                if (intPlayerScore > intDealerScore)
                {
                    //Player Wins
                    lblWinner.Text = "Player Wins!!";
                    btnScore.Enabled = false;
                    btnDeal.Enabled = true;
                }
                else if(intPlayerScore < intDealerScore)
                {
                    //Dealer Wins
                    lblWinner.Text = "Dealer Wins!! Try Again!";
                    btnScore.Enabled = false;
                    btnDeal.Enabled = true;
                }
                else
                {
                    //Tie Game
                    lblWinner.Text = "Tie Game. No Winner.";
                    btnScore.Enabled = false;
                    btnDeal.Enabled = true;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            //Add a card to the player
            if (lblCard3.Visible == false)
            {
                lblCard3.Visible = true;
                intPlayerScore += intCard3;
            }
            else
            {
                lblCard4.Visible = true;
                intPlayerScore += intCard4;
                btnHit.Enabled = false;
            }
            //Update player's score
            lblPlayerScore.Text = intPlayerScore.ToString();

           if(intPlayerScore > 21)
            {
                lblWinner.Text = "Player went bust!! Game Over!";
                btnScore.Enabled = false;
                btnDeal.Enabled = true;
            }
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            //Disable Deal until new game
            btnDeal.Enabled = false;
            btnScore.Enabled = true;
            btnHit.Enabled = true;

            //Hide cards
            lblCard3.Visible = false;
            lblCard4.Visible = false;
            lblDealer3.Visible = false;
            lblDealer4.Visible = false;

            //Set Scores to 0
            intPlayerScore = 0;
            intDealerScore = 0;
            lblPlayerScore.Text = intPlayerScore.ToString();
            lblDealerScore.Text = intDealerScore.ToString();

            //Randomize the number pot
            Random rndRandom = new Random();

            //Generate Random numbers 1-9 for the Cards
            intCard1 = rndRandom.Next(1, 9);
            intCard2 = rndRandom.Next(1, 9);
            intCard3 = rndRandom.Next(1, 9);
            intCard4 = rndRandom.Next(1, 9);
            intDealer1 = rndRandom.Next(1, 9);
            intDealer2 = rndRandom.Next(1, 9);
            intDealer3 = rndRandom.Next(1, 9);
            intDealer4 = rndRandom.Next(1, 9);

            //Declare the value of each card and it's label
            lblCard1.Text = intCard1.ToString();
            lblCard2.Text = intCard2.ToString();
            lblCard3.Text = intCard3.ToString();
            lblCard4.Text = intCard4.ToString();
            lblDealer1.Text = intDealer1.ToString();
            lblDealer2.Text = intDealer2.ToString();
            lblDealer3.Text = intDealer3.ToString();
            lblDealer4.Text = intDealer4.ToString();

            //Show two of the players cards
            lblCard1.Visible = true;
            lblCard2.Visible = true;

            //Show Players score
            intPlayerScore = intCard1 + intCard2;
            lblPlayerScore.Text = intPlayerScore.ToString();

            //Show two of the dealers cards
            lblDealer1.Visible = true;
            lblDealer2.Visible = true;

            //Show Dealers score
            int DealerScore = intDealer1 + intDealer2;
            lblDealerScore.Text = intDealerScore.ToString();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Four Card Game 21 by Derek (Jexington) Sneddon. Febuary, 2018.");
        }

        int intPlayerScore, intDealerScore;

        public frm21()
        {
            InitializeComponent();
        }

    }
}
