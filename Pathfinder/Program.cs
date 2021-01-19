using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace Pathfinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Game game = new Game();
            game.Run();
        }
    }
}
