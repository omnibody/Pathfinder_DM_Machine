using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
    class GUI
    {

        public static void Title(String str)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            str = String.Format("        {0}", str);
            int strLength = str.Length;
            for(int i = 0; i < Console.WindowWidth-strLength-1; i++)
            {
                str = str + " ";
            }
            str = str + "\n";
            String line = "";
            for(int i = 0; i < Console.WindowWidth-1; i++)
            {
                line = line + "=";
            }

            line = line + "\n";

            Console.Write(str);
            
            Console.WriteLine(line);

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void MenuTitle(String str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            str = String.Format(" ==== {0} ====\n\n", str);

            Console.Write(str);
            Console.ResetColor();
        }

        public static void MenuOption(int index, String str)
        {
            str = String.Format(" - ({0}) : {1}\n", index, str);

            Console.Write(str);
        }

        public static void Anouncement(String str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            str = String.Format(" (~) : ({0})\n", str);

            Console.Write(str);
            Console.ResetColor();
        }

        public static void GetInput(String str)
        {
            str = String.Format(" - {0}: ", str);

            Console.Write(str);
        }

        public static int GetInputInt(string message)
        {
            Nullable<int> input = null;

            while (input == null)
            {
                try
                {
                    GUI.GetInput(message);
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) //Error
                {
                    GUI.Anouncement(e.Message);
                }
            }

            return input.Value;
        
        }

    }
}
