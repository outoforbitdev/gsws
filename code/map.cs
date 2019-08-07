////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   map.cs                                   //
//                  Implements a map of planets in the galaxy                 //
//              Created by: Jarett (Jay) Mirecki, March 04, 2019              //
//              Modified by: Jarett (Jay) Mirecki, March 04, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    public enum Sector { Coruscant }
    public enum Region { Core }
    public enum PlanetClass { Terrestrial }
    public enum Climate { Temperate }
    public enum Atmosphere { One }
    class Map {
        JMSuite.Collections.Graph<string, Planet> map;

        public Map() {
            map = new JMSuite.Collections.Graph<string, Planet>();
        }
        private void AddPlanet(Planet planet, 
                               string[] neighbors, 
                               int[] weights) {
            map.Add(planet.Name, planet, neighbors, weights);
        }
        private void DefaultMap() {
            Planet coruscant = new Planet("Coruscant", new Vector3(0, 0, 0), "Coruscant", "Coruscanti", "Empire", Sector.Coruscant, Region.Core, PlanetClass.Terrestrial, Climate.Temperate, Atmosphere.One, Faction.Empire, 24, 368, 12240, 99, 1000000000, 3, 3, 100000, 1000000, 100000, 1000000000, 1000000000);
        }
    }
}