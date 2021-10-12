using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WPF_Number_Guessing_Game.Configs
{
    class Directories
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
