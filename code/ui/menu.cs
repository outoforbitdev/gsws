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

        public Menu(string name) {
            Setup(name, "", null, false);
        }
        public Menu(string name, string subname) {
            Setup(name, subname, null, false);
        }
        public Menu(string name, bool text) {
            Setup(name, "", null, text);
        }
        public Menu(string name, string subname, bool text) {
            Setup(name, subname, null, text);
        }
        public Menu(string name, string subname, string[] tooltip, bool text) {
            Setup(name, subname, tooltip, text);
        }
        public void UpdateToolTip(string[] newToolTip) {
            ToolTip = newToolTip;
            BuildTitleBox();
        }
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
        public void Add(string option) {
            options.Add(option);
        }
        public void Print() {
            if (input) {
                JMSuite.UI.ConsoleDisplay.PrintMiddle(TitleBox, options.ToArray());
            }  else {
                JMSuite.UI.ConsoleDisplay.PrintMiddle(TitleBox, options.ToArray(), select);
            }
        }
        public void Next() {
            select++;
            if (select >= options.Count)
                select = 0;
        }
        public void Previous() {
            select--;
            if (select < 0)
                select = options.Count - 1;
        }
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
        public void Quit() {
            ResetSelect();
            done = true;
        }
    }
}