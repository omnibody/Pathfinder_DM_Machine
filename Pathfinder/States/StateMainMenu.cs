using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
    class StateMainMenu 
        : State
    {
        protected ArrayList characterList;
        protected Character activeCharacter;
        protected int Difficulty = 2;

        public StateMainMenu(Stack<State> states, ArrayList character_list) 
            : base(states)
        {
            this.characterList = character_list;
        }

        public void ProcessInput(int input)
        {
            switch(input)
            {
                case -1:
                    this.end = true;
                    break;
                case 1:
                    this.StartNewGame();
                    break;
                case 2:
                    Console.Clear();
                    this.states.Push(new StateCharacterCreator(this.states, this.characterList, this.Difficulty));
                    break;
                case 3:
                    Console.Clear();
                    this.SelectCharacters();
                    break;
                case 4:
                    Console.Clear();
                    this.SelectDifficulty();
                    break;
                default:
                    break;

            }

        }

        override public void Update()
        {
            
            GUI.Title("PATHFINDER");

            if(this.activeCharacter != null)
                GUI.Anouncement("Active Character: " + this.activeCharacter.Name);

            GUI.MenuTitle("Main Menu");
            GUI.MenuOption(1, "New Game");
            GUI.MenuOption(2, "Character Creator");
            GUI.MenuOption(3, "Select Characters");
            GUI.MenuOption(4, "Select Difficulty");
            GUI.MenuOption(-1, "Exit");

            int input = GUI.GetInputInt("Input");

            this.ProcessInput(input);
        }

        public void StartNewGame()
        {
            //While the active character variable is null, one cannot start the game
            if(this.activeCharacter == null) //error
            {
                GUI.Anouncement("There is no active character selected");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else //Start game
            {
                Console.Clear();
                this.states.Push(new StateGame(this.states, this.activeCharacter));
            }
        }

        public void SelectCharacters()
        {
            GUI.MenuTitle("Character Selection");
            //Print all characters to select
            if (this.characterList.Count > 0)
            {
                for (int i = 0; i < this.characterList.Count; i++)
                {
                    Character charI = (Character)this.characterList[i];
                    GUI.MenuOption(i, charI.Name);
                }

                int choice = GUI.GetInputInt("Character Selection");

                try
                {
                    this.activeCharacter = (Character)this.characterList[choice];
                }
                catch (Exception e)
                {
                    GUI.Anouncement(e.Message);
                }

                if (this.activeCharacter != null)
                {
                    GUI.Anouncement($"The Character {this.activeCharacter.Name} is selected");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                GUI.Anouncement("No characters to select. Please create a character first.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
                
        }

        public void SelectDifficulty()
        {
            GUI.MenuTitle("Select Difficulty");

            GUI.MenuOption(1, "Low Fantasy");
            GUI.MenuOption(2, "Standard Fantasy");
            GUI.MenuOption(3, "High Fantasy");
            GUI.MenuOption(4, "Epic Fantasy");

            int choice = GUI.GetInputInt("Select Difficulty");

            switch (choice)
            {
                case 1:
                    //low fantasy
                    this.Difficulty = 1;
                    Console.WriteLine("Difficulty set to Low Fantasy.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    //standard fantasy
                    this.Difficulty = 2;
                    Console.WriteLine("Difficulty set to Standard Fantasy.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    //high fantasy
                    this.Difficulty = 3;
                    Console.WriteLine("Difficulty set to High Fantasy.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    //epic fantasy
                    this.Difficulty = 4;
                    Console.WriteLine("Difficulty set to Epic Fantasy.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    //standard fantasy
                    this.Difficulty = 2;
                    Console.WriteLine("Difficulty set to Standard Fantasy.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
