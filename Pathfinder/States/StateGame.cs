using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
    class StateGame
        : State
    {
        protected Character character;

        public StateGame(Stack<State> states, Character activeCharacter)
            : base(states)
        {
            this.character = activeCharacter;
        }

        public void ProcessInput(int input)
        {
            switch (input)
            {
                case -1:
                    Console.Clear();
                    this.end = true;
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine(this.character.ToString());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    GUI.Anouncement($"Added 2000 exp to character: {this.character.Name}");
                    this.character.CalulateExp(2000);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    break;

            }

        }

        override public void Update()
        {
            GUI.MenuTitle("Game State");
            GUI.MenuOption(1, "Character Stats");
            GUI.MenuOption(2, "Add 2000 exp");
            GUI.MenuOption(-1, "Exit");

            int input = GUI.GetInputInt("Input");

            this.ProcessInput(input);
        }

    }
}
