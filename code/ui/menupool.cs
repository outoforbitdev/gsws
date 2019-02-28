////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 menupool.cs                                //
//                        Collection of menus to access                       //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//             Modified by: Jarett (Jay) Mirecki February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace GSWS.UI {
    public class MenuPool {
        IDictionary<string, Menu> menus;
        string curr;
        
        // Constructor
        // Parameters: None
        public MenuPool() {
            menus = new Dictionary<string, Menu>();
            curr = "";
        }
        // Add
        // Adds the specified menu to the menu pool under the given string
        // Parameters: string name to store the menu under
        //             Menu menu to store
        // Returns: void
        public void Add(string name, Menu menu) {
            menus.Add(name, menu);
            if (curr == "")
                curr = name;
        }
        // Enter (DEPRECATED)
        // Enters the current menu
        // Parameters: None
        // Returns: void
        public void Enter() {
            Menu menu;
            if (menus.TryGetValue(curr, out menu))
                menu.Enter();
            else {
                string [] message = {"MenuPool Error", curr + " is not a valid menu"};
                JMSuite.UI.ConsoleDisplay.PrintMiddle(message, 2);
            }
        }
        // Open
        // Opens the specified menu
        // Parameters: string name of menu to open
        // Returns: void
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