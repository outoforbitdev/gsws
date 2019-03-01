////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                  player.cs                                 //
//                                 Player class                               //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 1, 2019              //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    class Player {
        public string Name;
        public Faction Faction;

        public Player(string name, Faction faction) {
            this.Name = name;
            this.Faction = faction;
        }
        public Player(string encodedName) {
            string encodedFaction, name, faction;
            Parse.FirstPair(encodedName, "Name", out name, out encodedFaction);
            Name = name;

            Parse.FirstPair(encodedFaction, "Faction", out faction, out encodedName);
            Faction = (Faction)Int32.Parse(faction);
        }
        public string Encode() {
            return "{\"Name\": \"" + Name 
                   + "\", \"Faction\": \"" + (int)Faction
                   +"\"}";
        }
    }
}