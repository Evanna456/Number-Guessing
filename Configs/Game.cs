using System;
using System.IO;
using System.Text.Json;

namespace WPF_Number_Guessing_Game.Configs
{
    public class GameConfigJSON
    {
        public int min_range { get; set; }
        public int max_range { get; set; }
        public int no_chances { get; set; }
    }

    public class Game
    {
        private Configs.Directories myDirectories = new Configs.Directories();

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

        //END
    }
}