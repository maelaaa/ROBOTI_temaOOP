using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROBOTI_temaOOP
{
    public class Target
    {
        public string Name { get => GetType().ToString().Split('.')[1]; }
        private float _hp;
        public float Health { get => _hp; set => _hp = value; }
        public bool IsAlive { get => _hp > 0; }
    }
    public class Animal : Target
    {
        public Animal(int hp)
        {
            Health = hp;
        }
    }
    public class Human : Target
    {
        public Human(int hp)
        {
            Health = hp;
        }

    }
    public class Superhero : Target
    {
        public Superhero(int hp)
        {
            Health = hp;
        }
    }
}
