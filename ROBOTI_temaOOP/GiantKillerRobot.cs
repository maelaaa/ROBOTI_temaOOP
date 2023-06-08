using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROBOTI_temaOOP
{
    public class GiantKillerRobot
    {
        public int TotalShots { get; private set; } = 0;
        public int EyeLaserDamage { get; private set; }
        public bool Active { get; set; } = false;
        public Target CurrentTarget { get; set; }
        public List<Planet> MissionDestinations { get; private set; }
        public Planet CurrentDestination { get; set; }

        public GiantKillerRobot(List<Planet> missionDestinations)
        {
            Active = true;
            MissionDestinations = missionDestinations;
        }

        public void InitializeFor(Planet planet)
        {
            Console.WriteLine($"Initializing Giant Killer Robot on {planet.GetType().ToString().Split('.')[1]}...");
            CurrentDestination = planet;
            CurrentTarget = planet.Targets.First();
            EyeLaserDamage = planet.LaserDamage;
            //hp multiplier
            foreach (Target target in planet.Targets)
            {
                target.Health *= planet.BoostLife;
            }

        }

        public void FireLaserAt(Target target)
        {
            Console.WriteLine($"Shooting laser at {target.Name}...");
            target.Health -= EyeLaserDamage;
            TotalShots++;
        }

        public void AcquireNextTarget()
        {
            Console.WriteLine();
            Console.WriteLine($"Acquiring next target...");
            Console.WriteLine();

            CurrentDestination.Targets.Dequeue();
            CurrentTarget = CurrentDestination.Targets.First();
        }
    }
}
