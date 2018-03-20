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
        //Running Totals/Round Count
        
        private double totalCorrect = 0.0;
        private int currentRound = 1;

        //Field Level User Inputed Data
        private string name = "";
        private int highestNum = 0;
        private int rounds = 0;


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
            


            //Input Validation and recording information for the game
            if (nameTextBox.Text != "")
            {
                if (int.TryParse(roundsTextBox.Text, out rounds))
                {
                    if (int.TryParse(highestTextBox.Text, out highestNum))
                    {
                        name = nameTextBox.Text;
                        
                        //reveal the playable game, hide start game info
                        startMenuGroupBox.Visible = false;
                        activeGameGroupBox.Visible = true;

                        randDisplay();
                       
                        
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
            int factor1, factor2;
             

            if(currentRound < rounds)
            {
                
                randDisplay();
                checkAnswer();


                currentRound++;

            }
            else
            {
                MessageBox.Show("Game Over. Total Correct: " + totalCorrect + " out of " + rounds);
            }

           
           

        }//end of Answer button

        private void randDisplay()
        {
            int num1, num2;


            //create rand object and assign to numbers
            Random rand = new Random();

            num1 = rand.Next(highestNum + 1);
            num2 = rand.Next(highestNum + 1);

            //Display numbers
            randNumLabel1.Text = num1.ToString();
            randNumLabel2.Text = num2.ToString();

            
            
        }//end randDisplay


       private void checkAnswer()
        {
            int number1, number2;
            int answer;
            int studentAnswer;

           

            //Get values of rand #
            int.TryParse(randNumLabel1.Text, out number1);
            int.TryParse(randNumLabel2.Text, out number2);

            answer = number1 + number2;

            //Get Student Answer
            int.TryParse(studentAnswerTextBox.Text, out studentAnswer);

            if(studentAnswer == answer)
            {
                MessageBox.Show("Correct!");
                totalCorrect++;
            }
            else
            {
                MessageBox.Show("Incorrect, the correct answer was " + answer.ToString());
            }
        

        }
       
    }
}
