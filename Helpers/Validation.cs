using System;
using System.Text.RegularExpressions;

namespace WPF_Number_Guessing_Game.Helpers
{
    public class Validation
    {
        public string validate(string content, string type, int min, int max, string name)
        {
            Regex regexNumber = new Regex("^[0-9]*$");

            if (type == "number" && regexNumber.IsMatch(content) == true && content != "" && content != null)
            {
                int number_content = (int)Int32.Parse(content);

                if (number_content < min)
                {
                    return "The " + name + " is lower than the minimum allowed";
                }
                else if (number_content > max)
                {
                    return "The " + name + " is higher than the maximum allowed";
                }
                else if (number_content >= min && number_content <= max)
                {
                    return "valid";
                }
            }
            else if (content == "" || content == null)
            {
                return "Please type a number";
            }
            else
            {
                return "Not a number";
            }

            return "";
        }
    }
}