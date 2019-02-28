////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   menu.cs                                  //
//                           Impementation of menus                           //
//             Created by: Jarett (Jay) Mirecki, February 20, 2019            //
//             Modified by: Jarett (Jay) Mirecki February 27, 2019            //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace GSWS.UI {
    public class Menu {
        List<string> options;

        public delegate void OnSelect(int i);
        public delegate void OnInput(string s);
        public delegate void OnLoad();
        public OnSelect onSelect;
        public OnInput onInput;
        public OnLoad onLoad;
        int select;
        string Title, Subtitle;
        string[] TitleBox, ToolTip;
        bool done, input;

        // Constructor
        // Creates an option menu with the specified title
        // Parameters: string name of the menu
        public Menu(string name) {
            Setup(name, "", null, false);
        }
        // Constructor
        // Creates an option menu with the specified title and subtitle
        // Parameters: string name of the menu
        //             string description of the menu
        public Menu(string name, string subname) {
            Setup(name, subname, null, false);
        }
        // Constructor
        // Creates an option or input menu with the specified title
        // Parameters: string name of the menu
        //             boolean for whether the menu accepts input
        public Menu(string name, bool text) {
            Setup(name, "", null, text);
        }
        // Constructor
        // Creates an option or input menu with the specified title and subtitle
        // Parameters: string name of the menu
        //             string description of the menu
        //             boolean for whether the menu accepts input
        public Menu(string name, string subname, bool text) {
            Setup(name, subname, null, text);
        }
        // Constructor
        // Creates an option or input menu with the specified title, subtitle, 
        //     and tooltip
        // Parameters: string name of the menu
        //             string description of the menu
        //             string array for the tooltip
        //             boolean for whether the menu accepts input
        public Menu(string name, string subname, string[] tooltip, bool text) {
            Setup(name, subname, tooltip, text);
        }
        // UpdateToolTip
        // Updates the tool tip for the menu
        // Paramters: string array to replace the tooltip
        // Returns: void
        public void UpdateToolTip(string[] newToolTip) {
            ToolTip = newToolTip;
            BuildTitleBox();
        }
        // ResetSelect
        // Resets the currently selected option to the first item
        // Paramters: None
        // Returns: void
        public void ResetSelect() {
            select = 0;
        }
        private void Setup(string name, string subname, string[] tips, bool text) {
            options = new List<string>();
            select = 0;
            Title = name.ToUpper();
            Subtitle = subname;
            ToolTip = tips;
            BuildTitleBox();
            done = true;
            onSelect = delegate(int i) {return;};
            onInput = delegate(string s) {return;};
            onLoad = delegate() {return;};
            input = text;
        }
        private void BuildTitleBox() {
            if (ToolTip == null)
                TitleBox = new string[2];
            else
                TitleBox = new string[ToolTip.Length + 2];
            TitleBox[0] = Title;
            TitleBox[1] = Subtitle;
            if (ToolTip != null)
                for (int i = 0; i < ToolTip.Length; i++)
                    TitleBox[2 + i] = ToolTip[i];
        }
        // Add
        // Adds an option to the end of the menu
        // Paramters: string name of the option to add
        // Returns: void
        public void Add(string option) {
            options.Add(option);
        }
        // Print
        // Prints the menu
        // Paramters: None
        // Returns: void
        public void Print() {
            if (input) {
                JMSuite.UI.ConsoleDisplay.PrintMiddle(TitleBox, options.ToArray());
            }  else {
                JMSuite.UI.ConsoleDisplay.PrintMiddle(TitleBox, options.ToArray(), select);
            }
        }
        // Next
        // Moves the selector to the next option
        // Paramters: None
        // Returns: void
        public void Next() {
            select++;
            if (select >= options.Count)
                select = 0;
        }
        // Previous
        // Moves the selector to the previous option
        // Paramters: None
        // Returns: void
        public void Previous() {
            select--;
            if (select < 0)
                select = options.Count - 1;
        }
        // Enter
        // Loads the menu for the client to use
        // Paramters: None
        // Returns: void
        public void Enter() {
            onLoad();
            done = false;
            if (input) {
                Print();
                string selection = Console.ReadLine();
                onInput(selection);
            } else {
                while(!done) {
                    Print();
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                        Previous();
                    else if (key.Key == ConsoleKey.DownArrow)
                        Next();
                    else if (key.Key == ConsoleKey.Q)
                        done = true;
                    else if (key.Key == ConsoleKey.Enter)
                        onSelect(select);
                }
            }
        }
        // Quit
        // Quits the menu (has no effect if the menu is not entered)
        // Paramters: None
        // Returns: void
        public void Quit() {
            ResetSelect();
            done = true;
        }
    }
}