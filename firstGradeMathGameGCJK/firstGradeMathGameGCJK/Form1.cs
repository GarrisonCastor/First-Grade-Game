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
        private int currentRound = 0;

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


                       int answer = mathGame(currentRound);
                        
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

            //call the calculated answer
            answer = mathGame(currentRound);

            //Check their answer
            if (studentAnswer == answer)
            {
                MessageBox.Show("Correct! Great Job!");

                //Store their correct answer and move to next round
                totalCorrect += 1;
                
            }
            else
            {
                MessageBox.Show("Incorrect! The Answer was " + answer.ToString());
                
            }


           
           

        }//end of Answer button


        private int mathGame(int currentRound)
        {
            
                int randAnswer = 0;

                Random rand = new Random(highestNum);         //random method's () needs to have the variable for the highest value
                Random rand2 = new Random(highestNum);                                    //in calculation we will need to do +1 to the random number or 
                                                                                              //add it in inside the parenthesis

                //Create arrays to be filled with random numbers
                int[] randArray1 = new int[rounds];
                int[] randArray2 = new int[rounds];


            //Assign Random numbers to the current round's respective array block
            
                randArray1[currentRound] = rand.Next(highestNum);
                randArray2[currentRound] = rand2.Next(highestNum);

                randAnswer = randArray1[currentRound] + randArray2[currentRound];

                //display the numbers
                randNumLabel1.Text = randArray1[currentRound].ToString();
                randNumLabel2.Text = randArray1[currentRound].ToString();

                currentRound++;
            
                //Calculate the correct answer
                

                

                return randAnswer;
            
            
        }
    }
}
