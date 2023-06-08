using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ROBOTI_temaOOP.Planet;

namespace ROBOTI_temaOOP
{
    /// <summary>
    /// Se dau mai multe planete, fiecare planeta are un boostLife pentru fiintele/robotii de pe ea, care e predefinit
    /// Pe prima linie a fiserului va fi numarul de planete, viata animalului, viata robotului si viata supereroului, care sunt constante si se schimba pe 
    /// fiecare planeta in functie de boost life
    /// De asemenea puterea fiecarui robot difera in functie de planeta
    /// Programul numara de cate lovituri de laser e nevoie ca sa fie exterminata toata viata de pe fiecare planeta
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines(@"..\..\input.txt");
            //parsing the first line
            List<Planet> planets = new List<Planet>(int.Parse(inputLines[0].Split(' ')[0]));//cate tipuri de planeta avem

            int animalHP = int.Parse(inputLines[0].Split(' ')[1]);
            int humanHP = int.Parse(inputLines[0].Split(' ')[2]);
            int superheroHP = int.Parse(inputLines[0].Split(' ')[3]);

            Tuple<int, int, int> targetsHP = new Tuple<int, int, int>(animalHP, humanHP, superheroHP);
            //parsing data for each planet
            for (int i = 1; i < inputLines.Length; i++)
            {
                string[] line = inputLines[i].Split(' ');
                Queue<Target> planetTargets = new Queue<Target>();
                for (int j = 1; j < line.Length; j++)
                {
                    switch (line[j])
                    {
                        case "A":
                            planetTargets.Enqueue(new Animal(targetsHP.Item1));
                            break;
                        case "H":
                            planetTargets.Enqueue(new Human(targetsHP.Item2));
                            break;
                        case "S":
                            planetTargets.Enqueue(new Superhero(targetsHP.Item3));
                            break;
                        default:
                            throw new Exception("Doesn't exist");
                    }
                }
                switch (line[0])
                {
                    case "E":
                        planets.Add(new Earth(planetTargets));
                        break;
                    case "M":
                        planets.Add(new Mars(planetTargets));
                        break;
                    case "J":
                        planets.Add(new Jupiter(planetTargets));
                        break;
                    case "S":
                        planets.Add(new Saturn(planetTargets));
                        break;
                    case "U":
                        planets.Add(new Uranus(planetTargets));
                        break;
                    case "N":
                        planets.Add(new Neptune(planetTargets));
                        break;
                    case "P":
                        planets.Add(new Pluto(planetTargets));
                        break;
                    default:
                        throw new Exception("Invalid planet type");
                }
            }

            //starting the game

            GiantKillerRobot robot = new GiantKillerRobot(planets);

            foreach (Planet planet in robot.MissionDestinations)
            {
                robot.InitializeFor(planet);
                while (robot.Active && robot.CurrentDestination.ContainsLife)
                {
                    if (robot.CurrentTarget.IsAlive)
                    {
                        robot.FireLaserAt(robot.CurrentTarget);
                    }
                    else
                    {
                        robot.AcquireNextTarget();
                    }
                }
            }

            //output
            Console.WriteLine();

            Console.WriteLine($"Shots Needed: {robot.TotalShots}");
            File.WriteAllText(@"../../../output.txt", robot.TotalShots.ToString());
        }
    }
}
