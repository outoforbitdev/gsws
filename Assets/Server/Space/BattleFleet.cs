using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;
using System.Runtime.InteropServices;

namespace GSWS.Assets.Server
{
    public class BattleFleet
    {
        private Fleet Fleet;

        private List<Ship> Fighters;
        private List<Ship> Cruisers;
        private List<Ship> Destroyers;

        public int Count
        {
            get
            {
                return Fighters.Count + Cruisers.Count + Destroyers.Count;
            }
        }


        public Ship this[int i]
        {
            get
            {
                if (i < Fighters.Count)
                {
                    return Fighters[i];
                } 
                else if (i < Fighters.Count + Cruisers.Count)
                {
                    return Cruisers[i - Fighters.Count];
                } 
                else if (i < Count)
                {
                    return Destroyers[i - Fighters.Count - Cruisers.Count];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Remove(Ship ship)
        {
            if (!Fighters.Remove(ship))
            {
                if (!Cruisers.Remove(ship))
                {
                    Destroyers.Remove(ship);
                }
            }
        }

        public BattleFleet(Fleet fleet)
        {
            Fighters = new List<Ship>();
            Cruisers = new List<Ship>();
            Destroyers = new List<Ship>();

            Fleet = fleet;
            foreach (Ship ship in Fleet.Ships)
            {
                switch (ship.Model.Class)
                {
                    case ShipClass.Interceptor:
                    case ShipClass.Fighter:
                    case ShipClass.Bomber:
                        Fighters.Add(ship);
                        break;
                    case ShipClass.Corvette:
                    case ShipClass.Frigate:
                    case ShipClass.LightCruiser:
                    case ShipClass.HeavyCruiser:
                        Cruisers.Add(ship);
                        break;
                    case ShipClass.Destroyer:
                    case ShipClass.Battlecruiser:
                    case ShipClass.Dreadnought:
                        Destroyers.Add(ship);
                        break;
                }
            }
        }

        public void Reset()
        {
            for (int i = 0; i < Count; i++)
            {
                this[i].Reset();
            }
        }

        public void Attack(BattleFleet defender)
        {
            for (int j = 0; j < 10; j++)
            {
                Shuffle();
                defender.Shuffle();

                for (int i = 0; i < Math.Max(Count, defender.Count); i++)
                {
                    if (i < Count)
                    {
                        Ship shipA = this[i];
                        shipA.Reload();
                        Ship shipB = shipA.Attack(defender);
                        if (shipA.HullStrength == 0)
                        {
                            Remove(shipA);
                            WriteDestroyed(shipA);
                        }
                        if (shipB?.HullStrength == 0)
                        {
                            defender.Remove(shipB);
                            WriteDestroyed(shipB);
                        }
                    }
                    if (i < defender.Count)
                    {
                        Ship shipB = defender[i];
                        shipB.Reload();
                        Ship shipA = shipB.Attack(this);
                        if (shipB.HullStrength == 0)
                        {
                            Remove(shipB);
                            WriteDestroyed(shipB);
                        }
                        if (shipA?.HullStrength == 0)
                        {
                            defender.Remove(shipA);
                            WriteDestroyed(shipA);
                        }
                    }
                }
            }
        }

        private static void WriteDestroyed(Ship ship)
        {
            Console.WriteLine(ship.ToString() + " Destroyed");
        }

        public bool TrySurrender()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }

        public void Shuffle()
        {
            Shuffle(Fighters);
            Shuffle(Cruisers);
            Shuffle(Destroyers);
        }

        public static void Shuffle(List<Ship> ships)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                Ship shipA = ships[i];
                Random rnd = new Random();
                int j = rnd.Next(i, ships.Count);
                ships[i] = ships[j];
                ships[j] = shipA;
            }
        }

        private static bool _getShip(List<Ship> ships, out Ship ship)
        {
            if (ships.Count == 0)
            {
                ship = default;
                return false;
            }
            ship = ships[new Random().Next(0, ships.Count)];
            return true;
        }
        public bool TryGetFighter(out Ship fighter)
        {
            return _getShip(Fighters, out fighter);
        }
        public bool TryGetCruiser(out Ship cruiser)
        {
            return _getShip(Cruisers, out cruiser);
        }
        public bool TryGetDestroyer(out Ship destroyer)
        {
            return _getShip(Destroyers, out destroyer);
        }
    }
}
