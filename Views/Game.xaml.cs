using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Number_Guessing_Game.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        Helpers.Validation myValidation = new Helpers.Validation();
        public Game()
        {
            InitializeComponent();
        }

        int chances = 7;
        int number;

        private void load(object sender, RoutedEventArgs e)
        {
            generateRandomNumber();
        }

        private void submitBtnClick(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled = false;
            string string_answer = GuessedNumber.Text;

            string result = myValidation.validate(string_answer, "number", 1, 99, "answer");

            if (result == "valid")
            {

                int int_answer = (int)Int32.Parse(string_answer);
                int string_answer_length = string_answer.Length;
                string first_digit_answer = string_answer.Substring(0, 1);

                if (int_answer == number && chances != 0)
                {
                    SubmitBtn.IsEnabled = false;
                    GuessedNumber.Text = "";
                    MessageBox.Show("You won", "Success");
                }
                else if (int_answer > number && chances != 0)
                {
                    SubmitBtn.IsEnabled = true;
                    MessageBox.Show("Wrong, the correct number is lower", "Error");
                    chances = chances - 1;
                    ChancesLabel.Content = "You have " + chances + " chance left";
                    GuessedNumber.Text = "";
                    checkChances();
                }
                else if (int_answer < number && chances != 0)
                {
                    SubmitBtn.IsEnabled = true;
                    InformationTxtBlock.Foreground = Brushes.DarkRed;
                    MessageBox.Show("Wrong, the correct number is higher", "Error");
                    chances = chances - 1;
                    ChancesLabel.Content = "You have " + chances + " chance left";
                    GuessedNumber.Text = "";
                    checkChances();
                }
            }
            else
            {
                SubmitBtn.IsEnabled = true;
                GuessedNumber.Text = "";
                MessageBox.Show(result, "Error");
            }
        }

        private void resetBtnClick(object sender, RoutedEventArgs e)
        {
            generateRandomNumber();
            chances = 7;
            GuessedNumber.Text = "";
            ChancesLabel.Content = "You have " + chances + " chance left";
            SubmitBtn.IsEnabled = true;
        }

        private void aboutBtnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Number Guessing Game 1.0" + '\n' + "Author: Evanna" + '\n' + "Inspired by: (GBA)Megaman Battle Network 1 Mini Game", "About");
        }

        private void generateRandomNumber()
        {
            Random rnd = new Random();
            number = rnd.Next(1, 99);
            ChancesLabel.Content = "You have " + chances + " chance left";
            GuessedNumber.Text = "";
            string string_number = number.ToString();
            SubmitBtn.IsEnabled = true;
        }
        private void checkChances()
        {
            if (chances == 0)
            {
                MessageBox.Show("Gameover", "Error");
                SubmitBtn.IsEnabled = false;
                ChancesLabel.Content = "You have " + chances + " chance left";
            }
        }
    }
}
