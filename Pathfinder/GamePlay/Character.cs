﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Pathfinder
{
    public class Character
    {


        //core
        String name = "";
        String description = "";
        int level = 1;
        ArrayList job = new ArrayList();
        object race = null;
        String gender = "";
        int exp = 0;
        int expMax = 2000;
        int skillRanks = 0;
        int hpMax = 0;
        int hp = 0;

        //attributes
        int strenth = 10;
        int strengthFeatBonus = 0;
        int dexterity = 10;
        int constitution = 10;
        int wisdom = 10;
        int intelligence = 10;
        int charisma = 10;
        int attributePoints = 15;

        public int StrengthMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.strenth - 10) / 2));
        }
        public int DexterityMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.dexterity - 10) / 2));
        }
        public int ConstitutionMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.constitution - 10) / 2));
        }
        public int WisdomMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.wisdom - 10) / 2));
        }

        public int IntelligenceMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.intelligence - 10) / 2));
        }

        public int CharismaMod()
        {
            return Convert.ToInt32(Math.Floor(((double)this.charisma - 10) / 2));
        }

        int fortitude = 0;
        int reflex = 0;
        int will = 0;

        //Combat Stats
        ArrayList baseAttackBonus = new ArrayList();
        int initiative = 0;
        int combatManeuverBonus = 0;
        int combatManeuverDefence = 0;
        int armorClass = 10;
        int touchAC = 10;
        int flatFootedAC = 10;
        int speed = 30;
        int damageReduction = 0;
        int spellResistance = 0;
        
        Array skills;

        //equipment
        object body;
        object ring1;
        object ring2;
        object head;
        object feet;
        object hands;
        object arms;
        object neck;
        object shoulders;
        object belt;
        object eyes;
        object headband;
        object mainHand;
        object offHand;

        //General
        int copper = 0;
        int silver = 0;
        int gold = 0;
        ArrayList items = new ArrayList();

        //Settings
        public int difficulty = 2;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        public ArrayList Job
        {
            get { return this.job; }
            set { this.job.Add(value); }
        }

        public ArrayList BaseAttackBonus
        {
            get {
                ArrayList bab = new ArrayList();
                for (int i = 0; i < this.job.Count; i++)
                {
                    IJobs job = (IJobs)this.job[i];
                    for (int ii = 0; ii < job.BaseAttackBonus.Count; ii++)
                    {
                        if (bab.Count > ii)
                        {
                            int babii = Convert.ToInt32(bab[ii]);
                            babii += Convert.ToInt32(job.BaseAttackBonus[ii]);
                            bab[ii] = babii;
                        }
                        else
                        {
                            bab.Add(Convert.ToInt32(job.BaseAttackBonus[ii]));
                        }
                    }
                }
                this.baseAttackBonus = bab;
                return bab;

            }
            //set { this.baseAttackBonus = value; }
        }

        public int AttributePoints
        {
            get { return this.attributePoints; }
            set { this.attributePoints = value; }
        }

        public int Initiative
        {
            get { return this.initiative;  }
            set { this.initiative = value; }
        }

        public int Strength
        {
            get { return this.strenth; }
            set { this.strenth = value; }
        }

        public int StrengthFeatBonus
        {
            get { return this.strengthFeatBonus; }
            set { this.strengthFeatBonus = value; }
        }

        public int Dexterity
        {
            get { return this.dexterity; }
            set { this.dexterity = value; }
        }

        public int Constitution
        {
            get { return this.constitution; }
            set { this.constitution = value; }
        }

        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }

        public int Wisdom
        {
            get { return this.wisdom; }
            set { this.wisdom = value; }
        }

        public int Charisma
        {
            get { return this.charisma; }
            set { this.charisma = value; }
        }

        public ArrayList feats = new ArrayList();

        public ArrayList Feats
        {
            get { return this.feats; }
            set { this.feats.Add(value); }
        }

        public void CalculateStats()
        {
            //Calc Level
            int level = 0;
            for (int i = 0; i < this.job.Count; i++)
            {
                IJobs job = (IJobs)this.job[i];
                level += job.Level;
            }
            this.level = level;

            //Calc BAB
            ArrayList bab = new ArrayList();
            for (int i = 0; i < this.job.Count; i++)
            {
                IJobs job = (IJobs)this.job[i];
                for (int ii = 0; ii < job.BaseAttackBonus.Count; ii++)
                {
                    if (bab.Count > ii)
                    {
                        int babii = Convert.ToInt32(bab[ii]);
                        babii += Convert.ToInt32(job.BaseAttackBonus[ii]);
                        bab[ii] = babii;
                    }
                    else
                    {
                        bab.Add(Convert.ToInt32(job.BaseAttackBonus[ii]));
                    }
                }
            }
            this.baseAttackBonus = bab;

            //Calc Saves
            int fort = 0;
            for (int i = 0; i < this.job.Count; i++)
            {
                IJobs job = (IJobs)this.job[i];
                fort += job.FortitudeSaveBase;
            }
            fort += this.ConstitutionMod();
            this.fortitude = fort;

            int reflex = 0;
            for (int i = 0; i < this.job.Count; i++)
            {
                IJobs job = (IJobs)this.job[i];
                fort += job.ReflexSaveBase;
            }
            reflex += this.DexterityMod();
            this.reflex = reflex;

            int will = 0;
            for (int i = 0; i < this.job.Count; i++)
            {
                IJobs job = (IJobs)this.job[i];
                will += job.WillSaveBase;
            }
            will += this.WisdomMod();
            this.will = reflex;

            //Calc Feats
            for(int i = 0; i < Feats.Count; i++)
            {
                this.strengthFeatBonus = 0;
                IFeats runFeat = (IFeats)this.feats[i];
                runFeat.Execute(this);
            }
        }

        public void CalulateExp(int exp)
        {
            CalculateStats();
            this.exp += exp;
            if (this.exp >= this.expMax)
            {
                int power = (int)Math.Floor(((double)this.level + 2) / 2);
                int nextExp = Convert.ToInt32(Math.Pow(2, power)) * 1000;

                if (((this.level+2) % 2) > 0)
                {
                    nextExp = Convert.ToInt32((double)nextExp * 1.5);

                }

                int num = this.expMax + nextExp;

                if (this.level >= 8)
                {
                    if ((num % 5000) > 2000)
                    {
                        num = num + (5000 - (num % 5000));
                    }
                    else
                    {
                        num = num - (num % 5000);
                    }
                }

                this.expMax = num;
                LevelUp();
            }

        }

        public void LevelUp()
        {
            Console.Clear();
            GUI.Title("PATHFINDER");

            GUI.Anouncement("Active Character: " + this.name);

            GUI.MenuTitle("Level Up");

            if (this.job.Count > 0)
            {
                for (int i = 0; i < this.job.Count; i++)
                {
                    IJobs job = (IJobs)this.job[i];
                    GUI.MenuOption(i, job.Name);
                }
                bool LevelUp = true;
                while (LevelUp == true)
                {
                    int input = GUI.GetInputInt("Please select a job to level up");

                    if (input < this.Job.Count && input >= 0)
                    {

                        IJobs job = (IJobs)this.Job[input];
                        job.Level += 1;
                        CalculateStats();
                        LevelUp = false;
                    }
                    else
                    {
                        GUI.Anouncement("Invalid Input");
                    }
                }
            }
            else
            {
                GUI.Anouncement($"Error: Character: {this.name} has no jobs");
            }
            
        }


        public Character()
        {

        }

        public override string ToString()
        {
            this.CalculateStats();
            String bab = "";
            for (int i = 0; i < this.baseAttackBonus.Count; i++)
            {
                bab += this.baseAttackBonus[i];
                if(i+1 < this.baseAttackBonus.Count)
                {
                    bab += "/";
                }
            }
            String str = 
                $"Name: \t\t{this.name}\n" +
                $"Description: \t{this.description}\n" +
                $"Level: \t\t{this.level}\n" +
                $"Exp: \t\t{this.exp}/{this.expMax}\n" +
                $"Strength: \t{this.strenth + this.strengthFeatBonus}\n" +
                $"Dexterity: \t{this.Dexterity}\n" +
                $"Constitution: \t{this.Constitution}\n" +
                $"Intelligence: \t{this.Intelligence}\n" +
                $"Wisdom: \t{this.Wisdom}\n" +
                $"Charisma: \t{this.Charisma}\n" +
                $"BAB: \t\t" + bab + "\n" +
                $"Fort: \t\t{this.fortitude}\n" +
                $"Ref: \t\t{this.reflex}\n" +
                $"Will: \t\t{this.will}"; 

            return str;
        }

    }
}
