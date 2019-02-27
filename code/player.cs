using System;

namespace GSWS {
    class Player {
        public string Name;
        public Faction Faction;

        public Player(string name, Faction faction) {
            this.Name = name;
            this.Faction = faction;
        }
    }
}