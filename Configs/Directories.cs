using System.IO;

namespace WPF_Number_Guessing_Game.Configs
{
    public class Directories
    {
        public string base_directory = System.AppDomain.CurrentDomain.BaseDirectory;

        public void configDirectory()
        {
            if (Directory.Exists(base_directory + "/Configs") == false)
            {
                Directory.CreateDirectory(base_directory + "/Configs");
            }
        }
    }
}