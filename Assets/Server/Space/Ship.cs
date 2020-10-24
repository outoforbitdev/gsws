////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   Ship.cs                                  //
//                                 Ship class                                 //
//             Created by: Jarett (Jay) Mirecki, October 16, 2019             //
//             Modified by: Jarett (Jay) Mirecki, October 16, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GSWS.Assets.Server
{

    [Serializable]
    public class Ship : Object
    {
        public string kModel;
        [XmlIgnore]
        public ShipModel Model;
        public string Name;
        public List<string> kComplement, kPassengers, kAssociatedUnits, kCommanders;
        public List<Ship> Complement;
        public int Shields, HullStrength;
        public List<Weapon> OffensiveWeapons, DefensiveWeapons;

        #region Object Methods
        public override string DatapadDescription()
        {
            return Name;
        }
        public override string ToString()
        {
            return Name;
        }
        public override void UpdateKeys()
        {
            
        }
        public override void UpdateSuperGroups()
        {
            
        }
        public override void UpdateValues(Database db)
        {
            
        }
        public override void VerifySubGroups()
        {
            
        }
        #endregion

        public Ship()
        {
            Name = kModel = "";
            kComplement = new List<string>();
            kPassengers = new List<string>();
            kAssociatedUnits = new List<string>();
            kCommanders = new List<string>();
            Complement = new List<Ship>();
            Shields = HullStrength = 0;
            OffensiveWeapons = new List<Weapon>();
            DefensiveWeapons = new List<Weapon>();
        }

        public void Reset()
        {
            Shields = Model.Shields;
            HullStrength = Model.HullStrength;
            OffensiveWeapons = new List<Weapon>();
            DefensiveWeapons = new List<Weapon>();
            foreach (WeaponModel wm in Model.OffensiveWeapons)
            {
                OffensiveWeapons.Add(new Weapon(wm));
            }
            foreach (WeaponModel wm in Model.DefensiveWeapons)
            {
                DefensiveWeapons.Add(new Weapon(wm));
            }
        }

        public void Reload()
        {
            Shields = Math.Min(Shields + 1, Model.Shields);
            foreach (Weapon weapon in OffensiveWeapons)
            {
                weapon.Reload();
            }
            foreach (Weapon weapon in DefensiveWeapons)
            {
                weapon.Reload();
            }
        }
        public Ship Attack(BattleFleet defender)
        {
            Ship shipB = _getEnemy(defender);
            if (shipB == null)
            {
                return null;
            }

            float damage = 0;
            foreach (Weapon weapon in OffensiveWeapons)
            {
                damage += weapon.Fire();
            }
            shipB.Defend(this, damage);
            return shipB;
        }
        public void Defend(Ship shipA, float damage)
        {
            Damage(damage);
        }

        public void Damage(float damage)
        {
            if (damage > Shields)
            {
                damage -= Shields;
                Shields = 0;
                HullStrength = Math.Max(0, HullStrength - (int)damage);
            }
            else
            {
                Shields -= (int)damage;
            }
        }

        private Ship _getEnemy(BattleFleet defender)
        {
            Ship shipB = null;
            switch (Model.Class)
            {
                case ShipClass.Interceptor:
                case ShipClass.Corvette:
                case ShipClass.Frigate:
                    if (!defender.TryGetFighter(out shipB))
                    {
                        if (!defender.TryGetCruiser(out shipB))
                        {
                            defender.TryGetDestroyer(out shipB);
                        }
                    }
                    break;
                case ShipClass.Fighter:
                case ShipClass.LightCruiser:
                    if (!defender.TryGetCruiser(out shipB))
                    {
                        if (!defender.TryGetFighter(out shipB))
                        {
                            defender.TryGetDestroyer(out shipB);
                        }
                    }
                    break;
                case ShipClass.HeavyCruiser:
                case ShipClass.Destroyer:
                case ShipClass.Battlecruiser:
                case ShipClass.Dreadnought:
                    if (!defender.TryGetDestroyer(out shipB))
                    {
                        if (!defender.TryGetCruiser(out shipB))
                        {
                            defender.TryGetFighter(out shipB);
                        }
                    }
                    break;
            }
            return shipB;
        }
    }
}