using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pathfinder
{
    class StateCharacterCreator
        : State
    {

        protected ArrayList characterList;
        protected Character ActiveCharacter;
        protected int Difficulty;

        public StateCharacterCreator(Stack<State> states, ArrayList character_list, int difficulty = 2)
            : base(states)
        {
            this.characterList = character_list;
            this.Difficulty = difficulty;
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
                    this.CreateChartacter();
                    break;
                case 2:
                    Console.Clear();
                    EditChartacter();
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;

            }

        }

        override public void Update()
        {
            GUI.Title("PATHFINDER");
            GUI.MenuTitle("Charactor Creator");
            GUI.MenuOption(1, "New Character");
            GUI.MenuOption(2, "Edit Character");
            GUI.MenuOption(3, "Delete Character");
            GUI.MenuOption(-1, "Exit");


            int input = GUI.GetInputInt("Input");

            this.ProcessInput(input);
        }

        private void CreateChartacter()
        {
            Character character = new Character();
            character.difficulty = this.Difficulty;

            switch(this.Difficulty)
            {
                case 1:
                    character.AttributePoints = 10;
                    break;
                case 2:
                    character.AttributePoints = 15;
                    break;
                case 3:
                    character.AttributePoints = 20;
                    break;
                case 4:
                    character.AttributePoints = 25;
                    break;
                default:
                    break;
            }

            String name = "";
            String description = "";
            GUI.GetInput("Input Character Name");
            name = Console.ReadLine();
            GUI.GetInput("Input Character Description");
            description = Console.ReadLine();
            character.Name = name;
            character.Description = description;
            character.Job.Add(new Fighter());
            character.Feats.Add(new TestFeat());
            CharacterStatsForm(character);

            character.CalculateStats();
            this.characterList.Add(character);
            GUI.Anouncement("Character Created");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private void EditChartacter()
        {
            Console.Clear();
            if (this.characterList.Count > 0)
            {
                GUI.MenuTitle("Select Character to Edit");
                for (int i = 0; i < this.characterList.Count; i++)
                {
                    Character charI = (Character)this.characterList[i];
                    GUI.MenuOption(i, charI.Name);
                }

                int choice = GUI.GetInputInt("Character Selection");

                try
                {
                    ActiveCharacter = (Character)this.characterList[choice];
                }
                catch (Exception e)
                {
                    GUI.Anouncement(e.Message);
                }

                if (ActiveCharacter != null)
                {
                    GUI.Anouncement($"The Character {ActiveCharacter.Name} is selected");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();

                    String name = "";
                    String description = "";
                    GUI.Anouncement($"The Character {ActiveCharacter.Name} is selected");
                    GUI.GetInput("Change Character Name");
                    name = Console.ReadLine();
                    Console.Clear();
                    GUI.GetInput("Change Character Description");
                    description = Console.ReadLine();
                    Console.Clear();
                    GUI.MenuTitle("Change Character Difficulty");
                    GUI.MenuOption(1, "Low Fantasy");
                    GUI.MenuOption(2, "Standard Fantasy");
                    GUI.MenuOption(3, "High Fantasy");
                    GUI.MenuOption(4, "Epic Fantasy");

                    int difficulty = GUI.GetInputInt("Select Difficulty");

                    switch(difficulty)
                    {
                        case 1:
                            if(difficulty != ActiveCharacter.difficulty)
                            {
                                ActiveCharacter.Strength = 10;
                                ActiveCharacter.Dexterity = 10;
                                ActiveCharacter.Constitution = 10;
                                ActiveCharacter.Intelligence = 10;
                                ActiveCharacter.Wisdom = 10;
                                ActiveCharacter.Charisma = 10;
                                ActiveCharacter.difficulty = 1;
                                ActiveCharacter.AttributePoints = 10;
                                CharacterStatsForm(ActiveCharacter);
                            }
                            else
                            {
                                CharacterStatsForm(ActiveCharacter);
                            }
                            break;
                        case 2:
                            if (difficulty != ActiveCharacter.difficulty)
                            {
                                ActiveCharacter.Strength = 10;
                                ActiveCharacter.Dexterity = 10;
                                ActiveCharacter.Constitution = 10;
                                ActiveCharacter.Intelligence = 10;
                                ActiveCharacter.Wisdom = 10;
                                ActiveCharacter.Charisma = 10;
                                ActiveCharacter.difficulty = 2;
                                ActiveCharacter.AttributePoints = 15;
                                CharacterStatsForm(ActiveCharacter);
                            }
                            else
                            {
                                CharacterStatsForm(ActiveCharacter);
                            }
                            break;
                        case 3:
                            if (difficulty != ActiveCharacter.difficulty)
                            {
                                ActiveCharacter.Strength = 10;
                                ActiveCharacter.Dexterity = 10;
                                ActiveCharacter.Constitution = 10;
                                ActiveCharacter.Intelligence = 10;
                                ActiveCharacter.Wisdom = 10;
                                ActiveCharacter.Charisma = 10;
                                ActiveCharacter.difficulty = 3;
                                ActiveCharacter.AttributePoints = 20;
                                CharacterStatsForm(ActiveCharacter);
                            }
                            else
                            {
                                CharacterStatsForm(ActiveCharacter);
                            }
                            break;
                        case 4:
                            if (difficulty != ActiveCharacter.difficulty)
                            {
                                ActiveCharacter.Strength = 10;
                                ActiveCharacter.Dexterity = 10;
                                ActiveCharacter.Constitution = 10;
                                ActiveCharacter.Intelligence = 10;
                                ActiveCharacter.Wisdom = 10;
                                ActiveCharacter.Charisma = 10;
                                ActiveCharacter.difficulty = 4;
                                ActiveCharacter.AttributePoints = 25;
                                CharacterStatsForm(ActiveCharacter);
                            }
                            else
                            {
                                CharacterStatsForm(ActiveCharacter);
                            }
                            break;
                        default:
                            CharacterStatsForm(ActiveCharacter);
                            break;
                    }

                    ActiveCharacter.Name = name;
                    ActiveCharacter.Description = description;

                    ActiveCharacter.CalculateStats();
                    this.characterList[choice] = ActiveCharacter;
                    Console.Clear();
                    GUI.Anouncement("Character Changed");
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

        public void CloseForm(object sender, System.EventArgs e)
        {
            if (ActiveCharacter.AttributePoints >= 0)
            {
                Button button = (Button)sender;
                Form form = button.FindForm();
                form.Close();
            }
            else
            {

            }
        }

        public void StatChange(object sender, System.EventArgs e, Character character, String stat, int amount, Label label, Label title)
        {
            if (stat == "str")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Strength + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Strength + 1 <= 13 && character.Strength >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Strength + 1 <= 15 && character.Strength >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Strength + 1 <= 17 && character.Strength >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Strength + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Strength - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Strength - 1 >= 8 && character.Strength <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Strength - 1 >= 13 && character.Strength <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Strength - 1 >= 15 && character.Strength <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Strength == 18)
                        {
                            cost = -4;
                        }
                    }
                }
                
                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if(amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Strength = character.Strength - 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Strength = character.Strength + 1;
                    }

                    
                    label.Text = character.Strength.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }

            if (stat == "dex")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Dexterity + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Dexterity + 1 <= 13 && character.Dexterity >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Dexterity + 1 <= 15 && character.Dexterity >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Dexterity + 1 <= 17 && character.Dexterity >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Dexterity + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Dexterity - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Dexterity - 1 >= 8 && character.Dexterity <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Dexterity - 1 >= 13 && character.Dexterity <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Dexterity - 1 >= 15 && character.Dexterity <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Dexterity == 18)
                        {
                            cost = -4;
                        }
                    }
                }

                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if (amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Dexterity = character.Dexterity - 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Dexterity = character.Dexterity + 1;
                    }


                    label.Text = character.Dexterity.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }

            if (stat == "con")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Constitution + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Constitution + 1 <= 13 && character.Constitution >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Constitution + 1 <= 15 && character.Constitution >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Constitution + 1 <= 17 && character.Constitution >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Constitution + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Constitution - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Constitution - 1 >= 8 && character.Constitution <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Constitution - 1 >= 13 && character.Constitution <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Constitution - 1 >= 15 && character.Constitution <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Constitution == 18)
                        {
                            cost = -4;
                        }
                    }
                }

                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if (amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Constitution = character.Constitution - 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Constitution = character.Constitution + 1;
                    }


                    label.Text = character.Constitution.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }

            if (stat == "int")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Intelligence + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Intelligence + 1 <= 13 && character.Intelligence >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Intelligence + 1 <= 15 && character.Intelligence >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Intelligence + 1 <= 17 && character.Intelligence >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Intelligence + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Intelligence - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Intelligence - 1 >= 8 && character.Intelligence <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Intelligence - 1 >= 13 && character.Intelligence <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Intelligence - 1 >= 15 && character.Intelligence <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Intelligence == 18)
                        {
                            cost = -4;
                        }
                    }
                }

                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if (amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Intelligence -= 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Intelligence += 1;
                    }


                    label.Text = character.Intelligence.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }

            if (stat == "wis")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Wisdom + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Wisdom + 1 <= 13 && character.Wisdom >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Wisdom + 1 <= 15 && character.Wisdom >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Wisdom + 1 <= 17 && character.Wisdom >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Wisdom + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Wisdom - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Wisdom - 1 >= 8 && character.Wisdom <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Wisdom - 1 >= 13 && character.Wisdom <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Wisdom - 1 >= 15 && character.Wisdom <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Wisdom == 18)
                        {
                            cost = -4;
                        }
                    }
                }

                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if (amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Wisdom -= 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Wisdom += 1;
                    }


                    label.Text = character.Wisdom.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }

            if (stat == "cha")
            {
                int cost = 0;
                if (amount > 0)
                {
                    if (character.Charisma + 1 == 8)
                    {
                        cost = 2;
                    }
                    if (character.Charisma + 1 <= 13 && character.Charisma >= 8)
                    {
                        cost = 1;
                    }
                    if (character.Charisma + 1 <= 15 && character.Charisma >= 13)
                    {
                        cost = 2;
                    }
                    if (character.Charisma + 1 <= 17 && character.Charisma >= 15)
                    {
                        cost = 3;
                    }
                    if (character.Charisma + 1 == 18)
                    {
                        cost = 4;
                    }
                }
                else
                {
                    if (amount < 0)
                    {
                        if (character.Charisma - 1 == 7)
                        {
                            cost = -2;
                        }
                        if (character.Charisma - 1 >= 8 && character.Charisma <= 13)
                        {
                            cost = -1;
                        }
                        if (character.Charisma - 1 >= 13 && character.Charisma <= 15)
                        {
                            cost = -2;
                        }
                        if (character.Charisma - 1 >= 15 && character.Charisma <= 17)
                        {
                            cost = -3;
                        }
                        if (character.Charisma == 18)
                        {
                            cost = -4;
                        }
                    }
                }

                if (character.AttributePoints - cost >= 0 && cost != 0)
                {
                    if (amount < 0)
                    {
                        character.AttributePoints -= cost;
                        character.Charisma -= 1;
                    }
                    else
                    {
                        character.AttributePoints -= cost;
                        character.Charisma += 1;
                    }


                    label.Text = character.Charisma.ToString();
                    title.Text = $"Select Stats\nPoints: {character.AttributePoints}";
                }
            }
        }

        public void CharacterStatsForm(Character character)
        {
            //Variables
            ActiveCharacter = character;
            Form1 form = new Form1();
            Label titleLabel = new Label();
            Button submitButton = new Button();
            Button strPlus = new Button();
            Button strMinus = new Button();
            Label strLabel = new Label();
            Button dexPlus = new Button();
            Button dexMinus = new Button();
            Label dexLabel = new Label();
            Button conPlus = new Button();
            Button conMinus = new Button();
            Label conLabel = new Label();
            Button intPlus = new Button();
            Button intMinus = new Button();
            Label intLabel = new Label();
            Button wisPlus = new Button();
            Button wisMinus = new Button();
            Label wisLabel = new Label();
            Button chaPlus = new Button();
            Button chaMinus = new Button();
            Label chaLabel = new Label();

            //Buttons
            submitButton.Location = new Point(2, 294);
            submitButton.Width = 124;
            submitButton.Height = 40;
            submitButton.Text = "Submit";
            submitButton.BackColor = Color.Black;
            submitButton.ForeColor = Color.White;
            submitButton.Click += new EventHandler(CloseForm);

            strMinus.Location = new Point(2, 42);
            strMinus.Width = 40;
            strMinus.Height = 40;
            strMinus.Text = "-";
            strMinus.BackColor = Color.Black;
            strMinus.ForeColor = Color.White;
            strMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "str", -1, strLabel, titleLabel); };

            strPlus.Location = new Point(86, 42);
            strPlus.Width = 40;
            strPlus.Height = 40;
            strPlus.Text = "+";
            strPlus.BackColor = Color.Black;
            strPlus.ForeColor = Color.White;
            strPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "str", 1, strLabel, titleLabel); };

            dexMinus.Location = new Point(2, 84);
            dexMinus.Width = 40;
            dexMinus.Height = 40;
            dexMinus.Text = "-";
            dexMinus.BackColor = Color.Black;
            dexMinus.ForeColor = Color.White;
            dexMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "dex", -1, dexLabel, titleLabel); };

            dexPlus.Location = new Point(86, 84);
            dexPlus.Width = 40;
            dexPlus.Height = 40;
            dexPlus.Text = "+";
            dexPlus.BackColor = Color.Black;
            dexPlus.ForeColor = Color.White;
            dexPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "dex", 1, dexLabel, titleLabel); };

            conMinus.Location = new Point(2, 126);
            conMinus.Width = 40;
            conMinus.Height = 40;
            conMinus.Text = "-";
            conMinus.BackColor = Color.Black;
            conMinus.ForeColor = Color.White;
            conMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "con", -1, conLabel, titleLabel); };

            conPlus.Location = new Point(86, 126);
            conPlus.Width = 40;
            conPlus.Height = 40;
            conPlus.Text = "+";
            conPlus.BackColor = Color.Black;
            conPlus.ForeColor = Color.White;
            conPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "con", 1, conLabel, titleLabel); };

            intMinus.Location = new Point(2, 168);
            intMinus.Width = 40;
            intMinus.Height = 40;
            intMinus.Text = "-";
            intMinus.BackColor = Color.Black;
            intMinus.ForeColor = Color.White;
            intMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "int", -1, intLabel, titleLabel); };

            intPlus.Location = new Point(86, 168);
            intPlus.Width = 40;
            intPlus.Height = 40;
            intPlus.Text = "+";
            intPlus.BackColor = Color.Black;
            intPlus.ForeColor = Color.White;
            intPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "int", 1, intLabel, titleLabel); };

            wisMinus.Location = new Point(2, 210);
            wisMinus.Width = 40;
            wisMinus.Height = 40;
            wisMinus.Text = "-";
            wisMinus.BackColor = Color.Black;
            wisMinus.ForeColor = Color.White;
            wisMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "wis", -1, wisLabel, titleLabel); };

            wisPlus.Location = new Point(86, 210);
            wisPlus.Width = 40;
            wisPlus.Height = 40;
            wisPlus.Text = "+";
            wisPlus.BackColor = Color.Black;
            wisPlus.ForeColor = Color.White;
            wisPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "wis", 1, wisLabel, titleLabel); };

            chaMinus.Location = new Point(2, 252);
            chaMinus.Width = 40;
            chaMinus.Height = 40;
            chaMinus.Text = "-";
            chaMinus.BackColor = Color.Black;
            chaMinus.ForeColor = Color.White;
            chaMinus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "cha", -1, chaLabel, titleLabel); };

            chaPlus.Location = new Point(86, 252);
            chaPlus.Width = 40;
            chaPlus.Height = 40;
            chaPlus.Text = "+";
            chaPlus.BackColor = Color.Black;
            chaPlus.ForeColor = Color.White;
            chaPlus.Click += (sender, EventArgs) => { StatChange(sender, EventArgs, character, "cha", 1, chaLabel, titleLabel); };

            //Labels
            titleLabel.Location = new Point(3, 3);
            titleLabel.Width = 138;
            titleLabel.Height = 38;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Text = $"Select Stats\nPoints: {character.AttributePoints}";
            titleLabel.BackColor = Color.Black;
            titleLabel.ForeColor = Color.White;
            titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            strLabel.Location = new Point(45, 43);
            strLabel.Width = 38;
            strLabel.Height = 38;
            strLabel.TextAlign = ContentAlignment.MiddleCenter;
            strLabel.Text = character.Strength.ToString();
            strLabel.BackColor = Color.Black;
            strLabel.ForeColor = Color.White;
            strLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            dexLabel.Location = new Point(45, 85);
            dexLabel.Width = 38;
            dexLabel.Height = 38;
            dexLabel.TextAlign = ContentAlignment.MiddleCenter;
            dexLabel.Text = character.Dexterity.ToString();
            dexLabel.BackColor = Color.Black;
            dexLabel.ForeColor = Color.White;
            dexLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            conLabel.Location = new Point(45, 127);
            conLabel.Width = 38;
            conLabel.Height = 38;
            conLabel.TextAlign = ContentAlignment.MiddleCenter;
            conLabel.Text = character.Constitution.ToString();
            conLabel.BackColor = Color.Black;
            conLabel.ForeColor = Color.White;
            conLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            intLabel.Location = new Point(45, 169);
            intLabel.Width = 38;
            intLabel.Height = 38;
            intLabel.TextAlign = ContentAlignment.MiddleCenter;
            intLabel.Text = character.Intelligence.ToString();
            intLabel.BackColor = Color.Black;
            intLabel.ForeColor = Color.White;
            intLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            wisLabel.Location = new Point(45, 211);
            wisLabel.Width = 38;
            wisLabel.Height = 38;
            wisLabel.TextAlign = ContentAlignment.MiddleCenter;
            wisLabel.Text = character.Wisdom.ToString();
            wisLabel.BackColor = Color.Black;
            wisLabel.ForeColor = Color.White;
            wisLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            chaLabel.Location = new Point(45, 253);
            chaLabel.Width = 38;
            chaLabel.Height = 38;
            chaLabel.TextAlign = ContentAlignment.MiddleCenter;
            chaLabel.Text = character.Charisma.ToString();
            chaLabel.BackColor = Color.Black;
            chaLabel.ForeColor = Color.White;
            chaLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //Form Style
            form.BackColor = Color.Black;
            form.Size = new Size(144, 376);

            //Populate Form
            form.Controls.Add(titleLabel);
            form.Controls.Add(submitButton);
            form.Controls.Add(strPlus);
            form.Controls.Add(strLabel);
            form.Controls.Add(strMinus);
            form.Controls.Add(dexPlus);
            form.Controls.Add(dexLabel);
            form.Controls.Add(dexMinus);
            form.Controls.Add(conPlus);
            form.Controls.Add(conLabel);
            form.Controls.Add(conMinus);
            form.Controls.Add(intPlus);
            form.Controls.Add(intLabel);
            form.Controls.Add(intMinus);
            form.Controls.Add(wisPlus);
            form.Controls.Add(wisLabel);
            form.Controls.Add(wisMinus);
            form.Controls.Add(chaPlus);
            form.Controls.Add(chaLabel);
            form.Controls.Add(chaMinus);

            //Show Form
            Application.Run(form);
        }

    }
}
