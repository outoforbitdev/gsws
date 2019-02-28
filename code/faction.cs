////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 faction.cs                                 //
//                       Implements faction information                       //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
// Factions are implemented as an enumeration, and a series of arrays holding //
// information specific to each faction. The arrays are accessed by setter    //
// and getter functions which index into the array using the faction          //
// enumerations.                                                              //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    // Enumeration of factions for access to FactionInfo Arrays
    public enum Faction { GA, Empire, Confederation, Hapes, Mandalore, CSA, Extra1, Extra2, Extra3, Extra4, Extra5 }

    public class FactionInfo {
        private string[] Name;
        private int[] Funds;
        private Gov[] Government;

        private const int NumFactions = 11;

        // Constructor, initializes the FactionInfo arrays
        public FactionInfo() {
            Name = new string[] { "Galactic Federation of Free Alliances", 
                                  "Galactic Empire",
                                  "Confederation",
                                  "Hapes Consortium",
                                  "Mandalorian Protectorate",
                                  "Corporate Sector Authority",
                                  "Extra 1",
                                  "Extra 2",
                                  "Extra 3",
                                  "Extra 4",
                                  "Extra 5" };
            Funds = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Government = new Gov[NumFactions];
            for (int i = 0; i < NumFactions; i++)
                Government[i] = new Gov(Name[i], 0, 0);
        }
        // Setters and getters that are self explanatory. Each getter accepts a 
        // Faction enumeration and returns the expected type, while each setter 
        // accepts the faction enumeration the type of the array being set.
        public int GetFunds(Faction faction) {
            return Funds[(int)faction];
        }
        public void SetFunds(Faction faction, int funds) {
            Funds[(int)faction] = funds;
        }
        public string GetName(Faction faction) {
            return Name[(int)faction];
        }
        public void SetName(Faction faction, string name) {
            Name[(int)faction] = name;
        }
        public Gov GetGovernment(Faction faction) {
            return Government[(int)faction];
        }
        public void SetGovernment(Faction faction, Gov government) {
            Government[(int)faction] = government;
        }
    }
}