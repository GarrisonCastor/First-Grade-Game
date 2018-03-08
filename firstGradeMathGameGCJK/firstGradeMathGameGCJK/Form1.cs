using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * First Grade Math Game
 * Garrison Castor & Jhansi Kesireddy
 */

namespace firstGradeMathGameGCJK
{
    public partial class firstGradeMathGameForm : Form
    {
        //Running Total and total correct answers
        private double runningTotal = 0.0;
        private double totalCorrect = 0.0;


        public firstGradeMathGameForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Mrs. Branch's First Grade Math Game!");     //forgot the teacher's name
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Start of Game
            string name = "";
            double highestNum = 0.0;
            double rounds = 0.0;


            //Input Validation and recording information for the game
            if (nameTextBox.Text != "")
            {
                if (double.TryParse(roundsTextBox.Text, out rounds))
                {
                    if (double.TryParse(highestTextBox.Text, out highestNum))
                    {
                        name = nameTextBox.Text;

                        //reveal the playable game, hide start game info
                        startMenuGroupBox.Visible = false;
                        activeGameGroupBox.Visible = true;




                    }
                    else
                    {
                        MessageBox.Show("Please enter the highest number that can appear.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter how many rounds the student will play.");
                }
            }
            else
            {
                MessageBox.Show("Please enter your name.");
            }
        
        }//end of Start Game button

        private void answerButton_Click(object sender, EventArgs e)
        {
            //Answer Button

            int answer = 0;
            int studentAnswer = 0;



            //Get Student's answer
            int.TryParse(studentAnswerTextBox.Text, out studentAnswer);



            //Check their answer
            if (studentAnswer == answer)
            {
                MessageBox.Show("Correct! Great Job!");
                totalCorrect += 1;
            }
            else
            {
                MessageBox.Show("Incorrect! The Answer was " + answer.ToString());
            }

            //not sure where to put this, needs to be put in with the calculations
            Random rand = new Random();         //random method's () needs to have the variable for the highest value
                                                //in calculation we will need to do +1 to the random number or 
                                                //add it in inside the parenthesis
            Random rand2 = new Random();

        }//end of Answer button
    }
}
