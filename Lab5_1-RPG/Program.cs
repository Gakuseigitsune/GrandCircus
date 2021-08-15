using System;
using System.Collections.Generic;
using System.Threading;


namespace Lab5_1_RPG
{

    class GameCharacter
    {
        private string Name;
        private int Strength;
        private int Intelligence;


        

        public GameCharacter() { }

        public GameCharacter(string Name, int Strength, int Intelligence)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Intelligence = Intelligence;

        }

        public void SetName(string Name) => this.Name = Name;
        public void SetStrength(int Strength) => this.Strength = Strength;
        public void SetIntelligence(int Intelligence) => this.Intelligence = Intelligence;


        public string GetName() => Name;
        public int GetStrength() => Strength;
        public int GetIntelligence() => Intelligence;





        public virtual void Play()
        {
            Console.WriteLine("\n NAME: {0}\n INTELLIGENCE: {1}\n STRENGTH: {2}", GetName(), GetIntelligence(), GetStrength());

        }


    }
    class Warrior : GameCharacter
    {
        private string WeaponType;

        public Warrior() { }

        public Warrior(string Name, int Strength, int Intelligence, string WeaponType)
        {
            SetName(Name);
            SetStrength(Strength);
            SetIntelligence(Intelligence);
            this.WeaponType = WeaponType;


        }

        public string GetWeaponType() => WeaponType;

        public override void Play()
        {
            Console.WriteLine("\n NAME: {0}\n INTELLIGENCE: {1}\n STRENGTH {2}\n WEAPON TYPE: {3}", GetName(), GetIntelligence(), GetStrength(), GetWeaponType() );

        }


    }

    class MagicUsingCharacter : GameCharacter
    {
        private int MagicalEnergy;

        public MagicUsingCharacter() { }

        public MagicUsingCharacter(string Name, int Strength, int Intelligence, int MagicalEnergy)
        {
            SetName(Name);
            SetStrength(Strength);
            SetIntelligence(Intelligence);
            SetMagicalEnergy(MagicalEnergy);


        }


        public void SetMagicalEnergy(int MagicalEnergy) => this.MagicalEnergy = MagicalEnergy;

        public int GetMagicalEnergy() => MagicalEnergy;

        public override void Play()
        {

            Console.WriteLine("\n NAME: {0}\n INTELLIGENCE: {1}\n STRENGTH: {2}\n MAGIC_ENERGY: {3}", GetName(), GetIntelligence(), GetStrength(), GetMagicalEnergy());

        }

    }

    class Wizard : MagicUsingCharacter
    {
        private int SpellNumber;



        public Wizard() { }
       

        public Wizard(string Name, int Strength, int Intelligence, int MagicalEnergy, int SpellNumber)
        {
            SetName(Name);
            SetStrength(Strength);
            SetIntelligence(Intelligence);
            SetMagicalEnergy(MagicalEnergy);

            this.SpellNumber = SpellNumber;


        }

        public override void Play()
        {
            Console.WriteLine("\n NAME: {0}\n INTELLIGENCE: {1}\n STRENGTH: {2}\n MAGIC_ENERGY: {3}\n SPELL COUNT: {4}", GetName(), GetIntelligence(), GetStrength(), GetMagicalEnergy(), SpellNumber);

        }

    }



    class Program
    {


        static List<GameCharacter> spawnChars(int numWarrior, int numWizard, Random r)
        {

            List<GameCharacter> roster = new List<GameCharacter>();


            for (int i = 0; i < numWarrior; i++)
            {
                Warrior wr = new Warrior($"WARRIOR {i}", r.Next(101), r.Next(75), $"weapon{i}");
                roster.Add(wr);


            }

            for (int j = 0; j < numWizard; j++)
            {

                Wizard wz = new Wizard($"WIZARD {j}", r.Next(60), r.Next(75), r.Next(200), r.Next(7));
                roster.Add(wz);


            }

            Console.WriteLine("\nroster created!");

            return roster;
        }



        static void Main(string[] args)
        {
          
            Random r = new Random();


            List<GameCharacter> roster = spawnChars(2, 3, r);

            Thread.Sleep(1200);

            foreach (GameCharacter g_char in roster)
            {
                g_char.Play();

                Thread.Sleep(350);




            }

            Console.WriteLine("\n(End of list)");

        }
    }
}
