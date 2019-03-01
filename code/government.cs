////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                government.cs                               //
//                       Representation of a government                       //
//             Created by: Jarett (Jay) Mirecki, February 21, 2019            //
//              Modified by: Jarett (Jay) Mirecki, March 01, 2019             //
//                                                                            //
// Currently, the government class holds information that will eventually be  //
// extracted into the Planet class (Economic, Social, Population statistics), //
// and more fields will be added for positions in the government, laws, and   //
// balance of power.                                                          //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;

namespace GSWS {
    public class Gov {
        public string Name { get; private set; }
        public int Economic { get; private set;  }
        public int Social { get; private set;  }
        public int Population { get; set;  }
        public int Wealth { get; set;  }
        public int Industry { get; set;  }
        public int Productivity { get; set;  }
        public int Capacity { get; set;  }
        public double PopulationPressure { get; private set;  }
        public double WealthPressure { get; private set;  }
        public double IndustryPressure { get; private set;  }
        public double ProductivityPressure { get; private set;  }
        public double CapacityPressure { get; private set;  }
        public double PopulationPressureF { get; private set;  }
        public double WealthPressureF { get; private set;  }
        public double IndustryPressureF { get; private set;  }
        public double ProductivityPressureF { get; private set;  }
        public double CapacityPressureF { get; private set;  }
        public double TaxResidential;
        public double TaxCommercial;

        public Gov(string name, int economic, int social) {
            this.Name = name;
            this.Economic = economic;
            this.Social = social;
            Population = Wealth = Industry = Productivity = Capacity = 0;
            PopulationPressure = WealthPressure = IndustryPressure = ProductivityPressure = CapacityPressure = 0;
        }
        public Gov(string encodedGov) {
            string one = encodedGov;
            string two, name, economic, social, population, wealth, industry, productivity, capacity, taxResidential, taxCommercial;

            Parse.FirstPair(one, "Name", out name, out two);
            Parse.FirstPair(two, "Economic", out economic, out one);
            Parse.FirstPair(one, "Social", out social, out two);
            Parse.FirstPair(two, "Population", out population, out one);
            Parse.FirstPair(one, "Wealth", out wealth, out two);
            Parse.FirstPair(two, "Industry", out industry, out one);
            Parse.FirstPair(one, "Productivity", out productivity, out two);
            Parse.FirstPair(two, "Capacity", out capacity, out one);
            Parse.FirstPair(one, "TaxResidential", out taxResidential, out two);
            Parse.FirstPair(two, "TaxCommercial", out taxCommercial, out one);

            int TryEconomic, TrySocial, TryPopulation, TryWealth, TryIndustry, TryProductivity, TryCapacity, TryTaxResidential, TryTaxCommercial;
            Int32.TryParse(economic, out TryEconomic);
            Int32.TryParse(social, out TrySocial);
            Int32.TryParse(population, out TryPopulation);
            Int32.TryParse(wealth, out TryWealth);
            Int32.TryParse(industry, out TryIndustry);
            Int32.TryParse(productivity, out TryProductivity);
            Int32.TryParse(capacity, out TryCapacity);
            Int32.TryParse(taxResidential, out TryTaxResidential);
            Int32.TryParse(taxCommercial, out TryTaxCommercial);

            Economic = TryEconomic;
            Social = TrySocial;
            Population = TryPopulation;
            Wealth = TryWealth;
            Industry = TryIndustry;
            Productivity = TryProductivity;
            Capacity = TryCapacity;
            TaxResidential = TryTaxResidential;
            TaxCommercial = TryTaxCommercial;
        }
        public string Encode() {
            return "{\"Name\": \"" + Name 
                   + "\", \"Economic\": \"" + Economic.ToString()
                   + "\", \"Social\": \"" + Social.ToString()
                   + "\", \"Population\": \"" + Population.ToString()
                   + "\", \"Wealth\": \"" + Wealth.ToString()
                   + "\", \"Industry\": \"" + Industry.ToString()
                   + "\", \"Productivity\": \"" + Productivity.ToString()
                   + "\", \"Capacity\": \"" + Capacity.ToString()
                   + "\", \"TaxResidential\": \"" + TaxResidential.ToString()
                   + "\", \"TaxCommercial\": \"" + TaxCommercial.ToString()
                   + "\"}";
        }
        public void CalculatePressure() {
            PopulationPressure = (double)Wealth / 40000 + (double)Industry / Population;// + Capacity / Population;
            WealthPressure = (double)Industry / Population + (double)Productivity / 200000;
            IndustryPressure = (double)Population / Industry + (double)Productivity / 100000 - TaxCommercial / 0.2;
            ProductivityPressure = (double)Wealth / 60000 + (double)Population / Industry;
            CapacityPressure = (double)(Population + Industry) / Capacity;
            PopulationPressureF = Wealth / 40000 + Industry / Population - (int)(TaxResidential / (Math.Log10((double)Wealth) * 0.05));// + Capacity / Population;
            WealthPressureF = Industry / Population + Productivity / 200000;
            IndustryPressureF = Population / Industry + Productivity / 100000 - (int)(TaxCommercial / 0.2);
            ProductivityPressureF = Wealth / 60000 + Population / Industry;
            CapacityPressureF = (Population + Industry) / Capacity;
        }
        public int TaxIncome() {
            return (int)(Population * Wealth * TaxResidential + Industry + Productivity * TaxCommercial);
        }
        public string[] GetToolTip() {
            string space = "     ";
            string[] ToolTip = { "Statistics:",
                                 "Population: " + Population + space + "Wealth: " + Wealth + space +
                                 "Industry: " + Industry + space + "Productivity: " + Productivity + space +
                                 "Capacity: " + Capacity,
                                 "Pressure:",
                                 "Population: " + Math.Round(PopulationPressure, 2) + space + "Wealth: " + Math.Round(WealthPressure, 2) + space +
                                 "Industry: " + Math.Round(IndustryPressure, 2) + space + "Productivity: " + Math.Round(ProductivityPressure, 2) + space +
                                 "Capacity: " + Math.Round(CapacityPressure, 2),
                                 "Effective Pressure:",
                                 "Population: " + PopulationPressureF + space + "Wealth: " + WealthPressureF + space +
                                 "Industry: " + IndustryPressureF + space + "Productivity: " + ProductivityPressureF + space +
                                 "Capacity: " + CapacityPressureF,
                                 "Taxes:",
                                 "Residential Rate: " + Math.Round(TaxResidential, 2) + space + "Commercial Rate: " + Math.Round(TaxCommercial, 2) + space +
                                 "Expected Income: " + String.Format("{0:n0}", TaxIncome()) };
            return ToolTip;
        }
    }
}