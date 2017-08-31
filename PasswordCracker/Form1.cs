using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordCracker
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PasswordCracker : Form
    {
        // Class level variables
        // TODO: Consider dividing the array into multiple arrays that can be selected and joined
        char[] alphaNumeric = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'I', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        // 
        public PasswordCracker()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)//TODO: Fix Button event name
        {
            // Class level variables
            char[] attempt = new char[100];
            int[] hold = new int[1];

            int count = 0;
            string myString = "";
            int i = 0;

            // Cycle through all combonations of letters until the password is cracked.
            while (string.Equals(textBox1.Text, GetAttempt(hold, attempt, myString)))//.Equals())
            {
                // Keep track of the number of attempts
                count++;
                MessageBox.Show(count + "\r\n" + textBox1.Text + "\r\n" + (myString = new string(attempt).Trim()));
                //
                if (hold[i] < 61)// If this is true, increment hold
                {
                    hold[i]++;
                }
                else if (hold[i] == 61) // If this is true, reset the current hold and move over to the next non 62 hold
                {
                    //
                    do
                    {
                        //
                        hold[i] = 0;
                        i += 1;

                        //
                        if (hold.Length == i)
                        {
                            hold = SetNewArrayLength(hold);// Ima try it in debug. I am scratching my head atm
                        }

                        //
                        hold[i]++;

                    } while (hold[i] == 61);

                    i = 0;
                }
                
            }

            //
            MessageBox.Show("You did it!");
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hold"></param>
        public int[] SetNewArrayLength(int[] hold)
        {
            // Method level variables
            int[] T = new int[hold.Length];
            int i = 0;

            //
            hold.CopyTo(T, 0);
            hold = new int[hold.Length + 1];

            //
            foreach (int num in T)
            {
                hold[i++] = num;
            }

            //
            hold[hold.Length - 1] = 0;

            return hold;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hold"></param>
        /// <param name="attempt"></param>
        /// <returns></returns>
        public string GetAttempt(int[] hold, char[] attempt, string myString)
        {
            //


            //
            for (int i = 0; i < hold.Length; i++)
            {
                attempt[i] = alphaNumeric[hold[i]];
            } 

            return myString = new string(attempt).Trim();
        }

    }
}
