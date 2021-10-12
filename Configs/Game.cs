using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace WPF_Number_Guessing_Game.Configs
{
    public class GameConfigJSON
    {
        public int min_range { get; set; }
        public int max_range { get; set; }
        public int no_chances { get; set; }
    }
    class Game
    {
        Configs.Directories myDirectories = new Configs.Directories();
        public void gameConfigCreate()
        {
            string base_directory = myDirectories.base_directory;
            myDirectories.configDirectory();

            string file_path = Path.Combine(base_directory + "/Configs/", "game.json");

            if (File.Exists(file_path) == false)
            {

                GameConfigJSON config = new GameConfigJSON();
                config = new GameConfigJSON
                {
                    min_range = Int32.Parse("1"),
                    max_range = Int32.Parse("100"),
                    no_chances = Int32.Parse("7"),
                };

                string json_string = JsonSerializer.Serialize(config);
                File.WriteAllText(base_directory + "/Configs/game.json", json_string);

            }

        }

        string string_range;
        int int_string_range_length;
        string no_chances;
        string first_digit;
        int int_first_digit;
        int range;

        public void gameConfigUpdate(string min_range, string max_range)
        {

            gameConfigCreate();
            string base_directory = myDirectories.base_directory;

            int int_min_range = Int32.Parse(min_range);
            int int_max_range = Int32.Parse(max_range);

            range = int_max_range - int_min_range;
            string_range = range.ToString();
            int_string_range_length = string_range.Length;

            first_digit = string_range.Substring(0, 1);
            int_first_digit = Int32.Parse(first_digit);


            GameConfigJSON config = new GameConfigJSON();
            config = new GameConfigJSON
            {
                min_range = int_min_range,
                max_range = int_max_range,
                no_chances = Int32.Parse(no_chances),
            };

            string json_string = JsonSerializer.Serialize(config);
            File.WriteAllText(base_directory + "/Configs/game.json", json_string);

        }
     

        }
}
