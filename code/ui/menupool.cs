using System;
using System.Collections.Generic;

namespace GSWS.UI {
    public class MenuPool {
        IDictionary<string, Menu> menus;
        string curr;
        
        public MenuPool() {
            menus = new Dictionary<string, Menu>();
            curr = "";
        }
        public void Add(string name, Menu menu) {
            menus.Add(name, menu);
            if (curr == "")
                curr = name;
        }
        public void Enter() {
            Menu menu;
            if (menus.TryGetValue(curr, out menu))
                menu.Enter();
            else {
                string [] message = {"MenuPool Error", curr + " is not a valid menu"};
                JMSuite.UI.ConsoleDisplay.PrintMiddle(message, 2);
            }

            // bool quit = false;
            // while(!quit) {
            //     menu.Print();
            //     ConsoleKeyInfo key = Console.ReadKey();
            //     if (key.Key == ConsoleKey.UpArrow)
            //         menu.Previous();
            //     else if (key.Key == ConsoleKey.DownArrow)
            //         menu.Next();
            //     else if (key.Key == ConsoleKey.Q)
            //         quit = true;
            // }
            // menu.Enter();
        }
        public void Open(string name) {
            Menu menu;
            if (menus.TryGetValue(name, out menu))
                menu.Enter();
            else {
                string [] message = {"MenuPool Error", name + " is not a valid menu"};
                JMSuite.UI.ConsoleDisplay.PrintMiddle(message, 2);
            }
        }
    }
}