using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pathfinder
{
    class Game
    {
        //variables
        
        private bool end;
        public bool End
        {
            get { return this.end; }
            set { this.end = value; }
        }

        private Stack<State> states;
        private ArrayList charaterList;

        //private functions

        private void initVariables()
        {
            this.end = false;
        }

        private void initCharacterList()
        {
            this.charaterList = new ArrayList();
        }

        private void initStates()
        {
            this.states = new Stack<State>();

            //Push the first state
            this.states.Push(new StateMainMenu(this.states, this.charaterList));
        }

        //Constructors and Destructors
        public Game()
        {
            this.initVariables();
            this.initCharacterList();
            this.initStates();
            //Application.Run(new Form1());
        }

        public void Run()
        {
            while(this.states.Count > 0)
            {

                this.states.Peek().Update();

                if (this.states.Peek().RequestEnd())
                    this.states.Pop();
 
            }

            Console.WriteLine("Ending...");
        }

    }
}
