using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSWS.Assets.Server;
using System.Collections.Generic;

namespace GSWS.Assets.Tests.Server
{
    [TestClass]
    public class BattleTest
    {
        [TestMethod]
        public void FirstBattleTest()
        {
            WeaponModel xLaser = new WeaponModel()
            {
                ID = "xLaser",
                Name = "Taim & Bak KX9 laser cannon",
                Damage = 10,
                Accuracy = 1,
                Capacity = 0,
                ReloadTimer = 1
            };
            WeaponModel tLaser = new WeaponModel()
            {
                ID = "tLaser",
                Name = "L-s1 laser cannon",
                Damage = 10,
                Accuracy = 1,
                Capacity = 0,
                ReloadTimer = 1
            };
            WeaponModel torpedo = new WeaponModel()
            {
                ID = "torpedo",
                Name = "Krupx MG7 proton torpedo launcher",
                Damage = 10,
                Accuracy = 1,
                Capacity = 3,
                ReloadTimer = 10
            };

            ShipModel xWingModel = new ShipModel()
            {
                ID = "xwing",
                Name = "T-65 X-Wing Starfighter",
                Class = ShipClass.Fighter,
                OffensiveWeapons = new List<WeaponModel>() { xLaser, xLaser, xLaser, xLaser, torpedo, torpedo },
                Shields = 100,
                HullStrength = 100
            };
            ShipModel tieModel = new ShipModel()
            {
                ID = "tie",
                Name = "TIE/LN Starfighter",
                Class = ShipClass.Fighter,
                OffensiveWeapons = new List<WeaponModel>() { tLaser, tLaser },
                Shields = 0,
                HullStrength = 100
            };

            Ship xWing = new Ship()
            {
                ID = "xWing",
                Name = "X-Wing",
                Model = xWingModel,
            };
            Ship tie = new Ship()
            {
                ID = "tie",
                Name = "TIE Fighter",
                Model = tieModel,
            };

            Fleet rebelFleet = new Fleet();
            rebelFleet.Ships.Add(xWing);
            Fleet impFleet = new Fleet();
            impFleet.Ships.Add(tie);

            BattleFleet rebels = new BattleFleet(rebelFleet);
            BattleFleet imps = new BattleFleet(impFleet);

            rebels.Reset();
            rebels.Attack(imps);
        }
    }
}
