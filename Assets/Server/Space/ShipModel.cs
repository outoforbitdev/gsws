////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                ShipModel.cs                                //
//                               ShipModel class                              //
//            Created by: Jarett (Jay) Mirecki, September 02, 2019            //
//            Modified by: Jarett (Jay) Mirecki, October 16, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace GSWS.Assets.Server
{

    public enum ShipClass { Interceptor, Fighter, Bomber, Corvette, Frigate, LightCruiser, HeavyCruiser, Destroyer, Battlecruiser, Dreadnought }

    [Serializable]
    public class ShipModel
    {
        [XmlAttribute] public string ID;
        public string Name, Manufacturer;
        public float HyperdriveRating, Price, Crew;
        public ShipClass Class;
        public List<WeaponModel> OffensiveWeapons, DefensiveWeapons;
        public int Complement, Passengers, Speed, Acceleration, Shields, HullStrength;

        void InitInstance()
        {
            ID = Name = Manufacturer = "";
            HyperdriveRating = Price = Crew = 0f;
            OffensiveWeapons = new List<WeaponModel>();
            DefensiveWeapons = new List<WeaponModel>();
            Complement = Passengers = Speed = Acceleration = Shields = HullStrength = 0;
            Class = ShipClass.Corvette;
        }
        public ShipModel()
        {
            InitInstance();
            ShipClass x = Class;
        }
        public ShipModel(string id, string name, ShipClass shipClass, List<WeaponModel> weapons, int shields, int hullStrength)
        {
            ID = id;
            Name = name;
            Class = shipClass;
            OffensiveWeapons = weapons;
            Shields = shields;
            HullStrength = hullStrength;
        }
    }
}