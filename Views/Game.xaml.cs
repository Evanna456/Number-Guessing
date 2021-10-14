using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using WPF_Number_Guessing_Game.Configs;

namespace WPF_Number_Guessing_Game.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        private Helpers.Validation myValidation = new Helpers.Validation();
        private Configs.Directories myDirectories = new Configs.Directories();
        private Configs.Game myGame = new Configs.Game();
        private Configs.GameConfigJSON GameConfigJSON = new Configs.GameConfigJSON();
        private int number;
        private int min_range;
        private int max_range;
        private int no_chances;
        private int history_no_chances;

        public Game()
        {
            InitializeComponent();
        }

        private void navigateToHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/Index.xaml", UriKind.Relative));
        }

        private void showAboutWindow(object sender, RoutedEventArgs e)
        {
            AboutWindow myAboutWindow = new AboutWindow();
            myAboutWindow.Show();
        }

        private void load(object sender, RoutedEventArgs e)
        {
            gameConfigLoad();
        }

        private void submitBtnClick(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled = false;
            var string_answer = GuessedNumber.Text;

            if (myValidation.validate(string_answer, "number", min_range, max_range, "answer") == "valid")
            {
                int int_answer = (int)Int32.Parse(string_answer);

                if (int_answer == number && no_chances != 0)
                {
                    SubmitBtn.IsEnabled = false;
                    GuessedNumber.Text = "";
                    MessageBox.Show("You won", "Success");
                }
                else if (int_answer > number && no_chances != 0)
                {
                    SubmitBtn.IsEnabled = true;
                    MessageBox.Show("Wrong, the correct number is lower", "Error");
                    no_chances = no_chances - 1;
                    ChancesLabel.Content = "You have " + no_chances + " chance left";
                    GuessedNumber.Text = "";
                    checkChances();
                }
                else if (int_answer < number && no_chances != 0)
                {
                    SubmitBtn.IsEnabled = true;
                    InformationTxtBlock.Foreground = Brushes.DarkRed;
                    MessageBox.Show("Wrong, the correct number is higher", "Error");
                    no_chances = no_chances - 1;
                    ChancesLabel.Content = "You have " + no_chances + " chance left";
                    GuessedNumber.Text = "";
                    checkChances();
                }
            }
            else
            {
                SubmitBtn.IsEnabled = true;
                GuessedNumber.Text = "";
                MessageBox.Show(myValidation.validate(string_answer, "number", min_range, max_range, "answer"), "Error");
            }
        }

        private void resetBtnClick(object sender, RoutedEventArgs e)
        {
            generateRandomNumber(min_range, max_range);
            no_chances = history_no_chances;
            GuessedNumber.Text = "";
            ChancesLabel.Content = "You have " + no_chances + " chance left";
            SubmitBtn.IsEnabled = true;
        }

        public void gameConfigLoad()
        {
            myGame.gameConfigCreate();
            string base_directory = myDirectories.base_directory;

            string data = File.ReadAllText(base_directory + "/Configs/game.json");
            GameConfigJSON json = JsonSerializer.Deserialize<GameConfigJSON>(data);
            min_range = json.min_range;
            max_range = json.max_range;
            no_chances = json.no_chances;
            history_no_chances = json.no_chances;

            RangeLabel.Content = "Guess the Number from " + min_range.ToString() + " to " + max_range.ToString();
            ChancesLabel.Content = "You have " + no_chances.ToString() + " chance left";

            generateRandomNumber(min_range, max_range);
        }

        public void generateRandomNumber(int min_range, int max_range)
        {
            Random rnd = new Random();
            number = rnd.Next(min_range, max_range);
            GuessedNumber.Text = "";
            SubmitBtn.IsEnabled = true;
        }

        public void checkChances()
        {
            if (no_chances == 0)
            {
                MessageBox.Show("Gameover the answer is "+ number, "Error");
                SubmitBtn.IsEnabled = false;
                ChancesLabel.Content = "You have " + no_chances + " chance left";
            }
        }

        //END
    }
}