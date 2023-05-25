using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binary_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int total; // new total integer, this will be used to calculate the total number
        
        // new instance of the random number
        //we will give random numbers to the user to calculate in binary
        Random randomNumber = new Random();

        int randomInt; // this random int will contain a random number

        public MainWindow()
        {
            InitializeComponent();

            checkButton.IsEnabled = false;
            // disable the check answer button
            // when the start game button is pressed then we will enable this one
        }

        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            total = 0; // set the initial total to 0
            answerTxt.Content = ""; // empty the answer txt label
            // we need to access all of the text boxes from the grid
            // we will run a for each loop to indentify all of the text boxes
            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                // if the text box contains 1
                // meaning 0 is inactive binary and 1 is active binary
                if (x.Text == "1")
                {
                    total += Convert.ToInt32(x.Tag);
                    // then we will search for the tags associated with the text boxes
                    // and add them together by converting them to integers first
                }
                // once the calculation is completed we will show the binary number on the screen by
                // taking the content from each of the text boxes and adding them next to each other
                // notice the += sign this means instead of adding them up we will add them to the existing string
                answerTxt.Content += x.Text;
            }
            //in the if statement below it will check for the results either correct or incorrect
            if (total == randomInt)
            {
                // if the total number and random int is equals 
                // meaning if the anwer is correct
                // first we disable the check answer button
                checkButton.IsEnabled = false;
                // we will show the message the binary number for this equation is correct
                answerTxt.Content += "  is correct!";
            }
            else
            {
                // if the total number and random int is not equals
                // we will show the binary number is incorrect
                answerTxt.Content += "  is incorrect!";
            }

        }

        private void startGame(object sender, RoutedEventArgs e)
        {
            // this is the start game script
            // first we generate a random number between 0 to 511
            randomInt = randomNumber.Next(0, 511);
            // show the question to the screen on the question txt label
            questionTxt.Content = "What is " + randomInt + " in Binary?";
            // enable the check answer button
            checkButton.IsEnabled = true;
            // put an empty string on the answer txt label
            answerTxt.Content = "";
            // find all of the text boxes in the Grid and set them all to a 0 inside
            foreach (var x in mainGrid.Children.OfType<TextBox>())
            {
                x.Text = "0";
            }

        }

        private void showHelp(object sender, RoutedEventArgs e)
        {
            // this is the help button script
            // when this button is clicked it will show a message box with the message from below
            MessageBox.Show(
                "Click on the start button to begin" + Environment.NewLine +
                "Enter 1 or 0 into the boxes" + Environment.NewLine +
                "If you enter 1 into a box it will represent the value above the box, 0 will deactivate it" + Environment.NewLine +
                "Click on check answer to see if its correct" + Environment.NewLine +
                "You can retry until its correct or start with a new number"
                );

        }
    }
}
