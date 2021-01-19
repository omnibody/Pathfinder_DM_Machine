using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder
{
    public abstract class IFeats
    {

        public virtual void Execute(Character character)
        {

        }
    }

    public class TestFeat : IFeats
    {
        public override void Execute(Character character)
        {
            //character.StrengthFeatBonus += 100;
        }

        public TestFeat()
        {

        }
    }

}
