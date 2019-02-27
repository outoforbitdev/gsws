using System;

namespace GSWS.Initialize {
    partial class Menus {
        public static void Init() {
            MainMenu();
            NewGame();
            GameMenu();
            GovMenu();
            NotImplemented();
        }
        private static void GameMenu() {
            UI.Menu gamemenu = new UI.Menu("GSWS", "Please choose an option");
            gamemenu.Add("Administration");
            gamemenu.Add("War Room");
            gamemenu.Add("Holonet News Network");
            gamemenu.Add("Save");
            gamemenu.Add("Save & Exit");
            gamemenu.Add("Exit Session");
            gamemenu.onSelect =
                delegate(int i) {
                    switch(i) {
                        case 0:
                            GSWS.MainPool.Open("govmenu");
                            break;
                        case 1:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 2:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 3:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 4:
                            GSWS.MainPool.Open("notimplemented");
                            break;
                        case 5:
                             JMSuite.UI.ConsoleDisplay.Title = new string[] {"GSWS"};
                            gamemenu.Quit();
                            break;
                        default:
                            break;
                    }
                };
            GSWS.MainPool.Add("gamemenu", gamemenu);
        }
    }
}