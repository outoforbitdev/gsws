using System;

namespace GSWS {
    public enum DateSystem { ABY }
    public class Date {
        private const int YearLength = 368;
        private string[] era = { "ABY" };
        private int DateInt;
        private DateSystem System;
        public Date() {
            SetDate(0, DateSystem.ABY);
        }
        public Date(int date, DateSystem system) {
            SetDate(date, system);
        }
        public void SetDate(int date, DateSystem system) {
            DateInt = date;
            System = system;
        }
        public override string ToString() {
            int day, year;
            string dateString;
            if (System == DateSystem.ABY) {
                day = DateInt % YearLength + 1;
                year = DateInt / YearLength;
            } else {
                day = 0;
                year = 0;
            }
            dateString = day.ToString() + ":" 
                         + year.ToString() + " " 
                         + era[(int)System];
            return dateString;
        }
    }
}