using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROBOTI_temaOOP
{
    public class Planet
    {
        public float BoostLife { get; set; }
        public int LaserDamage { get; set; }//puterea fiecarui robot pe planeta X
        public Queue<Target> Targets { get; set; }
        public bool ContainsLife
        {
            get
            {
                foreach (Target target in Targets)
                {
                    if (target.IsAlive)
                        return true;
                }
                return false;
            }
        }
        public Planet(Queue<Target> targets)
        {
            Targets = targets;
        }
        public class Earth : Planet
        {
            public Earth(Queue<Target> targets) : base(targets)
            {
                BoostLife = 1;
                LaserDamage = 25;
            }
        }
        public class Mars : Planet
        {
            public Mars(Queue<Target> targets) : base(targets)
            {
                BoostLife = 0.6f;
                LaserDamage = 20;
            }
        }
        public class Jupiter : Planet
        {
            public Jupiter(Queue<Target> targets) : base(targets)
            {
                BoostLife = 2.5f;
                LaserDamage = 55;
            }
        }
        public class Saturn : Planet
        {
            public Saturn(Queue<Target> targets) : base(targets)
            {
                BoostLife = 1.5f;
                LaserDamage = 70;
            }
        }
        public class Uranus : Planet
        {
            public Uranus(Queue<Target> targets) : base(targets)
            {
                BoostLife = 2.0f;
                LaserDamage = 35;
            }
        }
        public class Neptune : Planet
        {
            public Neptune(Queue<Target> targets) : base(targets)
            {
                BoostLife = 1.8f;
                LaserDamage = 32;
            }
        }
        public class Pluto : Planet
        {
            public Pluto(Queue<Target> targets) : base(targets)
            {
                BoostLife = 0.2f;
                LaserDamage = 10;
            }
        }
    }
}
