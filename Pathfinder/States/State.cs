using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Pathfinder
{
    class State
    {
        protected Stack<State> states;
        protected bool end = false;
        public State(Stack<State> states)
        {
            this.states = states;
        }

        public bool RequestEnd()
        {
            return this.end;
        }

        virtual public void Update()
        {

        }


    }
}
