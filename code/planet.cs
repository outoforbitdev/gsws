////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  planet.cs                                 //
//                                 Planet class                               //
//             Created by: Jarett (Jay) Mirecki, February 27, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 28, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    class Planet {
        public string Name, System, Demonym;
        public int Sector, Region, Class;
        public Faction Faction;
        public Gov Government;
        public int Day, Year, Size, Surface, Population, EconomicRating, 
                   SocialRating, Wealth, Industrialization, Productivity, 
                   Capacity, MaximumCapacity;

        public Planet(string name, Faction faction) {
            Name = name;
            System = name;
            Demonym = name;
            Faction = Faction.GA;
            Sector = 0;
            Region = 0;
            Class = 0;
            Government = new Gov(name, 0, 0);
            Day = Year = Size = Surface = Population = EconomicRating = 
                   SocialRating = Wealth = Industrialization = Productivity = 
                   Capacity = MaximumCapacity = 0;
        }
    }
}