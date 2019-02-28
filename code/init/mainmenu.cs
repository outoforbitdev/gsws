////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 mainmenu.cs                                //
//                         Create the opening main menu                       //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//            Modified by: Jarett (Jay) Mirecki, February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS.Initialize {
    partial class Menus {
        // MainMenu()
        // Creates the opening main menu and adds it to the MainPool
        // Parameters: None
        // Returns: void
        private static void MainMenu() {
            UI.Menu mainmenu = new UI.Menu("GSWS", "Please choose an option to begin:");
            mainmenu.Add("New Game");
            mainmenu.Add("Load Game");
            mainmenu.Add("Delete Game");
            mainmenu.Add("Quit Game");

            mainmenu.onSelect = 
                delegate(int i) {
                    switch(i) {
                        case 0:
                            GSWS.MainPool.Open("newgame");
                            mainmenu.ResetSelect();
                            break;
                        case 1:
                            Game.Init();
                            Game.Player.Name = "Avan Ardele";
                            Game.Faction = Game.Player.Faction = Faction.Extra1;
                            Game.FactionInfo.SetName(Game.Faction, "IMF");
                            Game.Date = 41 * 365;
                            Game.FactionInfo.SetFunds(Game.Faction, 1191876720);
                            Gov newGov = new Gov("IMF", 0, 0);
                            newGov.Population = 327167434;
                            newGov.Wealth = 30000;
                            newGov.Industry = 162637000;
                            newGov.Productivity = 126050;
                            newGov.Capacity = 400000000;
                            newGov.TaxResidential = 0.09;
                            newGov.TaxCommercial = 0.2;
                            Game.FactionInfo.SetGovernment(Game.Faction, newGov);
                            Game.UpdateMenus();
                            GSWS.MainPool.Open("gamemenu");
                            mainmenu.ResetSelect();
                            break;
                        case 2:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 3:
                            mainmenu.Quit();
                            break;
                        default:
                            break;
                    }
                };

            GSWS.MainPool.Add("mainmenu", mainmenu);
        }
        // NotImplemented()
        // Creates the "not implemented" screen and adds it to the MainPool
        // Parameters: None
        // Returns: void
        private static void NotImplemented() {
            UI.Menu menu = new UI.Menu("This feature is not implemented yet", "Hopefully it will be added soon");
            menu.Add("OK");
            menu.onSelect =
                delegate(int i) {
                    menu.Quit();
                };
            GSWS.MainPool.Add("notimplemented", menu);
        }
    }
}