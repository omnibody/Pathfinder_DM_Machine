using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Pathfinder
{
    public abstract class IJobs
    {
        public abstract string Name { get; }
        public abstract int Level { get; set; }
        public abstract int MovementMod { get; }
        public abstract ArrayList BaseAttackBonus { get; }
        public abstract ArrayList BonusFeatLevels { get; }
        public abstract int FortitudeSaveBase { get; }
        public abstract int ReflexSaveBase { get; }
        public abstract int WillSaveBase { get; }

        public int GoodSave(int level)
        {
            return (int)Math.Floor((double)(level + 4) / 2);
        }

        public int PoorSave(int level)
        {
            return (int)Math.Floor((double)level / 3);
        }

        public ArrayList FastBaseAttackBonus(int level)
        {
            ArrayList bab = new ArrayList();
            bab.Add(level);
            if (level >= 6)
            {
                bab.Add(level - 5);
                if (level >= 11)
                {
                    bab.Add(level - 10);
                    if (level >= 16)
                    {
                        bab.Add(level - 15);
                    }
                }
            }
            return bab;
        }

        public ArrayList MediumBaseAttackBonus(int level)
        {
            ArrayList bab = new ArrayList();
            bab.Add((int)Math.Floor((double)level * 0.75));
            if ((int)Math.Floor((double)level * 0.75) >= 6)
            {
                bab.Add((int)Math.Floor((double)level * 0.75) - 5);
                if ((int)Math.Floor((double)level * 0.75) >= 11)
                {
                    bab.Add((int)Math.Floor((double)level * 0.75) - 10);
                }
            }
            return bab;
        }

        public ArrayList SlowBaseAttackBonus(int level)
        {
            ArrayList bab = new ArrayList();
            bab.Add((int)Math.Floor((double)level * 0.5));
            if ((int)Math.Floor((double)level * 0.5) >= 6)
            {
                bab.Add((int)Math.Floor((double)level * 0.5) - 5);
            }
            return bab;
        }
    }



    public class Fighter : IJobs
    {

        //core
        public override string Name { get { return "Fighter"; } }
        public override int Level { get { return this.level; } set { this.level = value; } }
        int level = 1;
        public override int MovementMod { get { return this.movementMod; } }
        int movementMod = 0;
        public override ArrayList BaseAttackBonus { get { return FastBaseAttackBonus(this.level); } }
        public override int FortitudeSaveBase { get { return GoodSave(this.level); } }
        public override int ReflexSaveBase { get { return PoorSave(this.level); } }
        public override int WillSaveBase { get { return PoorSave(this.level); } }
        public override ArrayList BonusFeatLevels { get 
            {
                ArrayList bonusFeatLevels = new ArrayList();
                bonusFeatLevels.Add(1);
                bonusFeatLevels.Add(2);
                bonusFeatLevels.Add(4);
                bonusFeatLevels.Add(6);
                bonusFeatLevels.Add(8);
                bonusFeatLevels.Add(10);
                bonusFeatLevels.Add(12);
                bonusFeatLevels.Add(14);
                bonusFeatLevels.Add(16);
                bonusFeatLevels.Add(18);
                bonusFeatLevels.Add(20);
                return bonusFeatLevels; 
            } 
        }

        //attributes bonus
        int strengthBonus = 0;
        int dexterityBonus = 0;
        int constitutionBonus = 0;
        int intelligenceBonus = 0;
        int wisdomBonus = 0;
        int charismaBonus = 0;

        //skill bonus
        int athleticsBonus = 0;
        int appraiseBonus = 0;
        int craftBonus = 0;
        int disableDiviceBonus = 0;
        int disguiseBonus = 0;
        int escapeArtistBonus = 0;
        int handleAnimalBonus = 0;
        int healBonus = 0;
        int knowledgeArcaneBonus = 0;
        int knowledgeDungeoneeringBonus = 0;
        int knowledgeEngineeringBonus = 0;
        int knowledgeGeographyBonus = 0;
        int knowledgeHistoryBonus = 0;
        int knowledgeLocalBonus = 0;
        int knowledgeNatureBonus = 0;
        int knowledgeNobilityBonus = 0;
        int knowledgePlanesBonus = 0;
        int knowledgeReligionBonus = 0;
        int linguisticsBonus = 0;
        int perceptionBonus = 0;
        int performBonus = 0;
        int professionBonus = 0;
        int senseMotiveBonus = 0;
        int slightOfHandBonus = 0;
        int socialBonus = 0;
        int spellcraftBonus = 0;
        int stealthBonus = 0;
        int survivalBonus = 0;
        int useMagicDeviceBonus = 0;

        //job skill
        bool athletics = false;
        bool appraise = false;
        bool craft = false;
        bool disableDivice = false;
        bool disguise = false;
        bool escapeArtist = false;
        bool handleAnimal = false;
        bool heal = false;
        bool knowledgeArcane = false;
        bool knowledgeDungeoneering = false;
        bool knowledgeEngineering = false;
        bool knowledgeGeography = false;
        bool knowledgeHistory = false;
        bool knowledgeLocal = false;
        bool knowledgeNature = false;
        bool knowledgeNobility = false;
        bool knowledgePlanes = false;
        bool knowledgeReligion = false;
        bool linguistics = false;
        bool perception = false;
        bool perform = false;
        bool profession = false;
        bool senseMotive = false;
        bool slightOfHand = false;
        bool social = false;
        bool spellcraft = false;
        bool stealth = false;
        bool survival = false;
        bool useMagicDevice = false;

        public Fighter()
        {
            
        }

    }  

}
