using System;

namespace GSWS.Initialize {
    partial class Menus {
        private static void GovMenu() {
            TaxMenu();
            UI.Menu menu = new UI.Menu("Government", "Please choose an option");
            menu.Add("Calculate Pressure");
            menu.Add("Adjust Tax Rate");
            menu.Add("Back");
            menu.onSelect =
                delegate(int i) {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    switch(i) {
                        case 0:
                            gov.CalculatePressure();
                            break;
                        case 1:
                            GSWS.MainPool.Open("taxmenu");
                            break;
                        case 2:
                            menu.Quit();
                            break;
                        default:
                            break;
                    }
                    menu.UpdateToolTip(gov.GetToolTip());
                };
            menu.onLoad =
                delegate() {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    menu.UpdateToolTip(gov.GetToolTip());
                };
            GSWS.MainPool.Add("govmenu",menu);
        }
        private static void TaxMenu() {
            RTaxMenu();
            CTaxMenu();
            UI.Menu menu = new UI.Menu("Taxes", "Please choose an option");
            menu.Add("Adjust Residential Rate");
            menu.Add("Adjust Commercial Rate");
            menu.Add("Back");
            menu.onSelect = 
                delegate(int i) {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    switch(i) {
                        case 0:
                            GSWS.MainPool.Open("rtaxmenu");
                            menu.UpdateToolTip(new string[] { "Residential Rate: " + gov.TaxResidential + "     Commericial Rate: " + gov.TaxCommercial });
                            break;
                        case 1:
                            GSWS.MainPool.Open("ctaxmenu");
                            menu.UpdateToolTip(new string[] { "Residential Rate: " + gov.TaxResidential + "     Commericial Rate: " + gov.TaxCommercial });
                            break;
                        case 2:
                            menu.Quit();
                            break;
                        default:
                            break;
                    }
                };
            menu.onLoad =
                delegate() {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    menu.UpdateToolTip(new string[] { "Residential Rate: " + gov.TaxResidential + "     Commericial Rate: " + gov.TaxCommercial });
                };
            GSWS.MainPool.Add("taxmenu",menu);
        }
        private static void RTaxMenu() {
            UI.Menu menu = new UI.Menu("Residential Tax Rate", "Please enter a tax rate", true);
            menu.onInput =
                delegate(string s) {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    double rate = 0;
                    Double.TryParse(s, out rate);
                    gov.TaxResidential = rate;
                    Game.FactionInfo.SetGovernment(Game.Faction, gov);
                    menu.Quit();
                };
            menu.onLoad =
                delegate() {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    menu.UpdateToolTip(new string[] { "Currently " + gov.TaxResidential });
                };
            GSWS.MainPool.Add("rtaxmenu",menu);
        }
        private static void CTaxMenu() {
            UI.Menu menu = new UI.Menu("Residential Tax Rate", "Please enter a tax rate", true);
            menu.onInput =
                delegate(string s) {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    double rate = 0;
                    Double.TryParse(s, out rate);
                    gov.TaxCommercial = rate;
                    Game.FactionInfo.SetGovernment(Game.Faction, gov);
                    menu.Quit();
                };
            menu.onLoad =
                delegate() {
                    Gov gov = Game.FactionInfo.GetGovernment(Game.Faction);
                    menu.UpdateToolTip(new string[] { "Currently " + gov.TaxCommercial });
                };
            GSWS.MainPool.Add("ctaxmenu",menu);
        }
    }
}