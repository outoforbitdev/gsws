////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  planet.cs                                 //
//                                 Planet class                               //
//             Created by: Jarett (Jay) Mirecki, February 27, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 04, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    public struct Vector3 { int X, Y, Z;
                            public Vector3(int x, int y, int z) {
                                X = x; Y = y; Z = z; }
                            public Vector3(string encodedVector) {
                                string one = encodedVector;
                                string two, x, y, z;

                                Parse.FirstPair(one, "X", out x, out two);
                                Parse.FirstPair(two, "Y", out y, out one);
                                Parse.FirstPair(one, "Z", out z, out two);

                                X = Math.Parse(x);
                                Y = Math.Parse(y);
                                Z = Math.Parse(z);
                            }
                            public string Encode() {
                                return "{\"X\": \"" + X.ToString()
                                        + "\", \"Y\": \"" + Y.ToString()
                                        + "\", \"X\": \"" + Y.ToString()
                                        + "\"}"; } }
    class Planet {
        public string Name, System, Demonym, Government;
        public Vector3 Coordinates;
        public Sector Sector;
        public Region Region;
        public PlanetClass Class;
        public Climate Climate;
        public Atmosphere Atmosphere;
        public Faction Faction;
        public int Day, Year, Size, Surface, Population, EconomicRating, 
                   SocialRating, Wealth, Industry, Productivity, 
                   Capacity, MaximumCapacity;

        public Planet(string name, Faction faction) {
            Name = name;
            Coordinates = new Vector3(0, 0, 0);
            System = name;
            Demonym = name;
            Faction = Faction.GA;
            Sector = 0;
            Region = 0;
            Class = 0;
            Government = Game.FactionInfo.GetName(Faction);
            Day = Year = Size = Surface = Population = EconomicRating = 
                   SocialRating = Wealth = Industry = Productivity = 
                   Capacity = MaximumCapacity = 0;
        }
        public Planet(string name, Vector3 coordinates, string system, string demonym, string government, Sector sector, Region region, PlanetClass classs, Climate climate, Atmosphere atmosphere, Faction faction, int day, int year, int size, int surface, int population, int economicRating, int socialRating, int wealth, int industry, int productivity, int capacity, int maxCapacity) {
            Name = name;
            Coordinates = coordinates;
            System = system;
            Demonym = demonym;
            Government = government;
            Sector = sector;
            Region = region;
            Class = classs;
            Climate = climate;
            Atmosphere = atmosphere;
            Faction = faction;
            Day = day;
            Year = year;
            Size = size;
            Surface = surface;
            EconomicRating = economicRating;
            SocialRating = socialRating;
            Population = population;
            Wealth = wealth;
            Industry = industry;
            Productivity = productivity;
            Capacity = capacity;
            MaximumCapacity = maxCapacity;
        }
        public Planet(string encodedPlanet) {
            string one = encodedPlanet;
            string two, name, coordinates, system, demonym, government, sector, region, classs, climate, atmosphere, faction, day, year, size, surface, economicRating, socialRating, population, wealth, industry, productivity, capacity, maxCapacity;

            Parse.FirstPair(one, "Name", out name, out two);
            Parse.FirstPair(two, "Coordinates", out coordinates, out one);
            Parse.FirstPair(one, "System", out system, out two);
            Parse.FirstPair(two, "Demonym", out demonym, out one);
            Parse.FirstPair(one, "Government", out government, out two);
            Parse.FirstPair(two, "Sector", out sector, out one);
            Parse.FirstPair(one, "Region", out region, out two);
            Parse.FirstPair(two, "Class", out classs, out one);
            Parse.FirstPair(one, "Climate", out climate, out two);
            Parse.FirstPair(two, "Atmosphere", out atmosphere, out one);
            Parse.FirstPair(one, "Faction", out faction, out two);
            Parse.FirstPair(two, "Day", out day, out one);
            Parse.FirstPair(one, "Year", out year, out two);
            Parse.FirstPair(two, "Size", out size, out one);
            Parse.FirstPair(one, "Surface", out surface, out two);
            Parse.FirstPair(two, "EconomicRating", out economicRating, out one);
            Parse.FirstPair(one, "SocialRating", out socialRating, out two);
            Parse.FirstPair(two, "Population", out population, out one);
            Parse.FirstPair(one, "Wealth", out wealth, out two);
            Parse.FirstPair(two, "Industry", out industry, out one);
            Parse.FirstPair(one, "Productivity", out productivity, out two);
            Parse.FirstPair(two, "Capacity", out capacity, out one);
            Parse.FirstPair(one, "MaximumCapacity", out maxCapacity, out two);

            Name = name;
            Coordinates = new Vector3(coordinates);
            System = system;
            Demonym = demonym;
            Government = government;
            Sector = (Sector)Math.Parse(sector);
            Region = (Region)Math.Parse(region);
            Class = (PlanetClass)Math.Parse(classs);
            Climate = (Climate)Math.Parse(climate);
            Atmosphere = (Atmosphere)Math.Parse(atmosphere);
            Faction = (Faction)Math.Parse(faction);
            Day = Math.Parse(day);
            Year = Math.Parse(year);
            Size = Math.Parse(size);
            Surface = Math.Parse(surface);
            EconomicRating = Math.Parse(economicRating);
            SocialRating = Math.Parse(socialRating);
            Population = Math.Parse(population);
            Wealth = Math.Parse(wealth);
            Industry = Math.Parse(industry);
            Productivity = Math.Parse(productivity);
            Capacity = Math.Parse(capacity);
            MaximumCapacity = Math.Parse(maxCapacity);
        }
        public string Encode() {
            return "{\"Name\": \"" + Name
                   + "\", \"Coordinates\": \"" + Coordinates.Encode() 
                   + "\", \"System\": \"" + System
                   + "\", \"Demonym\": \"" + Demonym
                   + "\", \"Government\": \"" + Government
                   + "\", \"Sector\": \"" + Sector.ToString()
                   + "\", \"Region\": \"" + Region.ToString()
                   + "\", \"Class\": \"" + Class.ToString()
                   + "\", \"Climate\": \"" + Climate.ToString()
                   + "\", \"Atmosphere\": \"" + Atmosphere.ToString()
                   + "\", \"Faction\": \"" + Faction.ToString()
                   + "\", \"Day\": \"" + Day.ToString()
                   + "\", \"Year\": \"" + Year.ToString()
                   + "\", \"Size\": \"" + Size.ToString()
                   + "\", \"Surface\": \"" + Surface.ToString()
                   + "\", \"EconomicRating\": \"" + EconomicRating.ToString()
                   + "\", \"SocialRating\": \"" + SocialRating.ToString()
                   + "\", \"Population\": \"" + Population.ToString()
                   + "\", \"Wealth\": \"" + Wealth.ToString()
                   + "\", \"Industry\": \"" + Industry.ToString()
                   + "\", \"Productivity\": \"" + Productivity.ToString()
                   + "\", \"Capacity\": \"" + Capacity.ToString()
                   + "\", \"MaximumCapacity\": \"" + MaximumCapacity.ToString()
                   + "\"}";
        }
    }
}