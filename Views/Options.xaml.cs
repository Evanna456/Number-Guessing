using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPF_Number_Guessing_Game.Configs;

namespace WPF_Number_Guessing_Game.Views
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        private Configs.Directories myDirectories = new Configs.Directories();
        private Configs.Game myGameConfigs = new Configs.Game();

        public Options()
        {
            InitializeComponent();
        }

        public void load(object sender, RoutedEventArgs e)
        {
            string base_directory = myDirectories.base_directory;
            myDirectories.configDirectory();
            myGameConfigs.gameConfigCreate();

            string data = File.ReadAllText(base_directory + "/Configs/game.json");
            GameConfigJSON json = JsonSerializer.Deserialize<GameConfigJSON>(data);
            int min_range = json.min_range;
            int max_range = json.max_range;

            MinRangeTextbox.Text = min_range.ToString();
            MaxRangeTextbox.Text = max_range.ToString();
        }

        public void navigateToHome(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/Index.xaml", UriKind.Relative));
        }

        public void showAboutWindow(object sender, RoutedEventArgs e)
        {
            AboutWindow myAboutWindow = new AboutWindow();
            myAboutWindow.Show();
        }

        public void saveBtnClick(object sender, RoutedEventArgs e)
        {
            string base_directory = myDirectories.base_directory;
            SaveOptionsBtn.IsEnabled = false;
            myGameConfigs.gameConfigCreate();

            string string_min_range = MinRangeTextbox.Text;
            string string_max_range = MaxRangeTextbox.Text;

            int int_min_range = Int32.Parse(string_min_range);
            int int_max_range = Int32.Parse(string_max_range);

            int range = int_max_range - int_min_range;
            string string_range = range.ToString();

            int string_range_length = string_range.Length;

            string first_digit = string_range.Substring(0, 1);
            int int_first_digit = Int32.Parse(first_digit);
            string no_chances = "0";
            Boolean saveOption = false;

            if (range <= 10)
            {
                no_chances = "3";
                saveOption = true;
            }
            else if(range <= 50)
            {
                no_chances = "5";
                saveOption = true;
            }else if(range > 51 && range <= 100)
            {
                no_chances = "7";
                saveOption = true;
            }else if(range > 100)
            {
                int total_chances = 3 + int_first_digit ;
                for (int it = 0;it < string_range_length;it++)
                {
                    total_chances = total_chances + Int32.Parse(string_range[it].ToString());
                }

                no_chances = total_chances.ToString();
                saveOption = true;
            }

            if (saveOption == true) {

                GameConfigJSON config = new GameConfigJSON();
                config = new GameConfigJSON
                {
                    min_range = int_min_range,
                    max_range = int_max_range,
                    no_chances = Int32.Parse(no_chances),
                };

                string json_string = JsonSerializer.Serialize(config);
                File.WriteAllText(base_directory + "/Configs/game.json", json_string);

                SaveOptionsBtn.IsEnabled = true;
                MessageBox.Show("Option Saved Successfully", "Success");

            }
        }
    }
}