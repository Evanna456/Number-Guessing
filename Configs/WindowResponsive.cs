using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace WPF_Number_Guessing_Game.Configs
{
    public class WindowConfigJSON
    {
        public double width { get; set; }
        public double height { get; set; }
        public string window_state { get; set; }
    }

    public class WindowResponsive
    {
        private Configs.Directories myDirectories = new Configs.Directories();

        public void windowConfigCreate()
        {
            string base_directory = myDirectories.base_directory;
            myDirectories.configDirectory();

            string file_path = Path.Combine(base_directory + "/Configs/", "window.json");

            if (File.Exists(file_path) == false)
            {
                WindowConfigJSON config = new WindowConfigJSON();
                config = new WindowConfigJSON
                {
                    width = Convert.ToDouble("640"),
                    height = Convert.ToDouble("640"),
                    window_state = "Normal"
                };

                string json_string = JsonSerializer.Serialize(config);
                File.WriteAllText(base_directory + "/Configs/window.json", json_string);
            }
        }

        public void windowConfigLoad()
        {
            string base_directory = myDirectories.base_directory;
            myDirectories.configDirectory();

            string data = File.ReadAllText(base_directory + "/Configs/window.json");
            WindowConfigJSON json = JsonSerializer.Deserialize<WindowConfigJSON>(data);
            double width = json.width;
            double height = json.height;
            string window_state = json.window_state;

            Application.Current.MainWindow.Width = width;
            Application.Current.MainWindow.Height = height;

            if (window_state == "Normal")
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else if (window_state == "Maximized")
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else if (window_state == "Minimized")
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        public void windowConfigUpdate()
        {
            string base_directory = myDirectories.base_directory;
            myDirectories.configDirectory();

            var new_width = Application.Current.MainWindow.Width;
            var new_height = Application.Current.MainWindow.Height;
            var new_state = Convert.ToString(Application.Current.MainWindow.WindowState);

            if (Double.IsNaN(new_width) == true || Double.IsNaN(new_height) == true)
            {
                new_width = Convert.ToDouble("640");
                new_height = Convert.ToDouble("640");
            }
            else
            {
                WindowConfigJSON config = new WindowConfigJSON();
                config = new WindowConfigJSON
                {
                    width = new_width,
                    height = new_height,
                    window_state = new_state
                };

                string jsonString = JsonSerializer.Serialize(config);
                File.WriteAllText(base_directory + "/Configs/window.json", jsonString);
            }
        }
    }
}