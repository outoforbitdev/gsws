using System;

namespace GSWS {
    static class Game {
        public static Player Player { get; set; }
        public static Faction Faction { get; set; }
        public static FactionInfo FactionInfo;
        public static int Date;
        public enum DateSystem { ABY };

        public static void Init() {
            Faction = Faction.GA;
            Player = new Player("", Faction);
            Date = 0;
            FactionInfo = new FactionInfo();
        }
        public static void UpdateMenus() {
            JMSuite.UI.ConsoleDisplay.Title = new string[] { "GSWS", "Player: " + Player.Name, "Faction: " + FactionInfo.GetName(Faction), "Date: " 
                                                            + ConvertYear(Date, DateSystem.ABY), "Funds: ₹" + String.Format("{0:n0}", FactionInfo.GetFunds(Faction)) };
        }
        public static int ConvertYear(int date, DateSystem system) {
            if (system == DateSystem.ABY) {
                if (date > 0)
                    return date / 365;
            }
            return 0;
        }
    }
}