using System;

namespace GSWS.Initialize {
    partial class Menus {
        private static void NewGame() {
            namemenu();
            factionmenu();
            eramenu();
            fundsmenu();
        }
        private static void namemenu() {
            UI.Menu newmenu = new UI.Menu("New Game", "Please enter your character's name:", true);
            newmenu.onInput = 
                delegate(string s)  {
                    Game.Init();
                    Game.Player.Name = s;
                    GSWS.MainPool.Open("chooseera");
                    newmenu.Quit();
                };
            GSWS.MainPool.Add("newgame", newmenu);
        }
        private static void eramenu() {
            UI.Menu era = new UI.Menu("New Game", "Please choose a start date");
            era.Add("1000 BBY: Rise of the Empire Era (Early)");
            era.Add("31 BBY: Rise of the Empire Era (Late)");
            era.Add("0 ABY: Rebellion Era");
            era.Add("5 ABY: New Republic Era");
            era.Add("25 ABY: New Jedi Order Era");
            era.Add("37 ABY: Legacy Era");
            era.onSelect =
                delegate(int i) {
                    switch(i) {
                        case 0:
                            Game.Date = 365 * -1000;
                            break;
                        case 1:
                            Game.Date = 365 * -31;
                            break;
                        case 2:
                            Game.Date = 365 * 0;
                            break;
                        case 3:
                            Game.Date = 365 * 5;
                            break;
                        case 4:
                            Game.Date = 365 * 25;
                            break;
                        case 5:
                            Game.Date = 365 * 37;
                            break;
                    }
                    GSWS.MainPool.Open("choosefaction");
                    era.Quit();
                };
            GSWS.MainPool.Add("chooseera", era);
        }
        private static void factionmenu() {
            UI.Menu faction = new UI.Menu("New Game", "Please choose your faction");
            faction.Add("Galactic Federation of Free Alliances");
            faction.Add("Galactic Empire");
            faction.Add("Confederation");
            // faction.Add("Hapes Consortium");
            // faction.Add("Mandalorian Protectorate");
            // faction.Add("Corporate Sector Authority");
            faction.onSelect =
                delegate(int i) {
                    switch(i) {
                        case 0:
                            Game.Faction = Game.Player.Faction = Faction.GA;
                            break;
                        case 1:
                            Game.Faction = Game.Player.Faction = Faction.Empire;
                            break;
                        case 2:
                            Game.Faction = Game.Player.Faction = Faction.Confederation;
                            break;
                        default:
                            break;
                    }
                    GSWS.MainPool.Open("choosefunds");
                    faction.Quit();
                };
            GSWS.MainPool.Add("choosefaction", faction);
        }
        private static void fundsmenu() {
            UI.Menu funds = new UI.Menu("New Game", "Please enter your starting funds", true);
            funds.onInput =
                delegate(string s) {
                    int amount = 0;
                    Int32.TryParse(s, out amount);
                    Game.FactionInfo.SetFunds(Game.Faction, amount);
                    Game.UpdateMenus();
                    GSWS.MainPool.Open("gamemenu");
                    funds.Quit();
                };
            GSWS.MainPool.Add("choosefunds", funds);
        }
    }
}