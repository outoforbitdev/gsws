using System;

namespace GSWS {
    public enum Faction { GA, Empire, Confederation, Hapes, Mandalore, CSA, Extra1, Extra2, Extra3, Extra4, Extra5 }

    public class FactionInfo {
        private string[] Name;
        private int[] Funds;
        private Gov[] Government;

        private const int NumFactions = 11;

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